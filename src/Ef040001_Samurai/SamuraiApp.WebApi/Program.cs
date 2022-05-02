using SamuraiApp.Data;
using System.Diagnostics;

namespace SamuraiApp.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder<Startup>(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<SamuraiContext>();
                    //                    context.Database.Migrate();
                    context.Database.EnsureCreated();
                    SeedData.Initialize(services);
                    // SeedSampleData.Initialize(services);
                }
                catch (Exception ex)
                {
                    Debugger.Break();
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder<TStartup>(string[] args) where TStartup : class
        {
            var builder = WebApplication.CreateBuilder(args);
            //if (autofacServiceProviderFactory == null)
            //    autofacServiceProviderFactory = new AutofacServiceProviderFactory();
            return Host.CreateDefaultBuilder(args)
            // .UseServiceProviderFactory(autofacServiceProviderFactory)
            // https://jkdev.me/asp-net-core-serilog/
            //.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration))
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder
              .UseStartup<TStartup>()
              .ConfigureLogging(logging =>
                    {
                        logging.ClearProviders();
                        logging.AddConsole();
                // logging.AddAzureWebAppDiagnostics(); add this if deploying to Azure
            });
            });
        }

    }


}
