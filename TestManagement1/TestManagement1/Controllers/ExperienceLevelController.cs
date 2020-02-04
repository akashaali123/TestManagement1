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

namespace TestManagement1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceLevelController : ControllerBase
    {
        

        private readonly IWebHostEnvironment _webHostEnvironment;

        ExperienceLevelPresenter exP;

        private readonly ILogger<ExperienceLevelPresenter> _logger;

        public ExperienceLevelController(IWebHostEnvironment webHostEnvironment,IExperienceLevel repository, ILogger<ExperienceLevelPresenter> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
            exP = new ExperienceLevelPresenter(_webHostEnvironment, repository, _logger);


        }



        [HttpPost]
        [Route("create")]
        //POST : api/ExperienceLevel/create
        public IActionResult Add(TblExperienceLevel experienceLevel)
        {
            
            if (ModelState.IsValid)
            {
                return Ok(exP.Add(experienceLevel));
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
                return Ok(exP.GetAll());
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
                return Ok(exP.Delete(id));
            }
            else
            {
                return BadRequest();
            }

        }

   
    
    
    
    
    
    }
}