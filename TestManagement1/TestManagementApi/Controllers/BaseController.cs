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
    }
}