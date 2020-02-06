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
    public class CandidateController : ControllerBase
    {
       

        private readonly IWebHostEnvironment webHostEnvironment;
       
        CandidatePresenter cp;
        
        private readonly ILogger<CandidatePresenter> _logger;
       
        public CandidateController(IWebHostEnvironment webHostEnvironment,ICandidateRepository repository, ILogger<CandidatePresenter> logger)
        {
            _logger = logger;
            this.webHostEnvironment = webHostEnvironment;
            cp = new CandidatePresenter(this.webHostEnvironment,repository,_logger);
        }


       
        
       [HttpPost]
       [Route("create")]
        //POST : api/Candidate/create
        
        public IActionResult add(CandidateViewModel candidate)
        {
            if (ModelState.IsValid)
            {
                return Ok(cp.Add(candidate));
            }
            else
            {
                return BadRequest();
            }
        }
       
        
       
        
        
        [HttpGet]
        [Route("getall")]
        //POST :  
        public IActionResult GetAll()
        {
           if(ModelState.IsValid)
            {
                return Ok(cp.GetAllCandidate());
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
                var result = cp.Delete(id);
                return Ok(result);
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
                return Ok(cp.Update(candidateChanges));
            }
            else
            {
                return BadRequest();
            }

        }

        //[HttpGet]
        //[Route("getallcandidate")]
        //public JsonResult update()
        //{
        //    return new JsonResult(cp.GetAllCandidate());
        //}
    
    
    }
}