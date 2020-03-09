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

        

        public ExperienceLevelController(IWebHostEnvironment webHostEnvironment,
                                         IExperienceLevel repository, 
                                         ILogger<ExperienceLevelPresenter> logger) : base(webHostEnvironment, logger)
        {
            
            exP = new ExperienceLevelPresenter(webHostEnvironment, repository, logger);

        }


        /// <summary>
        /// url : http://localhost:55377/experiencelevel/create
        /// 
        /// Body
        /// {
        ///"Name": "Senior",
        ///"MinExp": 4,
        /// MaxExp": 6
        /// }
        /// </summary>
        /// <param name="experienceLevel"></param>
        /// <returns>
        /// {
        ///"success": true,
        ///"status": 200,
        ///"message": "experience",
        ///"data": {
        ///"experience": {
        ///"id": 26,
        ///"name": "Senior",
        ///"minExp": 4,
        ///"maxExp": 6,
        ///"isActive": true,
        ///"createdBy": null,
        ///"createdDate": "2020-02-25T00:00:00+05:00",
        ///"updatedBy": null,
        ///"updatedDate": null
        ///  }
        /// }
        ///}
        /// </returns>
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




        /// <summary>
        /// url : http://localhost:55377/experiencelevel/getall
        /// </summary>
        /// <returns>
        /// {
        ///"success": true,
        ///"status": 200,
        ///"message": "experiences",
        ///"data": {
        ///"experiences": [
        ///{
        ///"id": 21,
        ///"name": "Intern PHP",
        ///"minExp": 0,
        ///"maxExp": 1,
        ///"isActive": true,
        ///"createdBy": "37476ed8-c025-478c-a1b0-5b6987f0fbce",
        ///"createdDate": "2020-02-19T18:28:51.5230734",
        ///"updatedBy": null,
        ///"updatedDate": null
        ///}
        ///]
        ///}
        ///}
        /// </returns>

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




        /// <summary>
        /// url : http://localhost:55377/experiencelevel/delete?id=26
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// {
        ///"success": true,
        ///"status": 200,
        ///"message": "experience",
        ///"data": {
        ///"experience": {
        ///"id": 26,
        ///"name": "Senior",
        ///"minExp": 4,
        ///"maxExp": 6,
        ///"isActive": true,
        ///"createdBy": null,
        ///"createdDate": "2020-02-25T00:00:00",
        ///"updatedBy": null,
        ///"updatedDate": null
        ///}
        ///}
        ///}
        /// </returns>
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


        [HttpPut]
        [Route("/experiencelevel/update")]
        //DELETE : api/ExperienceLevel/Delete
        public IActionResult Update(ExperienceLevelViewModel experienceLevelModel, int id)
        {

            var experience = exP.Update(experienceLevelModel,id);
            return helperMethode(experience, "experience");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller

        }



        [HttpGet]
        [Route("/experiencelevel/getbyid")]
        //DELETE : api/ExperienceLevel/Delete
        public IActionResult GetById(int id)
        {

            var experience = exP.GetById(id);
            return helperMethode(experience, "experience");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller

        }







    }
}