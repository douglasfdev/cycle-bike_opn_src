using CycleBike.Core.Domain.Modules.Entities.Extensions;

namespace CycleBike.Core.Domain.Modules.Entities;

public class Account : BaseEntity
{
    public Profile Profile { get; set; }
}