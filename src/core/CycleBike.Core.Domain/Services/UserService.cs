using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Modules.Entities;

namespace CycleBike.Core.Domain.Services;

public class UserService(IDatabaseGenericRepository<User> repository) : IUserService
{
    public async Task<User> FindByIdAsync(Ulid id)
        => await repository.GetByIdAsync(id) ?? throw new ArgumentNullException(nameof(id));
}