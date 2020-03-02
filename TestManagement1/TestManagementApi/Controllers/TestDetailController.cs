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
using TestManagementCore.ViewModel;

namespace TestManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDetailController :  BaseController<TestDetailPresenter>
    {

        TestDetailPresenter detailPresenter;
        public TestDetailController(IWebHostEnvironment webHostEnvironment,
                                    ITestDetails repository,
                                    ILogger<TestDetailPresenter> logger) : base(webHostEnvironment, logger)
        {
            detailPresenter = new TestDetailPresenter(webHostEnvironment, repository, logger);
        }


        /// <summary>
        /// url : http://localhost:55377/testdetail/create
        /// Body
        /// {
        ///"CandidateId":41,
        ///"QuestionId":44,
        ///"SelectedOptionId":"61,64"
        ///}
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// true
        /// </returns>

        [HttpPost]
        [Route("/testdetail/create")]
        public IActionResult Add(TestDetailsViewModel model)
        {
            var test = detailPresenter.Add(model);
            return helperMethode(test,"test");
        }

    }
}