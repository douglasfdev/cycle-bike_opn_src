namespace CycleBike.Adapters.SocketAdapter.Abstractions;

public interface ISocketAdapter: IAsyncDisposable
{
    Task ConnectAsync(CancellationToken cancellationToken = default);
    Task DisconnectAsync(CancellationToken cancellationToken = default);
    Task EmitAsync<T>(string methodName, T data, CancellationToken cancellationToken = default);
    Task<TResult> InvokeAsync<TResult>(string methodName, CancellationToken cancellationToken = default);
    Task<TResult> InvokeAsync<T, TResult>(string methodName, T data, CancellationToken cancellationToken = default);
    void On<T>(string methodName, Action<T> handler);
    void Off(string methodName);
    bool IsConnected { get; }
    event EventHandler? Connected;
    event EventHandler? Disconnected;
    event EventHandler<Exception?>? Reconnecting;
    event EventHandler<string?>? Reconnected;
    event EventHandler<Exception?>? Closed;
}