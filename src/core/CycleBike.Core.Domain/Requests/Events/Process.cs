using CycleBike.Core.Domain.Enums;

namespace CycleBike.Core.Domain.Requests.Events;

public static class Process
{
    public static ProductProcess ProductProcess { get; set; } = ProductProcess.ProductRegistration;
}