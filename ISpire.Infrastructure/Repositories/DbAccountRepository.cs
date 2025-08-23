using ISpire.Core.Entities;
using ISpire.Core.Repositories;
using ISpire.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ISpire.Infrastructure.Repositories;

public class DbAccountRepository : IAccountRepository
{
    private readonly AppDbContext _dbContext;

    public DbAccountRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Account?> Add(string name, string email, string passwordHash)
    {
        var account = new Account
        {
            Guid = Guid.NewGuid(),
            Name = name,
            Email = email,
            PasswordHash = passwordHash,
            AccountPermissions = [],
        };
        
        await _dbContext.Accounts.AddAsync(account);

        try
        {
            await _dbContext.SaveChangesAsync();
            return account;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<Account?> FindByGuid(Guid guid)
    {
        return await _dbContext.Accounts.FirstOrDefaultAsync(account => account.Guid == guid);
    }

    public async Task<Account?> FindByEmail(string email)
    {
        return await _dbContext.Accounts.FirstOrDefaultAsync(account => account.Email == email);
    }

    public async Task<Account?> FindByName(string name)
    {
        return await _dbContext.Accounts.FirstOrDefaultAsync(account => account.Name == name);
    }

    public async Task<ICollection<string>?> GetPermissionsByGuid(Guid guid)
    {
        var account = await _dbContext.Accounts
            .Include(a => a.AccountPermissions)
            .FirstOrDefaultAsync(account => account.Guid == guid);

        if (account == null)
        {
            return null;
        }
        
        return account.AccountPermissions
            .Select(p => p.PermissionName)
            .ToList();
    }
}