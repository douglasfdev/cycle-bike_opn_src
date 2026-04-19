using System.Text;
using System.Text.Json;
using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Modules.Entities;
using CycleBike.Core.Domain.Modules.Events.Envelopes;
using CycleBike.Core.Domain.Requests;
using Microsoft.Extensions.Logging;

namespace CycleBike.Core.Domain.Services.Events;

public class RegisterProductEvent<T>(ILogger<RegisterProductEvent<T>> _logger, INoSQLRepository<OutboxEnvelope> outboxRepository, IDatabaseWriteRepository<Product> productRepository): IConsumerStrategy<T> where T : class, IOutboxEnvelope
{
    public async Task HandleAsync(T message)
    {
        var res = await outboxRepository.GetByIdAsync(message.Id);
        if (res is null)
        {
            _logger.LogWarning("Not found envelope, [OUTBOX RELAY] Received event: Id={Id}, Type={Type}, OccurredAt={OccurredAt}",
                message.Id, message.MessageType, message.CreatedAt);
            return;
        };

        if (res.Data is null)
        {
            _logger.LogWarning("Not found data, [OUTBOX RELAY] Received event: Id={Id}, Type={Type}, OccurredAt={OccurredAt}",
                message.Id, message.MessageType, message.CreatedAt);
            return;
        };

        var product = JsonSerializer.Deserialize<ProductRequest.CreateProduct>(Encoding.UTF8.GetString(res.Data));
        if (product is null) return;

        if (!string.IsNullOrEmpty(product.CreatedBy))
        {
            var newProduct = Product.Create(product.Name, product.Price, product.Description, product.CreatedBy);
            await productRepository.AddAsync(newProduct);
            await productRepository.CommitAsync();
            res.Status = "Registered";
            res.SentAt = DateTime.UtcNow;
            await outboxRepository.UpdateAsync(res.Id,res);
            
            _logger.LogInformation("Product registered, [OUTBOX RELAY] Received event: Id={Id}, Type={Type}, OccurredAt={OccurredAt}",
                message.Id, message.MessageType, message.CreatedAt);
        }
        
        _logger.LogWarning("Not registered");
    }
}