using CycleBike.Core.Domain.Entities.Extensions;

namespace CycleBike.Core.Domain.Entities;

public record NotificationMessage(bool Ok, string? Source, string? Message) : BaseEntity;
