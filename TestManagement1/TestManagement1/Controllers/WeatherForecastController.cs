using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestManagementCore.Email_Services;

namespace TestManagement1.Controllers
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

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();

            //var message = new Message(new string[] { "akashaali2012@gmail.com" }, "Test email", "This is the content from our email in CORE project.");
            //_emailSender.SendEmail(message);




            // _logger.LogInformation("Info Logging");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {

                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

        }

        //[HttpGet]
        //public ActionResult<int> Get()
        //{

        //    try
        //    {
        //        int a = 2;
        //        int b = 0;
        //        return a / b;
        //    }
        //    catch (Exception ex)
        //    {

        //        _logger.LogError("Error in Weather Controller" + ex);
        //        return null;

        //    }
        //}


    }
}
