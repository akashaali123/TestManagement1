using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestManagement1.RepositoryInterface;
using TestManagementCore.Presenter;
using TestManagementCore.RepositoryInterface;

namespace TestManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestResultByReviewerController : BaseController<TestResultByReviewerPresenter>
    {


        TestResultByReviewerPresenter testResultByReviewerPresenter;

        public TestResultByReviewerController(IWebHostEnvironment webHostEnvironment,
                                              ITestResultByReviewer repository,
                                              ILogger<TestResultByReviewerPresenter> logger) : base(webHostEnvironment, logger)
        {
            testResultByReviewerPresenter = new TestResultByReviewerPresenter(webHostEnvironment, repository, logger);
        }



        [HttpGet]
        [Route("/testresult/getall")]
        public IActionResult DisplayResultAllCandidate()
        {
            var result = testResultByReviewerPresenter.DisplayResultAllCandidate();
            return helperMethode(result, "result");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller   
        }




        [HttpGet]
        [Route("/testresult/getbyid")]
        public IActionResult DisplayResultCandidatebyId(int candidateId)
        {
            var result = testResultByReviewerPresenter.DisplayResultcandidateById(candidateId);
            return helperMethode(result, "result");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller   
        }


       
        
        
        
        [HttpGet]
        [Route("/testresult/getquestion")]
        public IActionResult DisplayCandidateQuestion(int candidateId)
        {
            var result = testResultByReviewerPresenter.DisplayCandidateQuestion(candidateId);
            return helperMethode(result, "result");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller   
        }


       
        
        
        
        [HttpGet]
        [Route("/testresult/gettestbydate")]
        public IActionResult DisplayResultbyDate(DateTime fromDate, 
                                                 DateTime toDate)
        {
            var result = testResultByReviewerPresenter.DisplayResultbyDate(fromDate, toDate);
            return helperMethode(result, "result");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller   
        }


        
        
        
        [HttpGet]
        [Route("/testresult/gettestbyper")]
        public IActionResult DisplayResultbyPercentage()
        {
            var result = testResultByReviewerPresenter.DisplayResultbyPercentage();
            return helperMethode(result, "result");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller   
        }

       
        
        
        [HttpGet]
        [Route("/testresult/gettop10per")]
        public IActionResult DisplayResultbyTop10Percentage()
        {
            var result = testResultByReviewerPresenter.DisplayResultbyTop10Percentage();
            return helperMethode(result, "result");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller   
        }

       
        
        
        
        [HttpGet]
        [Route("/testresult/gettop10status")]
        public IActionResult DisplayResultbyTop10TestStatus(string status)
        {
            var result = testResultByReviewerPresenter.DisplayResultbyTop10TestStatus(status);
            return helperMethode(result, "result");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller   
        }


    
    
    
    }
}