using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System.Diagnostics;

namespace SamuraiApp.WebApi
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider) 
        {
            using (var dbContext = 
                new SamuraiContext(
                    serviceProvider.GetRequiredService<DbContextOptions<SamuraiContext>>()))
            {
                try
                {
                    PopulateTestData(dbContext);
                }
                catch (Exception ex)
                {
                    Debugger.Break();
                    Debugger.Log(level: 2, "SeedData", ex.Message);
                    throw;
                }
            }
        }

        public static void PopulateTestData(SamuraiContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            var user = new User("Vivek");
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }
    }
}
