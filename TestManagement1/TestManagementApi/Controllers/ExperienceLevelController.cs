using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestManagement1.Presenter;
using TestManagement1.RepositoryInterface;
using TestManagement1.ViewModel;

namespace TestManagementApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExperienceLevelController : BaseController<ExperienceLevelPresenter>
    {
        //Generic Methode Explanation in Candidate Controller



        ExperienceLevelPresenter exP;

        

        public ExperienceLevelController(IWebHostEnvironment webHostEnvironment, IExperienceLevel repository, ILogger<ExperienceLevelPresenter> logger) : base(webHostEnvironment, logger)
        {
            
            exP = new ExperienceLevelPresenter(webHostEnvironment, repository, logger);

        }



        #region Experience Level Create
        [HttpPost]
        [Route("/experiencelevel/create")]
        //POST : api/ExperienceLevel/create
        public IActionResult Add(ExperienceLevelViewModel experienceLevel)
        {
            try
            {
                // Data Dictionary added as per the standard policy
                Dictionary<string, object> data = new Dictionary<string, object>();

                var experience = exP.Add(experienceLevel);

                if (experience != null)
                {
                    // Add the data in the JSON Data field below
                    data.Add("ExperienceLevel", experience);

                    // Return Data 
                    return Ok(
                    new
                    {
                        success = true,
                        status = StatusCodes.Status200OK,
                        message = "ExperienceLevel Created",
                        data
                    });
                }
                else
                {
                    // Error Returned
                    return Ok(
                    new
                    {
                        success = false,
                        status = StatusCodes.Status400BadRequest,
                        message = "Invalid Attempt",
                        data
                    });
                }
                // Clear

            }
            catch (Exception ex)
            {
                // Exception thrown
                Dictionary<string, object> data = new Dictionary<string, object>();

                // Add the data in the JSON Data field below
                data.Add("exception", ex);

                // Return Exception
                return Ok(
                    new
                    {
                        success = false,
                        status = StatusCodes.Status502BadGateway,
                        message = "Exception Found",
                        data
                    });
            }
            // Function Ended
        }
        #endregion






        #region Experience Level Get All
        [HttpGet]
        [Route("/experiencelevel/getall")]
        //GET : api/ExperienceLevel/getall
        public IActionResult GetAll()
        {
            try
            {
                // Data Dictionary added as per the standard policy
                Dictionary<string, object> data = new Dictionary<string, object>();

                var experience = exP.GetAll();
                if (experience != null)
                {
                    // Add the data in the JSON Data field below
                    data.Add("experience", experience);

                    // Return Data 
                    return Ok(
                    new
                    {
                        success = true,
                        status = StatusCodes.Status200OK,
                        message = "All Users",
                        data
                    });
                }
                else
                {
                    // Error Returned
                    return Ok(
                    new
                    {
                        success = false,
                        status = StatusCodes.Status400BadRequest,
                        message = "Invalid Attempt",
                        data
                    });
                }
                //Clear
            }
            catch (Exception ex)
            {
                // Exception thrown
                Dictionary<string, object> data = new Dictionary<string, object>();

                // Add the data in the JSON Data field below
                data.Add("exception", ex);

                // Return Exception
                return Ok(
                    new
                    {
                        success = false,
                        status = StatusCodes.Status502BadGateway,
                        message = "Exception Found",
                        data
                    });
            }
            //Function Ended
        }
        #endregion





        #region Experience Level Delete
        [HttpDelete]
        [Route("/experiencelevel/delete")]
        //DELETE : api/ExperienceLevel/Delete
        public IActionResult Delete(int id)
        {
            try
            {
                // Data Dictionary added as per the standard policy
                Dictionary<string, object> data = new Dictionary<string, object>();

                var experience = exP.Delete(id);

                if (experience != null)
                {
                    // Add the data in the JSON Data field below
                    data.Add("experience", experience);

                    // Return Data 
                    return Ok(
                    new
                    {
                        success = true,
                        status = StatusCodes.Status200OK,
                        message = "User Created",
                        data
                    });
                }
                else
                {
                    // Error Returned
                    return Ok(
                    new
                    {
                        success = false,
                        status = StatusCodes.Status400BadRequest,
                        message = "Invalid Attempt",
                        data
                    });
                }
                //clear
            }
            catch (Exception ex)
            {
                // Exception thrown
                Dictionary<string, object> data = new Dictionary<string, object>();

                // Add the data in the JSON Data field below
                data.Add("exception", ex);

                // Return Exception
                return Ok(
                    new
                    {
                        success = false,
                        status = StatusCodes.Status502BadGateway,
                        message = "Exception Found",
                        data
                    });
            }
            // Function Ended

        }
        #endregion














    }
}