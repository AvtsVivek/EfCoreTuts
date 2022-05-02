using SamuraiApp.Data;
namespace SamuraiApp.WebApi
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration config, IWebHostEnvironment env)
        {
            Configuration = config;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            var connectionString = @"Host=localhost;Username=root;Password=root;Database=SamraiTemp";
            services.AddDbContext(connectionString);
        }

        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Onboarding  API V1");
            //    //c.RoutePrefix = "";
            //});

            app.UseSwaggerUI();

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
