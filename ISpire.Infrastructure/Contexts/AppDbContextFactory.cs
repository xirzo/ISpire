using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ISpire.Infrastructure.Contexts;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

        if (connectionString == null || string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("Database connection string environment variable (DB_CONNECTION_STRING) is not set.");
        }

        optionsBuilder.UseNpgsql(connectionString);

        return new AppDbContext(optionsBuilder.Options);
    }
}