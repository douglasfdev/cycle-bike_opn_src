using Asp.Versioning;
using CycleBike.Adapters.SocketAdapter.Abstractions;
using CycleBike.Adapters.SocketServerAdapter.RealTime.Hubs;
using CycleBike.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CycleBike.Adapters.WebApi.Controllers.V1.SocketTest;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class SocketTestController(
    ILogger<SocketTestController> logger,
    IHubContext<NotificationsHub> hubContext,
    ISocketAdapter socketAdapter
    ) : ControllerBase
{
    
    [HttpGet("connect")]
    public async Task<IActionResult> TestSignalR(CancellationToken cancellationToken)
    {
        logger.LogInformation("Sending notification via SignalR");

        await hubContext.Clients.All.SendAsync(
            "notification",
            new { Ok = true },
            cancellationToken: cancellationToken);

        return Ok(new { message = "Notification sent successfully" });
    }
    
    [HttpGet("connect2")]
    public async Task<IActionResult> Connect(CancellationToken cancellationToken)
    {
        logger.LogInformation("Connecting SocketAdapter to SignalR hub...");

        await socketAdapter.ConnectAsync(cancellationToken);

        return Ok(new
        {
            message = "Adapter connected",
            isConnected = socketAdapter.IsConnected
        });
    }
    
    [HttpGet("send")]
    public async Task<IActionResult> SendUsingAdapter(CancellationToken cancellationToken)
    {
        if (!socketAdapter.IsConnected)
        {
            logger.LogInformation("Adapter not connected. Connecting...");
            await socketAdapter.ConnectAsync(cancellationToken);
        }

        try
        {

            await socketAdapter.EmitAsync("SendNotification",
                new NotificationMessage(
                    true,
                    "WebApi-Adapter",
                    "Hello via ISocketAdapter"),
                cancellationToken);

            return Ok(new { message = "Notification sent via adapter" });
        }
        catch (Exception e)
        {
            logger.LogInformation(e.Message);
            throw;
        }
    }
}