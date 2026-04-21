using Asp.Versioning;
using Cycle.Core.Application.Ports.Handlers;
using Cycle.Core.Application.Schemas.Commands;
using Cycle.Core.Application.Schemas.Queries;
using CycleBike.Core.Domain.Modules.Entities;
using CycleBike.Core.Domain.Modules.Events.Envelopes;
using CycleBike.Core.Domain.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CycleBike.Adapters.WebApi.Controllers.V1;

[Authorize]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiVersion("1.0")]
public class ProductController(
    ICommandHandler<ProductCommands.PublishProduct, object> publishProductHandler,
    ICommandHandler<ProductCommands.CreateProduct, Product> createProductCacheHandler,
    IQueryHandler<ProductQueries.GetPendingMessages, List<OutboxEnvelope?>> getPendingMessagesHandler,
    IQueryHandler<ProductQueries.GetPendingMessage, OutboxEnvelope?> getPendingMessageHandler) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PublishProduct([FromBody] ProductRequest.CreateProduct request)
    {
        var command = new ProductCommands.PublishProduct(request);
        var result = await publishProductHandler.HandleAsync(command, CancellationToken.None);
        return StatusCode(result.StatusCode, result.Data);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductRequest.CreateProduct request)
    {
        var userId = User.FindFirst("sub")?.Value ?? "system";
        var command = new ProductCommands.CreateProduct(request.Name, request.Price, request.Description, userId);
        var result = await createProductCacheHandler.HandleAsync(command, CancellationToken.None);
        return StatusCode(result.StatusCode, result.Data);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPendingMessages()
    {
        var query = new ProductQueries.GetPendingMessages();
        var result = await getPendingMessagesHandler.HandleAsync(query, CancellationToken.None);
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPendingMessage(string id)
    {
        var query = new ProductQueries.GetPendingMessage(id);
        var result = await getPendingMessageHandler.HandleAsync(query, CancellationToken.None);
        return Ok(result);
    }
}
