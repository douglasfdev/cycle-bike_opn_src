using System.Text.Json;
using Asp.Versioning;
using Cycle.Core.Application.Requests;
using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Modules.Events.Envelopes;
using Microsoft.AspNetCore.Mvc;

namespace CycleBike.Adapters.WebApi.Controllers.V1;

[Controller]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiVersion("1.0")]
public class ProductController(ICacheService cacheService, IOutboxService service): ControllerBase
{
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