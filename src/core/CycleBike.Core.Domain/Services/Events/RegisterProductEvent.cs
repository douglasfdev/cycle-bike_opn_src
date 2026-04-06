using System.Text;
using System.Text.Json;
using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Modules.Entities;
using CycleBike.Core.Domain.Modules.Events.Envelopes;
using CycleBike.Core.Domain.Requests;

namespace CycleBike.Core.Domain.Services.Events;

public class RegisterProductEvent<T>(INoSQLRepository<OutboxEnvelope> outboxRepository, IDatabaseWriteRepository<Product> productRepository): IConsumerStrategy<T> where T : class, IOutboxEnvelope
{
    public async Task HandleAsync(T message)
    {
        var res = await outboxRepository.GetByIdAsync(message.Id);
        if (res is null) return;

        if (res.Data is null) return;

        var product = JsonSerializer.Deserialize<ProductRequest.CreateProduct>(Encoding.UTF8.GetString(res.Data));
        if (product is null) return;

        var newProduct = new Product(product.Name, product.Price, product.Description);
        
        await productRepository.AddAsync(newProduct);
        await productRepository.CommitAsync();
    }
}