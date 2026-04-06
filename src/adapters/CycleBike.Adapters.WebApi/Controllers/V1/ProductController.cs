using System.Text.Json;
using Asp.Versioning;
using Cycle.Core.Application.Abstractions.Handlers;
using Cycle.Core.Application.Modules.Product;
using Cycle.Core.Application.Ports.Handlers;
using Cycle.Core.Application.Responses;
using Cycle.Core.Application.Schemas.Commands;
using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Modules.Events.Envelopes;
using CycleBike.Core.Domain.Requests;
using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace CycleBike.Adapters.WebApi.Controllers.V1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiVersion("1.0")]
public class ProductController(CommandHandler<ProductCommands.CreateProduct, ApiResult<Core.Domain.Modules.Entities.Product>> handler, IMessagePublisher bus, ICacheService cacheService, IOutboxService service): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PublishProduct([FromBody] ProductRequest.CreateProduct request)
    {
        var envelope = await service.EnqueueAsync(request);
        await bus.PublishAsync(envelope, "ProductRequests", "Initial");
        return Accepted(new { message = "Produto sendo processado" });
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductRequest.CreateProduct request)
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