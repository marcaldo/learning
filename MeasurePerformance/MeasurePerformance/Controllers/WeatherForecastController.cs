using MethodTimer;
using Microsoft.AspNetCore.Mvc;

namespace MeasurePerformance.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /*
         *  Using MethodTimer.Fody package: https://github.com/Fody/MethodTimer 
         *  [Time] Logs TimeSpan duration in the MethodTimerLogger method.
         *  Default LogLevel in appsettings must be "Trace".
         *  See video https://www.youtube.com/watch?v=xlqcT4NSrZw
         */

        [HttpGet]
        [Time]
        //[Time("Retrieved weather for {days} days.")]
        public async Task<IEnumerable<WeatherForecast>> Get([FromQuery] int days = 5)
        {
            await Task.Delay(Random.Shared.Next(5, 30));

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}