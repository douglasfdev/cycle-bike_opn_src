using CycleBike.Core.Domain.Modules.Events.Envelopes;

namespace CycleBike.Adapters.GraphQL.Types;

public class OutboxEnvelopeType : ObjectType<OutboxEnvelope>
{
    protected override void Configure(IObjectTypeDescriptor<OutboxEnvelope> descriptor)
    {
        descriptor.Name("OutboxEnvelope");

        descriptor.Field(f => f.Id).Type<NonNullType<StringType>>().Description("Identificador da mensagem");
        descriptor.Field(f => f.MessageType).Type<StringType>().Description("Tipo da mensagem");
        descriptor.Field(f => f.Sent).Type<BooleanType>().Description("Indica se a mensagem foi enviada");
        descriptor.Field(f => f.SentAt).Type<DateTimeType>().Description("Data de envio");
        descriptor.Field(f => f.Attempts).Type<IntType>().Description("Número de tentativas de envio");
        descriptor.Field(f => f.LastAttempt).Type<DateTimeType>().Description("Data da última tentativa");
        descriptor.Field(f => f.Status).Type<StringType>().Description("Status da mensagem");
        descriptor.Field(f => f.CreatedAt).Type<DateTimeType>().Description("Data de criação");
    }
}
