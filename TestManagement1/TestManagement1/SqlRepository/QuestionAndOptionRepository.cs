using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagement1.SqlRepository;
using TestManagementCore.RepositoryInterface;
using TestManagementCore.ViewModel;

namespace TestManagementCore.SqlRepository
{
    public class QuestionAndOptionRepository : BaseRepository<QuestionAndOptionRepository>, IQuestionAndOption
    {
        int counter = 0;

        public QuestionAndOptionRepository(TestManagementContext context, ILogger<QuestionAndOptionRepository> logger, IHttpContextAccessor httpContextAccessor) :base(context, logger, httpContextAccessor)
        {

        }
        public QuestionAndOptionViewModel Add(QuestionAndOptionViewModel model)
        {
            try
            {
                _context.TblQuestion.Add(model.question);
                _context.SaveChanges();

                int questionId = _context.TblQuestion.Max(item => item.QuestionId);

                foreach (var item in model.option)
                {
                    item.QuestionId = questionId;
                    _context.TblOption.AddRange(model.option);

                }

                _context.SaveChanges();
                return model;
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in QuestionAndOptionRepository  Add Methode in Sql Repository" + ex);

                return null;
            }
          
           
        }

        public TblQuestion Delete(int id)
        {

            try
            {
                var question = _context.TblQuestion.Find(id);
                _context.TblQuestion.Remove(question);

                // var option = _context.TblLogging.Find(e=>e.);
                var option = _context.TblOption.Where(e => e.QuestionId == id).ToList();
                _context.TblOption.RemoveRange(option);

                _context.SaveChanges();

                return question;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in QuestionAndOptionRepository  Delete Methode in Sql Repository" + ex);

                return null;

            }
           

        }

        public IEnumerable<QuestionAndOptionViewModel> GetAll()
        {
            


            throw new NotImplementedException();
        }

        
        
        
        
        public QuestionAndOptionViewModel Update(QuestionAndOptionViewModel questionAndOptionViewModel, int id)
        {
            try
            {
                var questionChanges = _context.TblQuestion.Where(e => e.QuestionId == id).SingleOrDefault();
                if (questionChanges != null)
                {

                    questionChanges.Description = questionAndOptionViewModel.question.Description;
                    questionChanges.Type = questionAndOptionViewModel.question.Type;
                    questionChanges.Time = questionAndOptionViewModel.question.Time;
                    questionChanges.IsActive = questionAndOptionViewModel.question.IsActive;

                }
                var question = _context.TblQuestion.Attach(questionChanges);
                question.State = EntityState.Modified;
                _context.SaveChanges();//Question Updated


                //var optionChanges = _context.TblOption.Where(e => e.QuestionId == id).ToList();
                foreach (var item in questionAndOptionViewModel.option) //get value from Model 
                {
                    //select all the option of the question and save in a list
                    var optionChanges = _context.TblOption.Where(e => e.QuestionId == id).ToList();

                    for (int i = 0; i < optionChanges.Count - 1;)
                    {
                        //save the entity for CounterIndex option
                        optionChanges[counter].OptionDescription = item.OptionDescription;
                        optionChanges[counter].Duration = item.Duration;
                        optionChanges[counter].IsCorrect = item.IsCorrect;
                        optionChanges[counter].IsActive = item.IsActive;
                        break;
                    }
                    counter++; //Increment in counter to get the next element of list
                    _context.SaveChanges();
                }

                return questionAndOptionViewModel;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in QuestionAndOptionRepository update Methode in Sql Repository" + ex);

                return null;
            }
          
        }
        public QuestionOptionByIdViewModel GetQuestionById(int id)
        {

          QuestionOptionByIdViewModel model = new  QuestionOptionByIdViewModel();

            var question = _context.TblQuestion.Find(id);
            
                
                model.Description = question.Description;
                
                
            
            

            var option = _context.TblOption.Where(e => e.QuestionId == id);
            foreach (var item in option)
            {
                model.option = item.OptionDescription;
               
            }
            return model;
           
        }






    }
}
