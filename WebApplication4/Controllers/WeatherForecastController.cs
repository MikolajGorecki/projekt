using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] imie = new[]
        {
            "Damian", "Anna", "Filip", "Pola", "Adrian", "Maria", "Teofil", "Cyprian", "Weronika", "Justyna"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            int i = 1;
            return Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Pracownik = imie[Random.Shared.Next(imie.Length)],
                ID = i++
            })
            .ToArray();
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] WeatherForecast forecast)
        {
            return Ok(new { message = "dodany pracownik", data = forecast });
        }
    }
}
