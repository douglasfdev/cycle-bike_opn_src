using CycleBike.Core.Domain.Modules.Entities;

namespace CycleBike.Core.Domain.Interfaces;

public interface IUserService
{
    Task<User> FindByIdAsync(Ulid id);
}