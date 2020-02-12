using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : class
    {
        protected readonly IWebHostEnvironment _webHostEnvironment;
        protected readonly ILogger<T> _logger;

        public BaseController(IWebHostEnvironment webHostEnvironment, ILogger<T> logger)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public OkObjectResult MyReturnMethode(bool success, int status, string message, Dictionary<string, object> data)
        {
            return Ok(new
            {
                success,
                status,
                message,
                data
            });
        }
        
        
        //Above Function is replica of this return ok


        //return Ok(
        //new
        //{
        //    success = true,
        //    status = StatusCodes.Status200OK,
        //    message = "All Experience",
        //    data
        //});

    }
}