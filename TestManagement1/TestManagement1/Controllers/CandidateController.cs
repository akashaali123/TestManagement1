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
using TestManagement1.Validation_Filter;
using TestManagement1.ViewModel;

namespace TestManagement1.Controllers
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
       
        public CandidateController(IWebHostEnvironment webHostEnvironment,ICandidate repository, ILogger<CandidatePresenter> logger):base(webHostEnvironment,logger)
        {
            //_webHostEnvironment = webHostEnviroment;
            //_Logger = Logger;
            cp = new CandidatePresenter(webHostEnvironment,repository,logger);
        }



      
       [HttpPost]
       [Route("create")]
        //POST : api/Candidate/create
        
        public IActionResult Add(CandidateViewModel candidate)
        {
            
                if(ModelState.IsValid)
            {
                var data = cp.Add(candidate);
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
        //GET :   api/Candidate/getall
        public IActionResult GetAll()
        {
           if(ModelState.IsValid)
            {
                // return Ok(cp.GetAllCandidate());
                var data = cp.GetAllCandidate();
               
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
       // api/Candidate/Delete
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


       
        
        
        
        
        [HttpPut]
        [Route("update")]
      //PUT:  api/Candidate/update
        public IActionResult Update(CandidateViewModel candidateChanges)
        {
            if (ModelState.IsValid)
            {
                var data = cp.Update(candidateChanges);
               
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