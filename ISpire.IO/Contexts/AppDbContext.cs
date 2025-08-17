using Microsoft.EntityFrameworkCore;

namespace ISpire.IO.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }    
}
