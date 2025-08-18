using Microsoft.EntityFrameworkCore;

namespace ISpire.Infrastructure.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }    
}
