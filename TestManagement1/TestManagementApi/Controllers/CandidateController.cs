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
    [ApiController]                                  //Pass the ILogger class
    //[Authorize]
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

           
            var model = cp.Add(candidate);
            return helperMethode(model, "candidate");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller

        }
        #endregion



        #region Candidate Get All
        [HttpGet]
        [Route("/candidate/getall")]
        //GET :   api/Candidate/getall
        public IActionResult GetAll()
        {
            
            var candidate = cp.GetAllCandidate();
            return helperMethode(candidate, "candidates");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller

        }
        #endregion







        #region Candidate Delete
        [HttpDelete]
        [Route("/candidate/delete")]
        // api/Candidate/Delete
        public IActionResult Delete(int id)
        {
            
            var candidate = cp.Delete(id);
            return helperMethode(candidate, "candidate");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller
        }
        #endregion






        #region Candidate Update
        [HttpPut]
        [Route("/candidate/update")]
        //PUT:  api/Candidate/update
        public IActionResult Update(CandidateViewModel candidateChanges)
        {
            
            var candidate = cp.Update(candidateChanges);
            return helperMethode(candidate, "candidate");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller

        }
        #endregion



        [HttpPost]
        [Route("/candidate/generatetest")]
        public IActionResult JwtForCandidate(int candidateId,int numberOfQuestion)
        {
            var jwt = cp.JwtForCandidate(candidateId, numberOfQuestion);
            return helperMethode(jwt,"jwttoken");
        }



    }
}