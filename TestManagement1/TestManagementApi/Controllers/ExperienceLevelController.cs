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
    [Authorize]
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
            
            var experience = exP.Add(experienceLevel);
            return helperMethode(experience, "experience");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller

        }
        #endregion






        #region Experience Level Get All
        [HttpGet]
        [Route("/experiencelevel/getall")]
        //GET : api/ExperienceLevel/getall
        public IActionResult GetAll()
        {
            
            var experience = exP.GetAll();
            return helperMethode(experience, "experiences");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller
        }
        #endregion





        #region Experience Level Delete
        [HttpDelete]
        [Route("/experiencelevel/delete")]
        //DELETE : api/ExperienceLevel/Delete
        public IActionResult Delete(int id)
        {
           
            var experience = exP.Delete(id);
            return helperMethode(experience, "experience");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller

        }
        #endregion














    }
}