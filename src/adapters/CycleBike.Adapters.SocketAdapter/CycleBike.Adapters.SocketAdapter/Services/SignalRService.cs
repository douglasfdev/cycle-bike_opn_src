using CycleBike.Adapters.SocketAdapter.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR.Client;

namespace CycleBike.Adapters.SocketAdapter.Services;

public class SignalRService(HubConnection connection, ILogger<SignalRService> logger) : ISocketAdapter
{
    private readonly HubConnection _connection = connection;
    private readonly ILogger<SignalRService> _logger = logger;
    private readonly Dictionary<string, IDisposable> _subscriptions = [];
    private bool _disposed;

    public bool IsConnected => _connection.State == HubConnectionState.Connected;

    public event EventHandler? Connected;
    public event EventHandler? Disconnected;
    public event EventHandler<Exception?>? Reconnecting;
    public event EventHandler<string?>? Reconnected;
    public event EventHandler<Exception?>? Closed;

    private void ConfigureConnectionEvents()
    {
        _connection.Closed += async error =>
        {
            _logger.LogWarning(error, "SignalR connection closed");
            Closed?.Invoke(this, error);
            await Task.CompletedTask;
        };

        _connection.Reconnecting += error =>
        {
            _logger.LogWarning(error, "SignalR reconnecting...");
            Reconnecting?.Invoke(this, error);
            return Task.CompletedTask;
        };

        _connection.Reconnected += connectionId =>
        {
            _logger.LogInformation("SignalR reconnected. ConnectionId: {ConnectionId}", connectionId);
            Reconnected?.Invoke(this, connectionId);
            return Task.CompletedTask;
        };
    }

    public async Task ConnectAsync(CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);

        if (_connection.State == HubConnectionState.Connected)
        {
            _logger.LogWarning("Already connected to SignalR hub");
            return;
        }

        try
        {
            await _connection.StartAsync(cancellationToken);
            _logger.LogInformation("Connected to SignalR hub. ConnectionId: {ConnectionId}", 
                _connection.ConnectionId);
            Connected?.Invoke(this, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to connect to SignalR hub");
            throw;
        }
    }

    public async Task DisconnectAsync(CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);

        if (_connection.State == HubConnectionState.Disconnected)
        {
            _logger.LogWarning("Already disconnected from SignalR hub");
            return;
        }

        try
        {
            await _connection.StopAsync(cancellationToken);
            _logger.LogInformation("Disconnected from SignalR hub");
            Disconnected?.Invoke(this, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error disconnecting from SignalR hub");
            throw;
        }
    }

    public async Task EmitAsync<T>(string methodName, T data, CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        ArgumentException.ThrowIfNullOrWhiteSpace(methodName);

        try
        {
            await _connection.InvokeAsync(methodName, data, cancellationToken);
            _logger.LogDebug("Emitted {MethodName} with data: {Data}", methodName, data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error emitting {MethodName}", methodName);
            throw;
        }
    }

    public async Task<TResult> InvokeAsync<TResult>(string methodName, CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        ArgumentException.ThrowIfNullOrWhiteSpace(methodName);

        try
        {
            var result = await _connection.InvokeAsync<TResult>(methodName, cancellationToken);
            _logger.LogDebug("Invoked {MethodName}, result: {Result}", methodName, result);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error invoking {MethodName}", methodName);
            throw;
        }
    }

    public async Task<TResult> InvokeAsync<T, TResult>(string methodName, T data, CancellationToken cancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        ArgumentException.ThrowIfNullOrWhiteSpace(methodName);

        try
        {
            var result = await _connection.InvokeAsync<TResult>(methodName, data, cancellationToken);
            _logger.LogDebug("Invoked {MethodName} with data: {Data}, result: {Result}", methodName, data, result);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error invoking {MethodName}", methodName);
            throw;
        }
    }

    public void On<T>(string methodName, Action<T> handler)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        ArgumentException.ThrowIfNullOrWhiteSpace(methodName);
        ArgumentNullException.ThrowIfNull(handler);

        if (_subscriptions.ContainsKey(methodName))
        {
            _logger.LogWarning("Handler for {MethodName} already exists. Removing old handler.", methodName);
            Off(methodName);
        }

        var subscription = _connection.On(methodName, handler);
        _subscriptions[methodName] = subscription;
        _logger.LogDebug("Registered handler for {MethodName}", methodName);
    }

    public void Off(string methodName)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        ArgumentException.ThrowIfNullOrWhiteSpace(methodName);

        if (_subscriptions.Remove(methodName, out var subscription))
        {
            subscription.Dispose();
            _logger.LogDebug("Unregistered handler for {MethodName}", methodName);
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_disposed) return;

        foreach (var subscription in _subscriptions.Values)
        {
            subscription.Dispose();
        }
        _subscriptions.Clear();

        await _connection.DisposeAsync();
        _disposed = true;

        _logger.LogInformation("SignalRAdapter disposed");
    }
}