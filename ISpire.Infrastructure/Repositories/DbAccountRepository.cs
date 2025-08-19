using ISpire.Core.Entities;
using ISpire.Core.Repositories;
using ISpire.Infrastructure.Contexts;

namespace ISpire.Infrastructure.Repositories;

public class DbAccountRepository : IAccountRepository
{
    private readonly AppDbContext _dbContext;

    public DbAccountRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Account?> Add(Guid guid, string name, string email, string passwordHash)
    {
        throw new NotImplementedException();
    }

    public Task<Account?> FindByGuid(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<Account?> FindByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<Account?> FindByName(string email)
    {
        throw new NotImplementedException();
    }
}