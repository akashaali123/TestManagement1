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
           var questionChanges =  _context.TblQuestion.Where(e => e.QuestionId == id).SingleOrDefault();
            if(questionChanges != null)
            {
               
                questionChanges.Description = questionAndOptionViewModel.question.Description;
                questionChanges.Type = questionAndOptionViewModel.question.Type;
                questionChanges.Time = questionAndOptionViewModel.question.Time;
                questionChanges.IsActive = questionAndOptionViewModel.question.IsActive;
               
            }
            var question = _context.TblQuestion.Attach(questionChanges);
            question.State = EntityState.Modified;
            _context.SaveChanges();

            //var optionChanges = _context.TblOption.Where(e => e.QuestionId == id).ToList();
            foreach (var item in questionAndOptionViewModel.option)
            {
                var optionChanges = _context.TblOption.Where(e => e.QuestionId == id).FirstOrDefault();
                if (optionChanges!=null)
                {

                    optionChanges.OptionDescription = item.OptionDescription;
                    optionChanges.Duration = item.Duration;
                    optionChanges.IsCorrect = item.IsCorrect;
                    optionChanges.IsActive = item.IsActive;
                         
                       
               }
            }
            _context.SaveChanges();
            return questionAndOptionViewModel;


        }







    }
}
