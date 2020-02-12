using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    [ApiController]                                  //Pass the ILogger class
    public class CandidateController : BaseController<CandidatePresenter> //generic methode implement for Logger and WebHostEnviroment
    {
        //When we need to implement WebHostEnviroment and Logger so Inherit from base controller in which
        //we initialize and injected the logger and WebHostEnviroment so we get rid of duplication of code 
        //if we did'nt do this so we fix it manually in all controller as we comment it

        //private readonly ILogger<CandidatePresenter> _logger;
        //private readonly IWebHostEnvironment _webHostEnvironment;

        CandidatePresenter cp;
        

        public CandidateController(IWebHostEnvironment webHostEnvironment, ICandidate repository, ILogger<CandidatePresenter> logger) : base(webHostEnvironment, logger)
        {
            //_webHostEnvironment = webHostEnviroment;
            //_Logger = Logger;
          
            cp = new CandidatePresenter(webHostEnvironment, repository, logger);
        }


        #region Candidate Create
        // [ModelStateValidationFilter]
        [HttpPost]
        [Route("/candidate/create")]
        //POST : api/Candidate/create
        public IActionResult Add(CandidateViewModel candidate)
        {

            try
            {
                // Data Dictionary added as per the standard policy
                Dictionary<string, object> data = new Dictionary<string, object>();

                var model = cp.Add(candidate);
                if (model != null)
                {
                    // Add the data in the JSON Data field below
                    data.Add("candidate", model);

                    // Return Data 
                    
                    //MyReturnMethode Return the data in Ok result its implementation in base controller
                    return MyReturnMethode(true, StatusCodes.Status200OK, "Candidate Created", data);
                }
                else
                {
                    // Error Returned
                   
                    //MyReturnMethode Return the data in Ok result its implementation in base controller
                    return MyReturnMethode(false, StatusCodes.Status400BadRequest, "Invalid Attempt", data);
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



        #region Candidate Get All
        [HttpGet]
        [Route("/candidate/getall")]
        //GET :   api/Candidate/getall
        public IActionResult GetAll()
        {
            try
            {
                // Data Dictionary added as per the standard policy
                Dictionary<string, object> data = new Dictionary<string, object>();

                var candidate = cp.GetAllCandidate();
                if (candidate != null)
                {
                    // Add the data in the JSON Data field below
                    data.Add("candidate", candidate);

                    // Return Data 
                    
                    //MyReturnMethode Return the data in Ok result its implementation in base controller
                    return MyReturnMethode(true, StatusCodes.Status200OK, "All Candidate", data);


                }
                else
                {
                    // Error Returned
                    
                    //MyReturnMethode Return the data in Ok result its implementation in base controller
                    return MyReturnMethode(false, StatusCodes.Status400BadRequest, "Invalid Attempt", data);
                }
                //Clear
            }
            catch (Exception ex)
            {
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







        #region Candidate Delete
        [HttpDelete]
        [Route("/candidate/delete")]
        // api/Candidate/Delete
        public IActionResult Delete(int id)
        {
            try
            {
                // Data Dictionary added as per the standard policy
                Dictionary<string, object> data = new Dictionary<string, object>();

                var candidate = cp.Delete(id);
                if (candidate != null)
                {
                    // Add the data in the JSON Data field below
                    data.Add("candidate", candidate);

                    // Return Data 
                    
                    //MyReturnMethode Return the data in Ok result its implementation in base controller
                    return MyReturnMethode(true, StatusCodes.Status200OK, "Candidate Delete", data);
                }
                else
                {
                    // Error Returned
                   
                    //MyReturnMethode Return the data in Ok result its implementation in base controller
                    return MyReturnMethode(false, StatusCodes.Status400BadRequest, "Invalid Attempt", data);
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






        #region Candidate Update
        [HttpPut]
        [Route("/candidate/update")]
        //PUT:  api/Candidate/update
        public IActionResult Update(CandidateViewModel candidateChanges)
        {
            try
            {
                // Data Dictionary added as per the standard policy
                Dictionary<string, object> data = new Dictionary<string, object>();
                var candidate = cp.Update(candidateChanges);

                if (candidate != null)
                {
                    // Add the data in the JSON Data field below
                    data.Add("candidate", candidate);

                    // Return Data 
                    
                    //MyReturnMethode Return the data in Ok result its implementation in base controller
                    return MyReturnMethode(true, StatusCodes.Status200OK, "Canidate Updated", data);

                }
                else
                {
                    // Error Returned
                    
                    //MyReturnMethode Return the data in Ok result its implementation in base controller
                    return MyReturnMethode(false, StatusCodes.Status400BadRequest, "Invalid Attempt", data);

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







    }
}