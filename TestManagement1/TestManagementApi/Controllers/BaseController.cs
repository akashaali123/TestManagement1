using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        public BaseController(IWebHostEnvironment webHostEnvironment,
                              ILogger<T> logger)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public OkObjectResult MyReturnMethode(bool success,
                                              int status,
                                              string message,
                                              Dictionary<string, object> data)
        {
            return Ok(new
            {
                success,
                status,
                message,
                data
            });
        }

        
        
        public OkObjectResult helperMethode(object variable,
                                            string dicName)

        {
            try
            {
               
                    // Data Dictionary added as per the standard policy
                    Dictionary<string, object> data = new Dictionary<string, object>();

                    if (variable != null)
                    {
                        // Add the data in the JSON Data field below
                        data.Add(dicName, variable);


                        // Return Data 

                        //MyReturnMethode Return the data in Ok result its implementation in base controller
                        return MyReturnMethode(true, StatusCodes.Status200OK, dicName, data);
                    }
                    else
                    {
                        // Error Returned

                        //MyReturnMethode Return the data in Ok result its implementation in base controller
                        return MyReturnMethode(false, StatusCodes.Status400BadRequest, "Invalid Attempt", data);
                    }
                
               


            }
            catch (Exception ex)
            {

                // Exception thrown
                Dictionary<string, object> data = new Dictionary<string, object>();

                // Add the data in the JSON Data field below
                data.Add("exception", ex);

                // Return Exception

                //MyReturnMethode Return the data in Ok result its implementation in base controller
                return MyReturnMethode(false, StatusCodes.Status502BadGateway, "Exception Found", data);
            }

        }



        //public string GetUserId()
        //{
        //    string userId = User.Claims.FirstOrDefault(c => c.Type == "userid").Value;
        //    return userId;
        //}




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