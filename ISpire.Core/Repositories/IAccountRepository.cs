using ISpire.Core.Entities;

namespace ISpire.Core.Repositories;

public interface IAccountRepository
{
    Task<Account?> Add(string name, string email, string passwordHash);
    Task<Account?> FindByGuid(Guid guid);
    Task<Account?> FindByEmail(string email);
    Task<Account?> FindByName(string name);
    Task<ICollection<string>?> GetPermissionsByGuid(Guid guid);
}