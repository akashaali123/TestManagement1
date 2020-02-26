using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestManagementCore.Email_Services;

namespace TestManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecast1Controller : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecast1Controller> _logger;

        

        public WeatherForecast1Controller(ILogger<WeatherForecast1Controller> logger)
        {
            _logger = logger;
            
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();

            //var message = new Message(new string[] { "akashaali2012@gmail.com" }, "Test email", "This is the content from our email in API project.");
            //_emailSender.SendEmail(message);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
