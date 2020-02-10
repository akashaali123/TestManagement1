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
    [ApiController]
    public class ExperienceLevelController : BaseController<ExperienceLevelPresenter>
    {
        //Generic Methode Explanation in Candidate Controller

       

        ExperienceLevelPresenter exP;

        

        public ExperienceLevelController(IWebHostEnvironment webHostEnvironment,IExperienceLevel repository, ILogger<ExperienceLevelPresenter> logger):base(webHostEnvironment,logger)
        {
          
            exP = new ExperienceLevelPresenter(webHostEnvironment, repository, logger);

        }



        [HttpPost]
        [Route("create")]
        //POST : api/ExperienceLevel/create
        public IActionResult Add(ExperienceLevelViewModel experienceLevel)
        {
            
            if (ModelState.IsValid)
            {
                var data = exP.Add(experienceLevel);

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
        //GET : api/ExperienceLevel/getall
        public IActionResult GetAll()
        {
           
            if(ModelState.IsValid)
            {
                var data = exP.GetAll();
                
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
        //DELETE : api/ExperienceLevel/Delete
        public IActionResult Delete(int id)
        {
           

            if (ModelState.IsValid)
            {
                var data = exP.Delete(id);
               
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