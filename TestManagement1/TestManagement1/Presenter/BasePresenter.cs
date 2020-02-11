using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace TestManagement1.Presenter
{
    public class BasePresenter<T> where T : class
    {

        protected readonly IWebHostEnvironment _env;
        
        protected  readonly ILogger<T> _logger;

      //protected ILogger<T> Logger => _logger ?? (_logger = HttpContext? .RequestServices.GetService<ILogger<T>>());
        public BasePresenter(IWebHostEnvironment env, ILogger<T> logger)
        {
             _env = env;
             _logger = logger;
        }
    }
}
