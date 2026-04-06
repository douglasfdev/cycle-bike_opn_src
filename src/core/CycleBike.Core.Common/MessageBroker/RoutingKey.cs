namespace CycleBike.Core.Common.MessageBroker;

/// <summary>
/// Enum que representa as routing keys definidas nos appsettings.
/// Cada valor corresponde a uma fila específica no MessageBroker.
/// </summary>
public enum RoutingKey
{
    // Payment process
    InitialPayment,
    PaymentProcessed,
    PaymentFailed,
    PaymentRefunded,
    
    // ProductRequests process
    Initial,
    ProductValidated,
    ProductRejected,
    ProductApproved
}

/// <summary>
/// Extensões para facilitar a conversão entre RoutingKey e string
/// </summary>
public static class RoutingKeyExtensions
{
    public static string ToRoutingKeyString(this RoutingKey routingKey)
        => routingKey.ToString();
    
    public static bool EqualsRoutingKey(this RoutingKey routingKey, string value)
        => routingKey.ToString().Equals(value, StringComparison.InvariantCultureIgnoreCase);
}
