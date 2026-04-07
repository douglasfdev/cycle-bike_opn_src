using CycleBike.Core.Domain.Enums;

namespace CycleBike.Core.Domain.Requests.Events;

public static class RoutingKey
{
    public static ProductRegistrationStep Step { get; set; } = ProductRegistrationStep.Initial;
}