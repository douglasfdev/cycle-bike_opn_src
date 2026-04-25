using System.Text.Json;
using CycleBike.Core.Domain.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace CycleBike.Adapters.LoggerGateway.Controllers;

[ApiController]
[Route("api/logs")]
public class LogController : ControllerBase
{
    private readonly ILogger<LogController> _logger;
    private readonly IMessageProducer _messageProducer;

    public LogController(ILogger<LogController> logger, IMessageProducer messageProducer)
    {
        _logger = logger;
        _messageProducer = messageProducer;
    }

    [HttpPost]
    public async Task<IActionResult> PostLogs([FromBody] JsonElement logsElement)
    {
        try
        {
            var logs = JsonSerializer.Deserialize<List<LogEntry>>(logsElement.GetRawText());
            if (logs == null || !logs.Any())
            {
                return BadRequest("No logs provided");
            }

            await _messageProducer.PublishAsync("logs.queue", logs);
            
            _logger.LogInformation("Processed {Count} logs", logs.Count);
            return Ok(new { Processed = logs.Count });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing logs");
            return StatusCode(500, "Internal server error");
        }
    }
}