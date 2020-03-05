using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class QuestionAndOptionController : BaseController<QuestionAndOptionPresenter>
    {

        QuestionAndOptionPresenter questionAndOptionPresenter;
        public QuestionAndOptionController(IWebHostEnvironment webHostEnvironment,
                                           IQuestionAndOption repository,
                                           ILogger<QuestionAndOptionPresenter> logger) : base(webHostEnvironment, logger)
        {
            questionAndOptionPresenter = new QuestionAndOptionPresenter(webHostEnvironment, repository, logger);

        }




        /// <summary>
        ///Url : http://localhost:55377/question/create
        ///Body
        ///{	
        ///"question":{
        ///"Description":"afsdkafsdgfs",
        ///"Type":"ASP.NET",
        ///"Time":"5-2-2020",
        ///"Marks":4,
        ///"CategoryId":2,
        ///"ExperienceLevelId":21
        ///},
        ///"option":[
        ///{
        ///"OptionDescription":"OPTION1",
        ///"IsCorrect":0,
        ///"Duration":"5:10"
        ///},
        ///{
        ///"OptionDescription":"OPTION2",
        ///"IsCorrect":1,
        ///"Duration":"5:10"	
        ///},
        ///{
        ///"OptionDescription":"OPTION3",
        ///"IsCorrect":1,
        ///"Duration":"5:10"	
        ///}
        ///]
        ///}	
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// {
        ///"success": true,
        ///"status": 200,
        ///"message": "question",
        ///"data": {
        ///"question": {
        ///"question": {
        ///"questionId": 55,
        ///"description": "afsdkafsdgfs",
        ///"type": "ASP.NET",
        ///"time": "2020-05-02T00:00:00",
        ///"marks": 4,
        ///"isActive": true,
        ///"createdBy": null,
        ///"createdDate": "0001-01-01T00:00:00",
        ///"updatedBy": null,
        ///"updatedDate": null,
        ///"categoryId": 2,
        ///"experienceLevelId": 21
        ///},
        ///"option": [
        ///{
        ///"optionId": 94,
        ///"optionDescription": "OPTION1",
        ///"isCorrect": false,
        ///"questionId": 55,
        ///"duration": "2020-02-25T05:10:00",
        ///"isActive": true,
        ///"createdBy": null,
        ///"createdDate": null,
        ///"updatedBy": null,
        ///"updatedDate": null
        ///},
        ///{
        ///"optionId": 95,
        ///"optionDescription": "OPTION2",
        ///"isCorrect": true,
        ///"questionId": 55,
        ///"duration": "2020-02-25T05:10:00",
        ///"isActive": true,
        ///"createdBy": null,
        ///"createdDate": null,
        ///"updatedBy": null,
        ///"updatedDate": null
        ///},
        ///{
        ///"optionId": 96,
        ///"optionDescription": "OPTION3",
        ///"isCorrect": true,
        ///"questionId": 55,
        ///"duration": "2020-02-25T05:10:00",
        ///"isActive": true,
        ///"createdBy": null,
        ///"createdDate": null,
        ///"updatedBy": null,
        ///"updatedDate": null
        ///}
        ///]
        ///}
        ///}
        ///}
        /// </returns>

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





        /// <summary>
        /// Url : http://localhost:55377/question/Delete?id=55
        /// 
        /// Its also delete all option of the question 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// {
        ///"success": true,
        ///"status": 200,
        ///"message": "question",
        ///"data": {
        ///"question": {
        ///"questionId": 55,
        ///"description": "afsdkafsdgfs",
        ///"type": "ASP.NET",
        ///"time": "2020-05-02T00:00:00",
        ///"marks": 4,
        ///"isActive": true,
        ///"createdBy": null,
        ///"createdDate": "0001-01-01T00:00:00",
        ///"updatedBy": null,
        ///"updatedDate": null,
        ///"categoryId": 2,
        ///"experienceLevelId": 21
        ///}
        ///}
        ///}
        /// </returns>

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





        /// <summary>
        /// Url : http://localhost:55377/question/update?id=46
        /// Body
        /// {	
        ///"question":{
        ///"Description":"Q3",
        ///"Type":"ASP.NET",
        ///"Time":"5-2-2020",
        ///"Marks":4,
        ///"CategoryId":20,
        ///"ExperienceLevelId":2
        ///},
        ///"option":[
        ///{
        ///"OptionDescription":"OPTION21",
        ///"IsCorrect":0,
        ///"Duration":"5:10"
        ///},
        ///{
        ///"OptionDescription":"OPTION22",
        ///"IsCorrect":1,
        ///"Duration":"5:10"	
        ///}
        ///]
        ///}
        /// 
        /// </summary>
        /// <param name="questionAndOptionViewModel"></param>
        /// <param name="id"></param>
        /// <returns>
        /// same body with updated Field
        /// </returns>

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




        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

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





        /// <summary>
        /// url : http://localhost:55377/question/getquesbyid?id=44
        /// </summary>
        /// <returns>
        /// {
        ///"success": true,
        ///"status": 200,
        ///"message": "question",
        ///"data": {
        ///"question": {
        ///"questionId": 51,
        ///"question": "<?php     $num  = 1;     $num1 = 2;     print $num . \"+\". $num1;     ?>",
        ///"option": [
        ///{
        ///"optionId": 78,
        ///"option": "3"
        ///},
        /// {
        ///"optionId": 79,
        ///"option": "1+2"
        ///},
        ///{
        ///"optionId": 80,
        ///"option": "1.+2."
        ///},
        ///{
        ///"optionId": 81,
        ///"option": "Error"
        ///}
        ///]
        ///}
        ///}
        ///}
        ///</returns>      

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





        /// <summary>
        /// url : http://localhost:55377/question/getbycat?CategoryId=20
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>
        /// {
        ///"success": true,
        ///"status": 200,
        ///"message": "questions",
        ///"data": {
        ///"questions": [
        ///{
        ///"questionId": 51,
        ///"question": "<?php     $num  = 1;     $num1 = 2;     print $num . \"+\". $num1;     ?>",
        ///"option": [
        ///{
        ///"optionId": 78,
        ///"option": "3"
        ///},
        ///{
        ///"optionId": 79,
        ///"option": "1+2"
        ///},
        ///{
        ///"optionId": 80,
        ///"option": "1.+2."
        ///},
        ///{
        ///"optionId": 81,
        ///"option": "Error"
        ///}
        ///]
        ///}
        ///]
        ///}
        ///}
        /// </returns>

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





        /// <summary>
        /// url : http://localhost:55377/question/getbycatandexp?CategoryId=20&ExperienceLevelId=21
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="experienceLevelId"></param>
        /// <returns>
        /// Same Body as above
        /// </returns>

        #region Get Question by Category and Experience

        [HttpGet]
        [Route("/question/getbycatandexp")]
        public IActionResult GetQuestionByCategoryAndExperience(int categoryId,
                                                                int experienceLevelId)
        {
            var question = questionAndOptionPresenter.GetQuestionByCategoryAndExperience(categoryId,
                                                                                         experienceLevelId);
            return helperMethode(question, "questions");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller
        }
        #endregion






        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="experienceLevelId"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        #region Get Question by Category and Experience And Number

        [HttpGet]
        [Route("/question/getbycatandexpandnum")]
        public IActionResult GetQuestionByCategoryAndExperienceAndNo(int categoryId,
                                                                     int experienceLevelId,
                                                                     int number)
        {
            var question = questionAndOptionPresenter.GetQuestionByCategoryAndExperienceAndNo(categoryId,
                                                                                              experienceLevelId,
                                                                                              number);
            return helperMethode(question, "questions");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller
        }
        #endregion








        /// <summary>
        /// http://localhost:55377/question/getbyshuffle?candidateId=44&number=7
        /// </summary>
        /// <param name="candidateId"></param>
        /// <param name="number"></param>
        /// <returns>
        /// Get shuffling question
        /// </returns>
        #region Get Question By Shuffling
        [AllowAnonymous]
        [HttpPost]
        [Route("/question/getbyshuffle")]
        public IActionResult GetQuestionByCategoryAndExperienceAndNumberAndShuffling(int candidateId,
                                                                                     int number)
        {
            var question = questionAndOptionPresenter.GetQuestionByCategoryAndExperienceAndNumberAndShuffling(candidateId,
                                                                                                              number);
            return helperMethode(question, "questions");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller
        }
        #endregion





        /// <summary>
        /// url : http://localhost:55377/question/getquesbyid?id=44
        /// </summary>
        /// <returns>
        /// {
        ///"success": true,
        ///"status": 200,
        ///"message": "question",
        ///"data": {
        ///"question": {
        ///"questionId": 51,
        ///"question": "<?php     $num  = 1;     $num1 = 2;     print $num . \"+\". $num1;     ?>",
        ///"option": [
        ///{
        ///"optionId": 78,
        ///"option": "3"
        ///},
        /// {
        ///"optionId": 79,
        ///"option": "1+2"
        ///},
        ///{
        ///"optionId": 80,
        ///"option": "1.+2."
        ///},
        ///{
        ///"optionId": 81,
        ///"option": "Error"
        ///}
        ///]
        ///}
        ///}
        ///}
        ///</returns>      

        #region Get All question


        [HttpGet]
        [Route("/question/getquesbyrole")]
        public IActionResult GetAllByRole()
        {
            var allQuestion = questionAndOptionPresenter.GetAllByRole();
            return helperMethode(allQuestion, "questions");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller
        }
        #endregion



        [HttpGet]
        [Route("/question/getquestbyroleandid")]
        public IActionResult GetQuesByRoleAndId(int id)
        {
            var question = questionAndOptionPresenter.GetQuestionByRoleAndId(id);
            return helperMethode(question, "question");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller
        }


        [HttpGet]
        [Route("/question/questioncount")]
        public IActionResult NoOfQuestion()
        {
            var count = questionAndOptionPresenter.NoOfQuestion();
            return helperMethode(count, "count");
        }



    }
}