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
    [ApiController]
    public class CategoryController : BaseController<CategoryPresenter>
    {

        //webHostEnviroment Declaration but not used I used for furture configuration it provides the property such
        //as webRootPath webRootFile Provider

        //Generic Methode Description in Candidate Controller
        CategoryPresenter cp;
        

        public CategoryController(IWebHostEnvironment webHostEnvironment, ICategory repository, ILogger<CategoryPresenter> logger) : base(webHostEnvironment, logger)
        {
            
            cp = new CategoryPresenter(webHostEnvironment, repository, logger);
        }


        #region Category Create
        [HttpPost]
        [Route("/category/create")]
        //POST : api/Category/create
        public IActionResult Add(CategoryViewModel category)
        {
            try
            {
                // Data Dictionary added as per the standard policy
                Dictionary<string, object> data = new Dictionary<string, object>();

                var model = cp.Add(category);

                if (model != null)
                {
                    // Add the data in the JSON Data field below
                    data.Add("category", model);

                    // Return Data 
                    return Ok(
                    new
                    {
                        success = true,
                        status = StatusCodes.Status200OK,
                        message = "Category Created",
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



        #region Category get all
        [HttpGet]
        [Route("/category/getall")]
        //GET : api/Category/getall
        public IActionResult GetAll()
        {
            try
            {
                // Data Dictionary added as per the standard policy
                Dictionary<string, object> data = new Dictionary<string, object>();

                var category = cp.GetAllCategory();

                if (category != null)
                {
                    // Add the data in the JSON Data field below
                    data.Add("category", category);

                    // Return Data 
                    return Ok(
                    new
                    {
                        success = true,
                        status = StatusCodes.Status200OK,
                        message = "All Category",
                        data
                    });
                }
                else
                {
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
            //Fuction Ended
        }
        #endregion




        #region Category Delete
        [HttpDelete]
        [Route("/category/delete")]
        //DELETE : api/Category/Delete
        public IActionResult Delete(int id)
        {

            try
            {
                // Data Dictionary added as per the standard policy
                Dictionary<string, object> data = new Dictionary<string, object>();

                var category = cp.Delete(id);
                if (category != null)
                {
                    // Add the data in the JSON Data field below
                    data.Add("category", category);

                    // Return Data 
                    return Ok(
                    new
                    {
                        success = true,
                        status = StatusCodes.Status200OK,
                        message = "Category Deleted",
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







    }
}