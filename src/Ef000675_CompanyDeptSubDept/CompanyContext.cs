using Microsoft.EntityFrameworkCore;

namespace Ef000675_CompanyDeptSubDept;

public class CompanyContext : DbContext
{
  public CompanyContext(DbContextOptions<CompanyContext> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new CompanyTypeConfiguration());
  }
  public DbSet<Company> Companies { get; set; } = default!;
}
