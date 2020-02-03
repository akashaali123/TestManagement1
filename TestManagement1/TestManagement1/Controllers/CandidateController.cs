using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestManagement1.Model;
using TestManagement1.RepositoryInterface;

namespace TestManagement1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository repository;
        public CandidateController(ICandidateRepository repository)
        {
            this.repository = repository;
        }


       [HttpPost]
       [Route("create")]
        //POST : api/CandidateController/create

        public IActionResult add(TblCandidate candidate)
        {
            if (ModelState.IsValid)
            {
               
                    TblCandidate newCandidate = repository.Add(candidate);

                    return Ok(newCandidate);
                
              
            }
            else
            {
                return BadRequest();
            }
                

        }
       
        
        [HttpGet]
        [Route("getall")]
        //POST : api/CandidateController/getall
        public IActionResult GetAll()
        {
            var result = repository.GetAllCandidate();

            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete")]
       // api/Candidate/Delete
        public IActionResult Delete(int id)
        {
          var result =  repository.Delete(id);
            return Ok(new { message = "Deleted successfully"});
            
        }



    }
}