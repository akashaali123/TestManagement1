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

    }
}