using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace CycleBike.Adapters.SocketServerAdapter.RealTime.Hubs;

public class NotificationsHub(ILogger<NotificationsHub> logger) : Hub
{
    public override async Task OnConnectedAsync()
    {
        logger.LogInformation("Client connected: {ConnectionId}", Context.ConnectionId);
        await base.OnConnectedAsync();
    }
    
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        logger.LogInformation("Client disconnected: {ConnectionId}", Context.ConnectionId);
        await base.OnDisconnectedAsync(exception);
    }

    public Task SendNotification(object payload)
        => Clients.All.SendAsync("notification", payload);
    
    public async Task JoinGroup(string groupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        logger.LogInformation("Client {ConnectionId} joined group {GroupName}", 
            Context.ConnectionId, groupName);
    }
    
    public async Task LeaveGroup(string groupName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        logger.LogInformation("Client {ConnectionId} left group {GroupName}", 
            Context.ConnectionId, groupName);
    }
}