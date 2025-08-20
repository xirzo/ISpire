using ISpire.Core.Entities;
using ISpire.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ISpire.Infrastructure.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}