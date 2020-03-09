using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestManagementCore.Presenter;
using TestManagementCore.RepositoryInterface;

namespace TestManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TestResultController : BaseController<TestResultPresenter>
    {
        TestResultPresenter testResultPresenter;

        public TestResultController(IWebHostEnvironment webHostEnvironment,
                                    ITestResult repository,
                                    ILogger<TestResultPresenter> logger) : base(webHostEnvironment, logger)
        {
            testResultPresenter = new TestResultPresenter(webHostEnvironment, repository, logger); ;
        }


        #region Add Record
        /// <summary>
        ///Url : http://localhost:55377/test/add?candidateId=44 
        /// </summary>
        /// <param name="candidateId"></param>
        /// <returns>
        /// True
        /// </returns>
        [HttpPost]
        [Route("/test/add")]
        public IActionResult AddResult(int candidateId)
        {
            var result = testResultPresenter.AddResult(candidateId);
            return helperMethode(result, "result");


            // return Ok(testResultPresenter.AddResult(candidateId));
        }
        #endregion






        #region Get All Record
        /// <summary>
        /// Url : http://localhost:55377/test/getall
        /// </summary>
        /// <returns>
        /// {
        ///"success": true,
        ///"status": 200,
        ///"message": "result",
        ///"data": {
        ///"result": []
        ///}
        ///}
        /// </returns>
        [HttpGet]
        [Route("/test/getall")]
        public IActionResult GetAll()
        {
            var result = testResultPresenter.DisplayResultAllCandidate();
            return helperMethode(result, "result");

            // return Ok(testResultPresenter.DisplayResultAllCandidate());
        }
        #endregion






        
        
        
        #region Get Test By Id
        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidateId"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("/test/getbyId")]
        public IActionResult DisplayResultcandidateById(int candidateId)
        {
            var result = testResultPresenter.DisplayResultcandidateById(candidateId);
            return helperMethode(result, "result");
            //return Ok();
        }
        #endregion









        #region Get Test By Date
        /// <summary>
        /// url : http://localhost:55377/test/getbyId?candidateId=45
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns>
        /// return test record of candidate Id 45
        /// </returns>

        [HttpGet]
        [Route("/test/getbydate")]
        public IActionResult DisplayResultbyDate(DateTime fromDate,
                                                 DateTime toDate)
        {
            var result = testResultPresenter.DisplayResultbyDate(fromDate, toDate);
            return helperMethode(result, "result");


            //return Ok(testResultPresenter.DisplayResultbyDate(fromDate, toDate));
        }
        #endregion








        
        
        #region Get Test By Percentage
        /// <summary>
        /// url : http://localhost:55377/test/getbypercentage
        /// </summary>
        /// <returns>
        /// get percentage in descending order
        /// </returns>
        [HttpGet]
        [Route("/test/getbypercentage")]
        public IActionResult DisplayResultbyPercentage()
        {
            var result = testResultPresenter.DisplayResultbyPercentage();
            return helperMethode(result, "result");


            //return Ok(testResultPresenter.DisplayResultbyDate(fromDate, toDate));
        }

        #endregion






        
        
        #region Get by Percenatge and Category
        /// <summary>
        /// url : http://localhost:55377/test/getbyperandcat
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>
        /// get test record of specific category in descending order of percentage 
        /// </returns>

        [HttpGet]
        [Route("/test/getbyperandcat")]
        public IActionResult DisplayResultbyPercentageAndCategory(int categoryId)
        {
            var result = testResultPresenter.DisplayResultbyPercentageAndCategory(categoryId);
            return helperMethode(result, "result");
        }
        #endregion






        
        
        #region Get By Percentage Category and Experience
        [HttpGet]
        [Route("/test/getbypercatandexp")]
        public IActionResult DisplayResultbyPercentageAndCategoryAndExperience(int categoryId, 
                                                                               int experienceLevelId)
        {
            var result = testResultPresenter.DisplayResultbyPercentageAndCategoryAndExperience(categoryId, 
                                                                                               experienceLevelId);
            return helperMethode(result, "result");
        }
        #endregion






        
        
        #region Get By Percentage And Experience
        [HttpGet]
        [Route("/test/getbyperandexp")]
        public IActionResult DisplayResultbyPercentageAndExperience(int experienceId)
        {
            var result = testResultPresenter.DisplayResultbyPercentageAndExperience(experienceId);
            return helperMethode(result, "result");
        }
        #endregion





        
        
        
        #region Get By Category
        /// <summary>
        /// url : http://localhost:55377/test/getbycat
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>
        /// get test record of category
        /// </returns>
        [HttpGet]
        [Route("/test/getbycat")]
        public IActionResult DisplayResultbyCategory(int categoryId)
        {
            var result = testResultPresenter.DisplayResultbyCategory(categoryId);
            return helperMethode(result, "result");
        }
        #endregion






       
        
        
        #region Get By Experience
        [HttpGet]
        [Route("/test/getbyexp")]
        public IActionResult DisplayResultbyExperience(int experienceId)
        {
            var result = testResultPresenter.DisplayResultbyExperience(experienceId);
            return helperMethode(result, "result");
        }
        #endregion





        
        
        
        
        #region Get By Cat and Exp
        [HttpGet]
        [Route("/test/getbycatandexp")]
        public IActionResult DisplayResultbyCategoryAndExperience(int categoryId,
                                                                  int experienceId)
        {
            var result = testResultPresenter.DisplayResultbyCategoryAndExperience(categoryId,
                                                                                  experienceId);
            return helperMethode(result, "result");
        }
        #endregion









        #region Get By Category And Date
        /// <summary>
        /// url : http://localhost:55377/test/getbycatanddate
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns>
        /// get testResult Record of category on a specific dates
        /// </returns>
        [HttpGet]
        [Route("/test/getbycatanddate")]
        public IActionResult DisplayResultbyCategoryFromDate(int categoryId,
                                                             DateTime fromDate,
                                                             DateTime toDate)
        {
            var result = testResultPresenter.DisplayResultbyCategoryFromDate(categoryId,
                                                                             fromDate,
                                                                             toDate);
            return helperMethode(result, "result");
        }
        #endregion








        #region Get By Experience And Date
        [HttpGet]
        [Route("/test/getbyexpanddate")]
        public IActionResult DisplayResultbyExpFromDate(int experienceId,
                                                        DateTime fromDate, 
                                                        DateTime toDate)
        {
            var result = testResultPresenter.DisplayResultbyExpFromDate(experienceId,
                                                                        fromDate,
                                                                        toDate);
            return helperMethode(result, "result");
        }
        #endregion






        #region Get by Category Experience And Date
        [HttpGet]
        [Route("/test/getbycatexpanddate")]
        public IActionResult DisplayResultbyCatAndExpFromDate(int categoryId,
                                                              int experienceId, 
                                                              DateTime fromDate, 
                                                              DateTime toDate)
        {
            var result = testResultPresenter.DisplayResultbyCatAndExpFromDate(categoryId,
                                                                              experienceId,
                                                                              fromDate,
                                                                              toDate);
            return helperMethode(result, "result");
        }
        #endregion






        #region Get by Status
        /// <summary>
        /// url : http://localhost:55377/test/getbystatus
        /// </summary>
        /// <param name="status"></param>
        /// <returns>
        /// get record of Pass and Fail Status
        /// </returns>

        [HttpGet]
        [Route("/test/getbystatus")]
        public IActionResult DisplayResultbyTestStatus(string status)
        {
            var result = testResultPresenter.DisplayResultbyTestStatus(status);
            return helperMethode(result, "result");
        }
        #endregion





        #region Get by Status And Ctaegory
        /// <summary>
        /// url : http://localhost:55377/test/getbystaandcat
        /// </summary>
        /// <param name="status"></param>
        /// <param name="categoryId"></param>
        /// <returns>
        ///  get record of Pass and Fail Status of a category
        /// </returns>
        [HttpGet]
        [Route("/test/getbystaandcat")]
        public IActionResult DisplayResultbyTestStatusAndCat(string status,
                                                             int categoryId)
        {
            var result = testResultPresenter.DisplayResultbyTestStatusAndCat(status,
                                                                             categoryId);
            return helperMethode(result, "result");
        }
        #endregion







        #region Get by Status and Experince
        [HttpGet]
        [Route("/test/getbystaandexp")]
        public IActionResult DisplayResultbyTestStatusAndExp(string status,
                                                             int experienceId)
        {
            var result = testResultPresenter.DisplayResultbyTestStatusAndExp(status,
                                                                             experienceId);
            return helperMethode(result, "result");

        }
        #endregion






       
        #region Get by Status Experience And Category
        [HttpGet]
        [Route("/test/getbystaandexpandcat")]
        public IActionResult DisplayResultbyTestStatusAndExpAndCat(string status,
                                                                   int experienceId,
                                                                   int categoryId)
        {
            var result = testResultPresenter.DisplayResultbyTestStatusAndExpAndCat(status,
                                                                                   experienceId,
                                                                                   categoryId);
            return helperMethode(result, "result");
        }

        #endregion






       
        #region Get by status and date
        /// <summary>
        /// url : http://localhost:55377/test/getbystaanddate
        /// </summary>
        /// <param name="status"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns>
        /// get record of Pass and Fail Status of date Vise
        /// </returns>
        [HttpGet]
        [Route("/test/getbystaanddate")]
        public IActionResult DisplayResultbyTestStatusFromDate(string status,
                                                               DateTime fromDate,
                                                               DateTime toDate)
        {
            var result = testResultPresenter.DisplayResultbyTestStatusFromDate(status,
                                                                               fromDate,
                                                                               toDate);
            return helperMethode(result, "result");
        }
        #endregion





       
        #region Get By status Category and date
        /// <summary>
        /// url : http://localhost:55377/test/getbystacatanddate
        /// </summary>
        /// <param name="status"></param>
        /// <param name="categoryId"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns>
        /// get Result of Pass and Fail Status according to date category
        /// </returns>
        [HttpGet]
        [Route("/test/getbystacatanddate")]
        public IActionResult DisplayResultbyTestStatusandCatFromDate(string status,
                                                                     int categoryId,
                                                                     DateTime fromDate,
                                                                     DateTime toDate)
        {
            var result = testResultPresenter.DisplayResultbyTestStatusandCatFromDate(status,
                                                                                     categoryId,
                                                                                     fromDate, 
                                                                                     toDate);
            return helperMethode(result, "result");
        }
        #endregion





       
        #region Get byb status Category Experience and date
        [HttpGet]
        [Route("/test/getbystaexpcatanddate")]
        public IActionResult DisplayResultbyTestStatusandCatAndExpFromDate(string status,
                                                                           int categoryId,
                                                                           int experienceId,
                                                                           DateTime fromDate,
                                                                           DateTime toDate)
        {
            var result = testResultPresenter.DisplayResultbyTestStatusandCatAndExpFromDate(status,
                                                                                           categoryId,
                                                                                           experienceId,
                                                                                           fromDate,
                                                                                           toDate);
            return helperMethode(result, "result");
        }
        #endregion





        
        #region Get by Top10 Percentage
        /// <summary>
        /// url : http://localhost:55377/test/top10per
        /// </summary>
        /// <returns>
        /// return top 10 percentage candidate record
        /// </returns>

        [HttpGet]
        [Route("/test/top10per")]
        public IActionResult DisplayResultbyTop10Percentage()
        {
            var result = testResultPresenter.DisplayResultbyTop10Percentage();
            return helperMethode(result, "result");
        }
        #endregion






       
       
        #region GET top10 Percentage and category
        /// <summary>
        /// url : http://localhost:55377/test/top10perandcat
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>
        /// return top10 percentages of candidate according to category
        /// </returns>
        [HttpGet]
        [Route("/test/top10perandcat")]
        public IActionResult DisplayResultbyTop10PercentageAndCategory(int categoryId)
        {
            var result = testResultPresenter.DisplayResultbyTop10PercentageAndCategory(categoryId);
            return helperMethode(result, "result");
        }
        #endregion






        
        
        
        
        #region Get Top10 Percentage Category And Experience
        [HttpGet]
        [Route("/test/top10perandcatexp")]
        public IActionResult DisplayResultbyTop10PercentageAndCategoryAndExperience(int categoryId,
                                                                                    int experienceLevelId)
        {
            var result = testResultPresenter.DisplayResultbyTop10PercentageAndCategoryAndExperience(categoryId,
                                                                                                    experienceLevelId);
            return helperMethode(result, "result");
        }
        #endregion






       
        #region Get Top10 percentage and Experience
        [HttpGet]
        [Route("/test/top10perandexp")]
        public IActionResult DisplayResultbyTop10PercentageAndExperience(int experienceId)
        {
            var result = testResultPresenter.DisplayResultbyTop10PercentageAndExperience(experienceId);
            return helperMethode(result, "result");
        }
        #endregion






       
        #region Get Top10 Status
        /// <summary>
        /// url : http://localhost:55377/test/top10status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/test/top10status")]
        public IActionResult DisplayResultbyTop10TestStatus(string status)
        {
            var result = testResultPresenter.DisplayResultbyTop10TestStatus(status);
            return helperMethode(result, "result");

        }
        #endregion






       
        
        
        #region Get Top10 status and Category

        /// <summary>
        /// url : http://localhost:55377/test/top10statusandcat
        /// </summary>
        /// <param name="status"></param>
        /// <param name="categoryId"></param>
        /// <returns>
        /// return record of top 10 fail or pass 
        /// </returns>

        [HttpGet]
        [Route("/test/top10statusandcat")]
        public IActionResult DisplayResultbyTop10TestStatusAndCat(string status,
                                                                  int categoryId)
        {
            var result = testResultPresenter.DisplayResultbyTop10TestStatusAndCat(status,
                                                                                  categoryId);
            return helperMethode(result, "result");
        }
        #endregion




       
        
        
        #region Get Top10 Status and Experience
        [HttpGet]
        [Route("/test/top10statusandexp")]
        public IActionResult DisplayResultbyTop10TestStatusAndExp(string status,
                                                                  int experienceId)
        {
            var result = testResultPresenter.DisplayResultbyTop10TestStatusAndExp(status,
                                                                                  experienceId);
            return helperMethode(result, "result");
        }
        #endregion






        
        
        #region Get Top10 Status Category And Experience
        [HttpGet]
        [Route("/test/top10statuscatexp")]
        public IActionResult DisplayResultbyTop10TestStatusAndExpAndCat(string status,
                                                                        int experienceId,
                                                                        int categoryId)
        {
            var result = testResultPresenter.DisplayResultbyTop10TestStatusAndExpAndCat(status,
                                                                                        experienceId,
                                                                                        categoryId);
            return helperMethode(result, "result");
        }
        #endregion


        [HttpGet]
        [Route("/test/testcount")]
        public IActionResult TestCount()
        {
            int count = testResultPresenter.TestCount();
            return helperMethode(count,"count");
        }




        [HttpGet]
        [Route("/test/passcandidatecount")]
        public IActionResult PasscandidateCount()
        {
            int count = testResultPresenter.PasscandidateCount();
            return helperMethode(count, "count");
        }

        [HttpGet]
        [Route("/test/failcandidatecount")]
        public IActionResult FailcandidateCount()
        {
            int count = testResultPresenter.FailcandidateCount();
            return helperMethode(count, "count");
        }





    }
}