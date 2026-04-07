using CycleBike.Core.Common.Interfaces;
using CycleBike.Core.Common.MessageBroker;

namespace CycleBike.Core.Domain.Interfaces;

public interface IOutboxEnvelope : IRoutableMessage
{
}
