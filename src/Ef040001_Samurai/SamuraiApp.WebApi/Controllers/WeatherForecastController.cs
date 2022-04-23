using Microsoft.AspNetCore.Mvc;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace SamuraiApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
          "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        SamuraiContext _context = new SamuraiContext();
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            

            _context.Database.EnsureCreated();

          GetSamurais("Before Add:");
          AddSamurai();
          GetSamurais("After Add:");
          Console.Write("Press any key...");


      return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

    private void AddSamurai()
    {
      var samurai = new Samurai { Name = "Julie" };
      _context.Samurais.Add(samurai);
      _context.SaveChanges();
    }
    private void GetSamurais(string text)
    {
      var samurais = _context.Samurais.ToList();
      Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
      foreach (var samurai in samurais)
      {
        Console.WriteLine(samurai.Name);
      }
    }
  }
}
