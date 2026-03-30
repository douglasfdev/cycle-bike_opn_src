using MongoDB.Bson;

namespace CycleBike.Core.Domain.Modules.Events.Envelopes;

public class OutboxEnvelope : BaseEntityBson
{
    public OutboxEnvelope()
    {
        Id = ObjectId.GenerateNewId().ToString(); // gerado aqui
    }

    
    public byte[] Data { get; set; } = null!;
}