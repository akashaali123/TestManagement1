using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class TestResultByReviewerController : BaseController<TestResultByReviewerPresenter>
    {


        TestResultByReviewerPresenter testResultByReviewerPresenter;

        public TestResultByReviewerController(IWebHostEnvironment webHostEnvironment, ITestResultByReviewer repository, ILogger<TestResultByReviewerPresenter> logger) : base(webHostEnvironment, logger)
        {
            testResultByReviewerPresenter = new TestResultByReviewerPresenter(webHostEnvironment, repository, logger);
        }

        public IActionResult DisplayResultAllCandidate()
        {
            var result = testResultByReviewerPresenter.DisplayResultAllCandidate();
            return helperMethode(result, "result");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller   
        }


    }
}