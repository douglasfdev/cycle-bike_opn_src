using System.Text.Json;
using Asp.Versioning;
using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Modules.Events.Envelopes;
using CycleBike.Core.Domain.Requests;
using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace CycleBike.Adapters.WebApi.Controllers.V1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiVersion("1.0")]
public class ProductController(IMessagePublisher bus, ICacheService cacheService, IOutboxService service): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PublishProduct([FromBody] ProductRequest request)
    {
        var envelope = await service.EnqueueAsync(request);
        await bus.PublishAsync(envelope, "ProductRequests", "Initial");
        return Accepted(new { message = "Produto sendo processado" });
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductRequest request)
    {
        var getCache = await cacheService.GetOrSetDataAsync(request.Name,  async () =>
        {
            var message = new InboxMessage(DateTime.UtcNow, true, 0);
            await service.EnqueueAsync(message);
            
            return message;
        }, TimeSpan.FromMinutes(2));
        return Ok(getCache);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPendingMessages()
    {
        var envelopes = await service.GetPendingMessagesAsync();
        var resolved = envelopes.Select<OutboxEnvelope, OutboxEnvelope?>(envelope =>
        {
            if (envelope.MessageType is null) return null;
            try
            {
                var messageType = Type.GetType(envelope.MessageType);

                if (messageType == null) return null;

                var decodedContent = JsonSerializer.Deserialize<OutboxEnvelope>(envelope.Data);

                if (decodedContent is null) return null;

                return decodedContent;
            }
            catch (Exception ex)
            {
                return null;
            }
        });

        return Ok(resolved);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPendingMessage(string id)
    {
        var message = await service.GetPendingMessageAsync(id);
        return Ok(message);
    }
}