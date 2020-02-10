using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestManagement1.Model;
using TestManagement1.Presenter;
using TestManagement1.RepositoryInterface;
using TestManagement1.ViewModel;

namespace TestManagement1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]                                  //Pass the logger class
    public class CategoryController : BaseController<CategoryPresenter>
    {
       
        //webHostEnviroment Declaration but not used I used for furture configuration it provides the property such
        //as webRootPath webRootFile Provider
       
        //Generic Methode Description in Candidate Controller
        CategoryPresenter cp;

        

        public CategoryController(IWebHostEnvironment webHostEnvironment,ICategory repository, ILogger<CategoryPresenter> logger):base(webHostEnvironment,logger)
        {
           
            cp = new CategoryPresenter(webHostEnvironment, repository, logger);
        }

        
        
        
        [HttpPost]
        [Route("create")]
        //POST : api/Category/create

        public IActionResult Add(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var data = cp.Add(category);

                int status = StatusCodes.Status201Created;
                bool success = true;
                return Ok(new { success, status, message = "SuccessFull", data });
                
            }
            else
            {
                return BadRequest();
            }
        }

        
        
        
        [HttpGet]
        [Route("getall")]
        //GET : api/Category/getall
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                var data = cp.GetAllCategory();

                int status = StatusCodes.Status200OK;
                bool success = true;
                return Ok(new { success, status, message = "SuccessFull", data });
                
            }
            else
            {
                return BadRequest();
            }
        }

        
        
        [HttpDelete]
        [Route("Delete")]
        //DELETE : api/Category/Delete
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var data = cp.Delete(id);
                
                int status = StatusCodes.Status200OK;
                bool success = true;
                return Ok(new { success, status, message = "SuccessFull", data });
            }
            else
            {
                return BadRequest();
            }
        }


    }
}