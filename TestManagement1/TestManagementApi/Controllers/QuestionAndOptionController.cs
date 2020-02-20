using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        TestManagementContext _context;
        QuestionAndOptionPresenter questionAndOptionPresenter;
        public QuestionAndOptionController(IWebHostEnvironment webHostEnvironment, IQuestionAndOption repository, ILogger<QuestionAndOptionPresenter> logger, TestManagementContext context) : base(webHostEnvironment, logger)
        {
            questionAndOptionPresenter = new QuestionAndOptionPresenter(webHostEnvironment, repository, logger);
            _context = context;
        }


        #region createQuestion
        [HttpPost]
        [Route("/question/create")]
        public IActionResult Add(QuestionAndOptionViewModel model)
        {


            var questionAndOption = questionAndOptionPresenter.Add(model);
            return helperMethode(questionAndOption, "question");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller

        }
        #endregion




      
        
        
        #region Delete Question
        [HttpDelete]
        [Route("/question/delete")]
        public IActionResult Delete(int id)
        {
            var question = questionAndOptionPresenter.Delete(id);
            return helperMethode(question, "question");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller
        }
        #endregion




       
        
        
        #region UpdateQuestion
        [HttpPut]
        [Route("/question/update")]
        public IActionResult Update(QuestionAndOptionViewModel questionAndOptionViewModel, int id)
        {
            var update = questionAndOptionPresenter.Update(questionAndOptionViewModel, id);
            return helperMethode(update, "question");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller
        }
        #endregion



        
        
        
        #region get Question By Id
        [HttpGet]
        [Route("/question/getquesbyid")]
        public IActionResult GetQuestById(int id)
        {
            var question = questionAndOptionPresenter.GetQuestionById(id);
            return helperMethode(question, "question");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller
        }
        #endregion




       
        
        
        #region Get All question
        [HttpGet]
        [Route("/question/getallques")]
        public IActionResult GetQuestAll()
        {
            var allQuestion = questionAndOptionPresenter.GetAll();
            return helperMethode(allQuestion, "questions");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller
        }
        #endregion







        #region Get Question By Category
        [HttpGet]
        [Route("/question/getbycat")]
        public IActionResult GetQuestionByCategory(int categoryId)
        {
            var question = questionAndOptionPresenter.GetQuestionByCategory(categoryId);
            return helperMethode(question, "questions");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller
        }
        #endregion



        
        
        
        
        #region Get Question by Category and Experience
        [HttpGet]
        [Route("/question/getbycatandexp")]
        public IActionResult GetQuestionByCategoryAndExperience(int categoryId, int experienceLevelId)
        {
            var question = questionAndOptionPresenter.GetQuestionByCategoryAndExperience(categoryId, experienceLevelId);
            return helperMethode(question, "questions");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller
        }
        #endregion



        
        
        
        
        #region Get Question by Category and Experience And Number
        [HttpGet]
        [Route("/question/getbycatandexpandnum")]
        public IActionResult GetQuestionByCategoryAndExperienceAndNo(int categoryId, int experienceLevelId, int number)
        {
            var question = questionAndOptionPresenter.GetQuestionByCategoryAndExperienceAndNo(categoryId, experienceLevelId, number);
            return helperMethode(question, "questions");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller
        }
        #endregion









        #region Get Question By Shuffling
        [HttpGet]
        [Route("/question/getbyshuffle")]
        public IActionResult GetQuestionByCategoryAndExperienceAndNumberAndShuffling(int candidateId, int number)
        {
            var question = questionAndOptionPresenter.GetQuestionByCategoryAndExperienceAndNumberAndShuffling(candidateId, number);
            return helperMethode(question, "questions");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller
        }
        #endregion








    }
}