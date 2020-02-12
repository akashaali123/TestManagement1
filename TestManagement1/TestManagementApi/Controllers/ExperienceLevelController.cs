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
                    
                    //MyReturnMethode Return the data in Ok result its implementation in base controller
                    return MyReturnMethode(true, StatusCodes.Status200OK, "ExperienceLevel Created", data);                   
                }
                else
                {
                    // Error Returned
                    
                    //MyReturnMethode Return the data in Ok result its implementation in base controller
                    return MyReturnMethode(false, StatusCodes.Status400BadRequest, "Invalid Attempt", data);
                  
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
               
                //MyReturnMethode Return the data in Ok result its implementation in base controller
                return MyReturnMethode(false, StatusCodes.Status502BadGateway, "Exception Found", data);
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
                if (experience.Count() != 0)
                {
                    // Add the data in the JSON Data field below
                    data.Add("experience", experience);

                    
                    
                    // Return Data 
                    
                    //MyReturnMethode Return the data in Ok result its implementation in base controller
                    return MyReturnMethode(true, StatusCodes.Status200OK, "All Experience Level", data);
                                                                                              
                }
                else
                {
                    // Error Returned
                    
                    //MyReturnMethode Return the data in Ok result its implementation in base controller
                    return MyReturnMethode(false, StatusCodes.Status400BadRequest, "No Record Found", data);                 
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
                
                //MyReturnMethode Return the data in Ok result its implementation in base controller
                return MyReturnMethode(false, StatusCodes.Status502BadGateway, "Exception Found", data);
               
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
                    
                    //MyReturnMethode Return the data in Ok result its implementation in base controller
                    return MyReturnMethode(true, StatusCodes.Status200OK, "Deleted", data);
                }
                else
                {
                    // Error Returned
                   
                    //MyReturnMethode Return the data in Ok result its implementation in base controller
                    return MyReturnMethode(false, StatusCodes.Status400BadRequest, "Invalid Attempt", data);

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
                
                //MyReturnMethode Return the data in Ok result its implementation in base controller
                return MyReturnMethode(false, StatusCodes.Status502BadGateway, "Exception Found", data);
            }
            // Function Ended

        }
        #endregion





       








    }
}