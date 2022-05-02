using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Ef010701_OnboardTrials.DataAccess;

public class CompanyContextFactory : IDesignTimeDbContextFactory<CompanyContext>
{
    public CompanyContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<CompanyContext>()
              .UseSqlServer(CompanyContext.ConnectionString).Options;

        return new CompanyContext(options);
    }
}
