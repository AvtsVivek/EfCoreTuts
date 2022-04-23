using Microsoft.AspNetCore.Mvc;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace SamuraiApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SamuraiController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
          "Freezing", "Bracing", "Chilly", "Cool", "Mild",
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        SamuraiContext _context = new SamuraiContext();
        public SamuraiController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetSamurai")]
        //[HttpGet("[action]")]
        public IActionResult Get()
        {
            _context.Database.EnsureCreated();

            var samurais = _context.Samurais.ToList();

            return Ok(samurais);
        }

        [HttpGet("[action]", Name = "GetSamuraiCount")]
        public IActionResult GetSamuraiCount()
        {
            _context.Database.EnsureCreated();

            var samuraisCount = _context.Samurais.Count();

            return Ok(samuraisCount);
        }

        [HttpPost("AddSamurai/{name}")]
        public async Task<IActionResult> AddSamurai(string name)
        {
            _context.Database.EnsureCreated();
            
            var samurai = new Samurai { Name = name };
            
            await _context.Samurais.AddAsync(samurai);
            
            _context.SaveChanges();
            
            return Ok();
        }
    }
}
