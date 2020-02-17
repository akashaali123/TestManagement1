﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TestManagement1.Model;
using TestManagementCore.Presenter;
using TestManagementCore.RepositoryInterface;
using TestManagementCore.ViewModel;

namespace TestManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionAndOptionController : BaseController<QuestionAndOptionPresenter>
    {

        QuestionAndOptionPresenter questionAndOptionPresenter;
        public QuestionAndOptionController(IWebHostEnvironment webHostEnvironment, IQuestionAndOption repository, ILogger<QuestionAndOptionPresenter> logger) : base(webHostEnvironment, logger)
        {
            questionAndOptionPresenter = new QuestionAndOptionPresenter(webHostEnvironment, repository, logger);
        }


        [HttpPost]
        [Route("/question/create")]
        public IActionResult Add(QuestionAndOptionViewModel model)
        {
            try
            {
                // Data Dictionary added as per the standard policy
                Dictionary<string, object> data = new Dictionary<string, object>();

                var questionAndOption = questionAndOptionPresenter.Add(model);

                if (questionAndOption != null)
                {
                    // Add the data in the JSON Data field below
                    data.Add("Question and Options", questionAndOption);


                    // Return Data 

                    //MyReturnMethode Return the data in Ok result its implementation in base controller
                    return MyReturnMethode(true, StatusCodes.Status200OK, "Question and Options Created", data);
                }
                else
                {
                    // Error Returned

                    //MyReturnMethode Return the data in Ok result its implementation in base controller
                    return MyReturnMethode(false, StatusCodes.Status400BadRequest, "Invalid Attempt", data);

                }
                // Clear
            }
            catch (Exception ex)
            {

                // Exception thrown
                Dictionary<string, object> data = new Dictionary<string, object>();

                // Add the data in the JSON Data field below
                data.Add("exception", ex);

                // Return Exception

                //MyReturnMethode Return the data in Ok result its implementation in base controller
                return MyReturnMethode(false, StatusCodes.Status502BadGateway, "Exception Found", data);
            }        
        }


        [HttpDelete]
        [Route("/question/delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Data Dictionary added as per the standard policy
                Dictionary<string, object> data = new Dictionary<string, object>();


               var question = questionAndOptionPresenter.Delete(id);
                if (question != null)
                {
                    // Add the data in the JSON Data field below
                    data.Add("Question and Options", question);


                    // Return Data 

                    //MyReturnMethode Return the data in Ok result its implementation in base controller
                    return MyReturnMethode(true, StatusCodes.Status200OK, "Question Deleted", data);
                }
                else
                {
                    // Error Returned

                    //MyReturnMethode Return the data in Ok result its implementation in base controller
                    return MyReturnMethode(false, StatusCodes.Status400BadRequest, "Invalid Attempt", data);

                }
                // Clear

            }
            catch (Exception ex)
            {

                // Exception thrown
                Dictionary<string, object> data = new Dictionary<string, object>();

                // Add the data in the JSON Data field below
                data.Add("exception", ex);

                // Return Exception

                //MyReturnMethode Return the data in Ok result its implementation in base controller
                return MyReturnMethode(false, StatusCodes.Status502BadGateway, "Exception Found", data);
            }

           
        }

        [HttpPut]
        [Route("/question/update")]
        public IActionResult Update(QuestionAndOptionViewModel questionAndOptionViewModel, int id)
        {

            return Ok(questionAndOptionPresenter.Update(questionAndOptionViewModel, id));
        }




    }
}