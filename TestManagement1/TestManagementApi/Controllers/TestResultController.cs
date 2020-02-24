using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class TestResultController : BaseController<TestResultPresenter>
    {
        TestResultPresenter testResultPresenter;

        public TestResultController(IWebHostEnvironment webHostEnvironment, ITestResult repository, ILogger<TestResultPresenter> logger) : base(webHostEnvironment, logger)
        {
            testResultPresenter = new TestResultPresenter(webHostEnvironment, repository, logger); ;
        }


        [HttpPost]
        [Route("/test/add")]
        public IActionResult AddResult(int candidateId)
        {
            var result = testResultPresenter.AddResult(candidateId);
            return helperMethode(result, "result");


           // return Ok(testResultPresenter.AddResult(candidateId));
        }

        [HttpGet]
        [Route("/test/getall")]
        public IActionResult GetAll()
        {
            var result = testResultPresenter.DisplayResultAllCandidate();
            return helperMethode(result, "result");

           // return Ok(testResultPresenter.DisplayResultAllCandidate());
        }

        [HttpGet]
        [Route("/test/getbyId")]
        public IActionResult DisplayResultcandidateById(int candidateId)
        {
            var result = testResultPresenter.DisplayResultcandidateById(candidateId);
            return helperMethode(result, "result");
            //return Ok();
        }

        [HttpGet]
        [Route("/test/getbydate")]
        public IActionResult DisplayResultbyDate(DateTime fromDate, DateTime toDate)
        {
            var result = testResultPresenter.DisplayResultbyDate(fromDate, toDate);
            return helperMethode(result, "result");


            //return Ok(testResultPresenter.DisplayResultbyDate(fromDate, toDate));
        }

        [HttpGet]
        [Route("/test/getbypercentage")]
        public IActionResult DisplayResultbyPercentage()
        {
            var result = testResultPresenter.DisplayResultbyPercentage();
            return helperMethode(result, "result");


            //return Ok(testResultPresenter.DisplayResultbyDate(fromDate, toDate));
        }

        [HttpGet]
        [Route("/test/getbyperandcat")]
        public IActionResult DisplayResultbyPercentageAndCategory(int categoryId)
        {
            var result = testResultPresenter.DisplayResultbyPercentageAndCategory(categoryId);
            return helperMethode(result, "result");
        }

        [HttpGet]
        [Route("/test/getbypercatandexp")]
        public IActionResult DisplayResultbyPercentageAndCategoryAndExperience(int categoryId, int experienceLevelId)
        {
            var result = testResultPresenter.DisplayResultbyPercentageAndCategoryAndExperience(categoryId, experienceLevelId);
            return helperMethode(result, "result");
        }



        [HttpGet]
        [Route("/test/getbyperandexp")]
        public IActionResult DisplayResultbyPercentageAndExperience(int experienceId)
        {
            var result = testResultPresenter.DisplayResultbyPercentageAndExperience(experienceId);
            return helperMethode(result, "result");
        }



        [HttpGet]
        [Route("/test/getbycat")]
        public IActionResult DisplayResultbyCategory(int categoryId)
        {
            var result = testResultPresenter.DisplayResultbyCategory(categoryId);
            return helperMethode(result, "result");
        }


        [HttpGet]
        [Route("/test/getbyexp")]
        public IActionResult DisplayResultbyExperience(int experienceId)
        {
            var result = testResultPresenter.DisplayResultbyExperience(experienceId);
            return helperMethode(result, "result");
        }

        [HttpGet]
        [Route("/test/getbycatandexp")]
        public IActionResult DisplayResultbyCategoryAndExperience(int categoryId, int experienceId)
        {
            var result = testResultPresenter.DisplayResultbyCategoryAndExperience(categoryId, experienceId);
            return helperMethode(result, "result");
        }


        [HttpGet]
        [Route("/test/getbycatanddate")]

        public IActionResult DisplayResultbyCategoryFromDate(int categoryId, DateTime fromDate, DateTime toDate)
        {
            var result = testResultPresenter.DisplayResultbyCategoryFromDate(categoryId, fromDate, toDate);
            return helperMethode(result, "result");
        }


        [HttpGet]
        [Route("/test/getbyexpanddate")]
        public IActionResult DisplayResultbyExpFromDate(int experienceId, DateTime fromDate, DateTime toDate)
        {
            var result = testResultPresenter.DisplayResultbyExpFromDate(experienceId, fromDate, toDate);
            return helperMethode(result, "result");
        }

        [HttpGet]
        [Route("/test/getbycatexpanddate")]
        public IActionResult DisplayResultbyCatAndExpFromDate(int categoryId, int experienceId, DateTime fromDate, DateTime toDate)
        {
            var result = testResultPresenter.DisplayResultbyCatAndExpFromDate(categoryId, experienceId, fromDate, toDate);
            return helperMethode(result, "result");
        }

        [HttpGet]
        [Route("/test/getbystatus")]
        public IActionResult DisplayResultbyTestStatus(string status)
        {
            var result = testResultPresenter.DisplayResultbyTestStatus(status);
            return helperMethode(result, "result");
        }


        [HttpGet]
        [Route("/test/getbystaandcat")]
        public IActionResult DisplayResultbyTestStatusAndCat(string status, int categoryId)
        {
            var result = testResultPresenter.DisplayResultbyTestStatusAndCat(status, categoryId);
            return helperMethode(result, "result");
        }

        [HttpGet]
        [Route("/test/getbystaandexp")]
        public IActionResult DisplayResultbyTestStatusAndExp(string status, int experienceId)
        {
            var result = testResultPresenter.DisplayResultbyTestStatusAndExp(status, experienceId);
            return helperMethode(result, "result");

        }

        [HttpGet]
        [Route("/test/getbystaandexpandcat")]
        public IActionResult DisplayResultbyTestStatusAndExpAndCat(string status, int experienceId, int categoryId)
        {
            var result = testResultPresenter.DisplayResultbyTestStatusAndExpAndCat(status, experienceId, categoryId);
            return helperMethode(result, "result");
        }

        [HttpGet]
        [Route("/test/getbystaanddate")]
        public IActionResult DisplayResultbyTestStatusFromDate(string status, DateTime fromDate, DateTime toDate)
        {
            var result = testResultPresenter.DisplayResultbyTestStatusFromDate(status, fromDate, toDate);
            return helperMethode(result, "result");
        }
        public IActionResult DisplayResultbyTestStatusandCatFromDate(string status, int categoryId, DateTime fromDate, DateTime toDate)
        {
            var result = testResultPresenter.DisplayResultbyTestStatusandCatFromDate(status, categoryId, fromDate, toDate);
            return helperMethode(result, "result");
        }

        [HttpGet]
        [Route("/test/getbystaexpcatanddate")]
        public IActionResult DisplayResultbyTestStatusandCatAndExpFromDate(string status, int categoryId, int experienceId, DateTime fromDate, DateTime toDate)
        {
            var result = testResultPresenter.DisplayResultbyTestStatusandCatAndExpFromDate(status, categoryId, experienceId, fromDate, toDate);
            return helperMethode(result, "result");
        }

        [HttpGet]
        [Route("/test/top10per")]
        public IActionResult DisplayResultbyTop10Percentage()
        {
            var result = testResultPresenter.DisplayResultbyTop10Percentage();
            return helperMethode(result, "result");
        }

        [HttpGet]
        [Route("/test/top10perandcat")]
        public IActionResult DisplayResultbyTop10PercentageAndCategory(int categoryId)
        {
            var result = testResultPresenter.DisplayResultbyTop10PercentageAndCategory(categoryId);
            return helperMethode(result, "result");
        }

        [HttpGet]
        [Route("/test/top10perandcatexp")]
        public IActionResult DisplayResultbyTop10PercentageAndCategoryAndExperience(int categoryId, int experienceLevelId)
        {
            var result = testResultPresenter.DisplayResultbyTop10PercentageAndCategoryAndExperience(categoryId, experienceLevelId);
            return helperMethode(result, "result");
        }

        [HttpGet]
        [Route("/test/top10perandexp")]
        public IActionResult DisplayResultbyTop10PercentageAndExperience(int experienceId)
        {
            var result = testResultPresenter.DisplayResultbyTop10PercentageAndExperience(experienceId);
            return helperMethode(result, "result");
        }

        [HttpGet]
        [Route("/test/top10status")]
        public IActionResult DisplayResultbyTop10TestStatus(string status)
        {
            var result = testResultPresenter.DisplayResultbyTop10TestStatus(status);
            return helperMethode(result, "result");

        }
        [HttpGet]
        [Route("/test/top10statusandcat")]
        public IActionResult DisplayResultbyTop10TestStatusAndCat(string status, int categoryId)
        {
            var result = testResultPresenter.DisplayResultbyTop10TestStatusAndCat(status, categoryId);
            return helperMethode(result, "result");
        }

        [HttpGet]
        [Route("/test/top10statusandexp")]
        public IActionResult DisplayResultbyTop10TestStatusAndExp(string status, int experienceId)
        {
            var result = testResultPresenter.DisplayResultbyTop10TestStatusAndExp(status, experienceId);
            return helperMethode(result, "result");
        }

        [HttpGet]
        [Route("/test/top10statuscatexp")]
        public IActionResult DisplayResultbyTop10TestStatusAndExpAndCat(string status, int experienceId, int categoryId)
        {
            var result = testResultPresenter.DisplayResultbyTop10TestStatusAndExpAndCat(status, experienceId, categoryId);
            return helperMethode(result, "result");
        }
    }
}