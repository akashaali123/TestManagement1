using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestManagement1;
using TestManagementCore;

namespace TestManagementCore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class weatherforecast2Controller : ControllerBase
    {

        private static readonly string[] Summaries = new[]
           {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<weatherforecast2Controller> _logger;



        public weatherforecast2Controller(ILogger<weatherforecast2Controller> logger)
        {
            _logger = logger;

        }

        [HttpGet]
        public IEnumerable<WeatherForecast2> Get()
        {
            var rng = new Random();

            //var message = new Message(new string[] { "akashaali2012@gmail.com" }, "Test email", "This is the content from our email in API project.");
            //_emailSender.SendEmail(message);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast2
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}

public class WeatherForecast2
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string Summary { get; set; }
}