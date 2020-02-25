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




        /// <summary>
        /// url : http://localhost:55377/candidate/create
        /// 
        /// Body
        /// {
        ///"FirstName":"aaaaaa",
        ///"LastName":"bbbbb",
        ///"Email":"aa@gmail.com",
        ///"CurrentCompany":"aaaa",
        ///"categoryId":22,
        ///"ExperienceLevelId":21
        ///}  
        /// </summary>
        /// <param name="candidate">CandidateViewModel</param>
        /// <returns>
        /// {
        /// "success": true,
        ///"status": 200,
        ///"message": "candidate",
        ///"data": {
        /// "candidate": {
        ///  "candidateId": 50,
        ///"firstName": "aaaaaa",
        ///"lastName": "bbbbb",
        ///"email": "aa@gmail.com",
        ///"currentCompany": "aaaa",
        ///"techStack": null,
        ///"isActive": true,
        ///"vacancyId": null,
        ///"createdBy": null,
        ///"createdDate": "2020-02-25T00:00:00+05:00",
        ///"experienceLevelId": 21,
        ///"categoryId": 22
        ///}
        ///}
        ///}
        /// </returns>


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

        /// <summary>
        /// url: http://localhost:55377/candidate/getall
        /// </summary>
        /// <returns>
        /// {
        ///"success": true,
        ///"status": 200,
        ///"message": "candidates",
        ///"data": {
        ///"candidates": [
        /// {
        ///  "candidateId": 45,
        ///"firstName": "Akasha ",
        ///"lastName": "Nasir",
        ///"email": "akashanasir@gmail.com",
        ///"currentCompany": "Arpatech",
        ///"techStack": null,
        ///"isActive": true,
        ///"vacancyId": null,
        ///"createdBy": null,
        ///"createdDate": "2020-02-24T00:00:00",
        ///"experienceLevelId": 21,
        ///"categoryId": 19
        ///}
        ///]
        ///}
        ///}
        /// </returns>

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





        /// <summary>
        /// url : http://localhost:55377/candidate/delete?id=50
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// {
        ///"success": true,
        ///"status": 200,
        ///"message": "candidate",
        ///"data": {
        /// "candidate": {
        ///  "candidateId": 50,
        ///"firstName": "aaaaaa",
        ///"lastName": "bbbbb",
        ///"email": "aa@gmail.com",
        ///"currentCompany": "aaaa",
        ///"techStack": null,
        ///"isActive": true,
        ///"vacancyId": null,
        ///"createdBy": null,
        ///"createdDate": "2020-02-25T00:00:00",
        ///"experienceLevelId": 21,
        ///"categoryId": 22
        ///}
        ///}
        ///}
        /// </returns>

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




        /// <summary>
        /// url: http://localhost:55377/candidate/update
        /// Body:
        /// {
        ///"CandidateId":41,
        ///"FirstName":"aaaaaa",
        ///"LastName":"bbbbb",
        ///"Email":"aa@gmail.com",
        ///"CurrentCompany":"aaaa",
        ///"categoryId":20,
        ///"experienceLevelId":21
        ///}
        /// </summary>
        /// <param name="candidateChanges"></param>
        /// <returns>
        ///{
        ///"CandidateId":41,
        ///"FirstName":"aaaaaa",
        ///"LastName":"bbbbb",
        ///"Email":"aa@gmail.com",
        ///"CurrentCompany":"aaaa",
        ///"categoryId":20,
        ///"experienceLevelId":21
        ///}
        /// </returns>

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


        /// <summary>
        /// Url : http://localhost:55377/candidate/generatetest?candidateId=45&numberOfQuestion=1
        /// 
        /// 
        /// </summary>
        /// <param name="candidateId"></param>
        /// <param name="numberOfQuestion"></param>
        /// <returns>
        /// {
        ///"success": true,
        ///"status": 200,
        ///"message": "jwttoken",
        ///"data": {
        /// "jwttoken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyb2xlIjoiY2FuZGlkYXRlIiwiY2FuZGlkYXRlaWQiOiI0NSIsIm51bWJlciI6IjEiLCJuYmYiOjE1ODI2MDQ3MDIsImV4cCI6MTU4MjYyMjcwMiwiaWF0IjoxNTgyNjA0NzAyfQ.umslX50cMEkNscJCsG_5uBhoXmvocHWYERFG8YSMyyY"
        ///}
        ///}
        /// </returns>
        [HttpPost]
        [Route("/candidate/generatetest")]
        public IActionResult JwtForCandidate(int candidateId,int numberOfQuestion)
        {
            var jwt = cp.JwtForCandidate(candidateId, numberOfQuestion);
            return helperMethode(jwt,"jwttoken");
        }



    }
}