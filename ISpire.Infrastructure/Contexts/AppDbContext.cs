using ISpire.Core.Entities;
using ISpire.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ISpire.Infrastructure.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Subject> Subjects{ get; set; }
    public DbSet<Topic> Topics{ get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new SubjectConfiguration());
        modelBuilder.ApplyConfiguration(new TopicConfiguration());
        modelBuilder.ApplyConfiguration(new AccountPermissionConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}