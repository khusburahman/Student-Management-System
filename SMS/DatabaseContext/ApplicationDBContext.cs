using Microsoft.EntityFrameworkCore;
using SMS.Models;

namespace SMS.DatabaseContext;

public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> contextOptions):DbContext(contextOptions)
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
    }

public DbSet<SMS.Models.Student> Student { get; set; } = default!;
}
