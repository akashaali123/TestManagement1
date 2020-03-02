using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagement1.SqlRepository;
using TestManagementCore.Extension;//For Shuffling
using TestManagementCore.MyTriggerMethode;
using TestManagementCore.RepositoryInterface;
using TestManagementCore.ViewModel;
//using TestManagementCore.SessionManager;

namespace TestManagementCore.SqlRepository
{
    public class QuestionAndOptionRepository : BaseRepository<QuestionAndOptionRepository>, IQuestionAndOption
    {
        

        


        public QuestionAndOptionRepository(TestManagementContext context,
                                           ILogger<QuestionAndOptionRepository> logger,
                                           IHttpContextAccessor httpContextAccessor,
                                           TriggerClass trigger) :base(context,
                                                                       logger,
                                                                       httpContextAccessor,
                                                                       trigger)
        {

        }



        public QuestionAndOptionViewModel Add(QuestionAndOptionViewModel model)
        {

            //For transaction
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {

                    model.question.CreatedBy = GetUserId(); //set userid in created by
                    model.question.CreatedDate = DateTime.Today;//set date in created date

                  


                    model.question.Roleid = GetRoleId(); //set role in question RoleId

                    _context.TblQuestion.Add(model.question);//add question
                    _context.SaveChanges();

                   


                    foreach (var item in model.option)
                    {
                        item.QuestionId = model.question.QuestionId;
                        _context.TblOption.AddRange(model.option);

                    }

                  _context.SaveChanges();
                    
                    

                    //If all option and question add transaction commit
                    transaction.Commit();
                    
                    return model;
                }
                catch (Exception ex)
                {

                    _logger.LogError("Error in QuestionAndOptionRepository  Add Methode in Sql Repository" + ex);
                    transaction.Rollback();
                    return null;
                }
            }

           
          
           
        }

      
        
        
        
        public bool Delete(int id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var question = _context.TblQuestion.Find(id);
                    _context.TblQuestion.Remove(question);

                    
                    var option = _context.TblOption.Where(e => e.QuestionId == id).ToList();
                    _context.TblOption.RemoveRange(option);

                    _context.SaveChanges();
                    
                    transaction.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error in QuestionAndOptionRepository  Delete Methode in Sql Repository" + ex);
                    
                    transaction.Rollback();
                    
                    return false;

                }
            }            
           
        }

        public List<AllQuestionViewModel> GetAllByRole()
        {
            try
            {

                //Get question by role and with category
                var question = _context.TblQuestion
                                       .Where(e => e.Roleid == GetRoleId() &&
                                                    e.CreatedBy == GetUserId())
                                       .Select(x => new AllQuestionViewModel
                                       {
                                           questionId = x.QuestionId,
                                           question = x.Description,
                                           category = _context.TblCategory.Where(e => e.CategoryId == x.CategoryId)
                                                                          .Select(e => e.Name)
                                                                          .SingleOrDefault()

                                       })
                                       .ToList();


                return question;

                #region Return through List and find category and option which contain loop 

                //var vmList = new List<AllQuestionViewModel>();//list object

                ////get only those question which is created by user 
                //var question = _context.TblQuestion
                //                       .Where(e => e.Roleid == GetRoleId() && 
                //                                    e.CreatedBy == GetUserId())
                //                       .ToList();



                //foreach (var item in question)
                //{
                //    AllQuestionViewModel model = new AllQuestionViewModel();//Object of vm


                //    //all Option regarding their Question
                //    //var option = _context.TblOption.Where(e => e.QuestionId == item.QuestionId)
                //    //    .Select(x => new OptionViewModel 
                //    //    {
                //    //        optionId = x.OptionId,
                //    //        option = x.OptionDescription 
                //    //    })
                //    //    .ToList();




                //    model.questionId = item.QuestionId;
                //    model.question = item.Description;// Question set to model question item have current iterate question

                //    //model.option = option;//Option set in model option

                //    vmList.Add(model);//add model in list         

                //}
                //// vmList.Shuffle(); For Shuffling
                //return vmList;

                #endregion



            }
            catch (Exception ex)
            {

                _logger.LogError("Error in QuestionAndOptionRepository  GetAll Methode in Sql Repository" + ex);

                return null;
            }

        }



        public QuestionOptionByIdViewModel GetQuestionByRoleAndId(int id)
        {
            try
            {
                //var question = _context.TblQuestion.Find(id);//get Question

                var question = _context.TblQuestion.Where(e => e.QuestionId == id && 
                                                               e.Roleid == GetRoleId() && 
                                                               e.CreatedBy == GetUserId())
                                                    .Select(x => new
                                                    {
                                                        x.Description,
                        
                                                        x.QuestionId
                                                    })
                                                    .SingleOrDefault();


               
                var options = _context.TblOption.Where(x => x.QuestionId == id)
                                                .Select(x => new OptionViewModel
                                                {
                                                    optionId = x.OptionId,
                                                    option = x.OptionDescription
                                                })
                                                .ToList();//get option assign to option



                QuestionOptionByIdViewModel model = new QuestionOptionByIdViewModel();//instantiate class
                model.questionId = question.QuestionId;
                model.question = question.Description;//assign question in vm question 

                model.option = options;//assign option in vm option



                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in QuestionAndOptionRepository GetQuestionById Methode in Sql Repository" + ex);

                return null;

            }


        }










        public List<AllQuestionViewModel> GetAll()
        {
            try
            {
                //Get all question and their Respective Category
                var question = _context.TblQuestion
                   .Select(x => new AllQuestionViewModel
                   {
                       question = x.Description,
                       questionId = x.QuestionId,
                       category = _context.TblCategory.Where(e => e.CategoryId == x.CategoryId)
                       .Select(x => x.Name)
                       .SingleOrDefault()
                   })
                   .ToList();

                return question;


                #region Return through List and find category and option which contain loop  
                //var vmList = new List<AllQuestionViewModel>();//list object



                //var question = _context.TblQuestion
                //                        .Select(x => new
                //                               {
                //                                x.QuestionId,
                //                                x.Description,
                //                                x.CategoryId
                //                                  })
                //                       .ToList();

                //foreach (var item in question)
                //{
                // AllQuestionViewModel model = new AllQuestionViewModel();//Object of vm



                //    //all Option regarding their Question
                //    


                //var option = _context.TblOption.Where(e => e.QuestionId == item.QuestionId)
                //    //    .Select(x => new OptionViewModel 
                //    //    { 
                //    //        optionId = x.OptionId,
                //    //        option = x.OptionDescription 
                //    //    })
                //    //    .ToList();


                //    //Get Category Of Question
                //    var category = _context.TblCategory.Where(e => e.CategoryId == item.CategoryId)
                //                                        .Select(x => x.Name)
                //                                        .SingleOrDefault();

                //    model.questionId = item.QuestionId;
                //    model.question = item.Description;// Question set to model question item have current iterate question
                //    model.category = category;


                //    //model.option = option;

                //    vmList.Add(model);//add model in list         

                //}



                //return vmList;
                #endregion



            }
            catch (Exception ex)
            {

                _logger.LogError("Error in QuestionAndOptionRepository  GetAll Methode in Sql Repository" + ex);

                return null;
            }


        }





       
        
        
        
        public QuestionAndOptionViewModel Update(QuestionAndOptionViewModel questionAndOptionViewModel,
                                                 int id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    ////get role id of current user
                    //var roleId = _context.UserRoles.Where(e => e.UserId == sessionManager.getSession("userid"))
                    //    .Select(x => x.RoleId)
                    //    .SingleOrDefault();




                    var questionChanges = _context.TblQuestion
                                                  .Where(e => e.QuestionId == id)
                                                  .SingleOrDefault();


                    if (questionChanges != null)
                    {

                        questionChanges.Description = questionAndOptionViewModel.question.Description;
                        questionChanges.Type = questionAndOptionViewModel.question.Type;
                        questionChanges.Time = questionAndOptionViewModel.question.Time;
                        questionChanges.IsActive = questionAndOptionViewModel.question.IsActive;
                        questionChanges.ExperienceLevelId = questionAndOptionViewModel.question.ExperienceLevelId;
                        questionChanges.CategoryId = questionAndOptionViewModel.question.CategoryId;

                        questionChanges.CreatedBy = GetUserId();
                        questionChanges.CreatedDate = DateTime.Today;
                        questionChanges.UpdatedBy = GetUserId();
                        questionChanges.UpdatedDate = DateTime.Today;
                        questionChanges.Roleid = GetRoleId();



                    }
                    var question = _context.TblQuestion.Attach(questionChanges);
                    question.State = EntityState.Modified;
                    _context.SaveChanges();//Question Updated

                    int counter = 0;

                    //var optionChanges = _context.TblOption.Where(e => e.QuestionId == id).ToList();
                    foreach (var item in questionAndOptionViewModel.option) //get value from Model 
                    {
                        //select all the option of the question and save in a list
                        var optionChanges = _context.TblOption.Where(e => e.QuestionId == id)
                                                              .ToList();

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
                    transaction.Commit();
                    
                    return questionAndOptionViewModel;
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error in QuestionAndOptionRepository update Methode in Sql Repository" + ex);
                    transaction.Rollback();
                    return null;
                }
            }
                
          
        }
       
        
        
        
        
        public QuestionOptionByIdViewModel GetQuestionById(int id)
        {
            try
            {
                //var question = _context.TblQuestion.Find(id);//get Question

                var question = _context.TblQuestion.Where(e=>e.QuestionId == id)
                                                    .Select(x=> new 
                                                    { 
                                                        x.Description
                                                        ,x.QuestionId
                                                    })
                                                    .SingleOrDefault();

               
                var options = _context.TblOption.Where(x => x.QuestionId == id)
                                                .Select(x => new OptionViewModel 
                                                { 
                                                    optionId = x.OptionId,
                                                    option = x.OptionDescription 
                                                })
                                                .ToList();//get option assign to option

               
                
                QuestionOptionByIdViewModel model = new QuestionOptionByIdViewModel();//instantiate class
                model.questionId = question.QuestionId;
                model.question= question.Description;//assign question in vm question 
                
                model.option = options;//assign option in vm option
                
               

                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in QuestionAndOptionRepository GetQuestionById Methode in Sql Repository" + ex);

                return null;

            }
           
            
        }

       
        
        
        
        public List<AllQuestionViewModel> GetQuestionByCategory(int categoryId)
        {
            try
            {
                
                var question = _context.TblQuestion.Where(e => e.CategoryId == categoryId)
                                                    .Select(x => new AllQuestionViewModel
                                                    {
                                                        questionId = x.QuestionId,
                                                        question = x.Description,
                                                        category = _context.TblCategory.Where(e => e.CategoryId == x.CategoryId).Select(x => x.Name).SingleOrDefault()
                                                    })
                                                   .ToList();

                return question;

                #region Above query replica of this comment code  except option work if we want to retrive option so we do
                //var questionList = new List<AllQuestionViewModel>();//For returning

                //var question = _context.TblQuestion.Where(e => e.CategoryId == categoryId)
                //    .Select(x => new
                //    {
                //        x.QuestionId,
                //        x.Description,
                //        x.CategoryId

                //    })
                //    .ToList();


                //foreach (var item in question)
                //{
                //    AllQuestionViewModel model = new AllQuestionViewModel();

                //    var category = _context.TblCategory.Where(e => e.CategoryId == item.CategoryId)
                //                                       .Select(x=>x.Name)
                //                                       .SingleOrDefault();

                //    model.questionId = item.QuestionId;
                //    model.question = item.Description;//item contain the iterated question
                //    model.category = category;




                //    //var option = _context.TblOption.Where(e => e.QuestionId == item.QuestionId)
                //    //                                .Select(x => new OptionViewModel 
                //    //                                { 
                //    //                                    optionId = x.OptionId, 
                //    //                                    option = x.OptionDescription 
                //    //                                })
                //    //                                .ToList();


                //    //model.option = option;//set list of option in vm model option list



                //    questionList.Add(model);
                //}
                //return questionList;
                #endregion


            }
            catch (Exception ex)
            {

                _logger.LogError("Error in QuestionAndOptionRepository GetQuestionByCategory Methode in Sql Repository" + ex);

                return null;
            }
        }


        
        
        
        
        public List<AllQuestionViewModel> GetQuestionByCategoryAndExperience(int categoryId, 
                                                                             int experienceLevelId)
        {
            try
            {

                var question = _context.TblQuestion.Where(e => e.CategoryId == categoryId &&
                                                               e.ExperienceLevelId == experienceLevelId)
                                                    .Select(x => new AllQuestionViewModel
                                                    {
                                                        question = x.Description,
                                                        questionId = x.QuestionId,
                                                        category = _context.TblCategory.Where(e => e.CategoryId == x.CategoryId)
                                                                                       .Select(x => x.Name)
                                                                                       .SingleOrDefault()
                                                    })
                                                    .ToList();
                return question;

                #region  Above query replica of this comment code  except option work if we want to retrive option so we do
                //var questionList = new List<AllQuestionViewModel>();//For returning
                //var question = _context.TblQuestion.Where(e => e.CategoryId == categoryId && 
                //                                               e.ExperienceLevelId == experienceLevelId)
                //                                    .Select(x=> new
                //                                    {
                //                                        x.Description,
                //                                        x.QuestionId,
                //                                        x.CategoryId
                //                                    })
                //                                    .ToList();

                //foreach (var item in question)
                //{
                //    AllQuestionViewModel model = new AllQuestionViewModel();

                //    var category = _context.TblCategory.Where(e => e.CategoryId == item.CategoryId)
                //                                       .Select(x => x.Name)
                //                                       .SingleOrDefault();


                //    model.questionId = item.QuestionId;
                //    model.question = item.Description;//item contain the iterated question
                //    model.category = category;
                //    //var option = _context.TblOption.Where(e => e.QuestionId == item.QuestionId)
                //    //                                .Select(x => new OptionViewModel 
                //    //                                { 
                //    //                                    optionId = x.OptionId,
                //    //                                    option = x.OptionDescription 
                //    //                                })
                //    //                                .ToList();


                //    //model.option = option;//set list of option in vm model option list

                //    questionList.Add(model);
                //}
                //return questionList;
                #endregion


            }
            catch (Exception ex)
            {

                _logger.LogError("Error in QuestionAndOptionRepository GetQuestionByCategory Methode in Sql Repository" + ex);

                return null;
            }
        }


       
        
        
        
        public List<AllQuestionViewModel> GetQuestionByCategoryAndExperienceAndNo(int categoryId, 
                                                                                  int experienceLevelId, 
                                                                                  int number)
        {
            try
            {
                var question = _context.TblQuestion.Where(e => e.CategoryId == categoryId &&
                                                              e.ExperienceLevelId == experienceLevelId)
                                                   .Select(x => new AllQuestionViewModel
                                                   {
                                                       questionId = x.QuestionId,
                                                       question = x.Description,
                                                       category = _context.TblCategory.Where(e => e.CategoryId == x.CategoryId)
                                                                                      .Select(e => e.Name)
                                                                                      .SingleOrDefault()
                                                   })
                                                   .Take(number)
                                                   .ToList();

                return question;

                #region  Above query replica of this comment code  except option work if we want to retrive option so we do
                //var questionList = new List<AllQuestionViewModel>();//For returning
                //var question = _context.TblQuestion.Where(e => e.CategoryId == categoryId && 
                //                                               e.ExperienceLevelId == experienceLevelId)
                //                                    .Select(x=>new 
                //                                    {
                //                                        x.QuestionId,
                //                                        x.Description,
                //                                        x.CategoryId
                //                                    })
                //                                    .Take(number)
                //                                    .ToList();

                //foreach (var item in question)
                //{
                //    AllQuestionViewModel model = new AllQuestionViewModel();

                //    var category = _context.TblCategory.Where(e => e.CategoryId == item.CategoryId)
                //                                    .Select(x => x.Name)
                //                                    .SingleOrDefault();


                //    model.questionId = item.QuestionId;
                //    model.question = item.Description;//item contain the iterated question
                //    model.category = category;
                //    //var option = _context.TblOption.Where(e => e.QuestionId == item.QuestionId)
                //    //                                .Select(x => new OptionViewModel 
                //    //                                { 
                //    //                                    optionId = x.OptionId,
                //    //                                    option = x.OptionDescription 
                //    //                                })
                //    //                                .ToList();


                //    //model.option = option;//set list of option in vm model option list

                //    questionList.Add(model);
                //}

                //return questionList;
                #endregion


            }
            catch (Exception ex)
            {

                _logger.LogError("Error in QuestionAndOptionRepository GetQuestionByCategory Methode in Sql Repository" + ex);

                return null;
            }
        }


       
        
        
        
        public List<QuestionOptionByIdViewModel> GetQuestionByCategoryAndExperienceAndNumberAndShuffling(int candidateId,
                                                                                                         int number)
        {
            try
            {

                var candidate = _context.TblCandidate.Where(e => e.CandidateId == candidateId)
                                                     .Select(x=> new 
                                                     {
                                                          x.CategoryId,
                                                          x.ExperienceLevelId 
                                                     })
                                                     .SingleOrDefault();
               
                
                int? categoryId = candidate.CategoryId;
                int? experienceLevelId = candidate.ExperienceLevelId;





                var question = _context.TblQuestion.Where(e => e.CategoryId == categoryId &&
                                                               e.ExperienceLevelId == experienceLevelId &&
                                                               e.IsActive == true)
                                       .Select(x => new QuestionOptionByIdViewModel 
                                       { 
                                                questionId = x.QuestionId,
                                                question   =  x.Description,
                                                option = _context.TblOption.Where(e=>e.QuestionId == x.QuestionId)
                                                                 .Select(x=>new OptionViewModel
                                                                 { 
                                                                         optionId = x.OptionId,
                                                                         option = x.OptionDescription
                                                                 })
                                                                 .ToList()
                                                      
                                       })
                                       .OrderBy(r => Guid.NewGuid())
                                       .Take(number)
                                       .ToList();


                return question;

                #region above query modified form of this comment section
                //var questionList = new List<QuestionOptionByIdViewModel>();//For returning

                //to get random record

                //Random rand = new Random();
                //int toSkip = rand.Next(1, _context.TblQuestion
                //.Where(e => e.CategoryId == categoryId && e.ExperienceLevelId == experienceLevelId && e.IsActive == true)
                //.Count());



                //var question = _context.TblQuestion.Where(e => e.CategoryId == categoryId && 
                //                                               e.ExperienceLevelId == experienceLevelId && 
                //                                               e.IsActive == true)
                //                                   .Select(x => new { x.QuestionId, x.Description })
                //                                   .OrderBy(r=>Guid.NewGuid())
                //                                   .Take(number)
                //                                   .ToList();

                //foreach (var item in question)
                //{
                //    QuestionOptionByIdViewModel model = new QuestionOptionByIdViewModel();
                //    model.questionId = item.QuestionId;
                //    model.question = item.Description;//item contain the iterated question
                //    var option = _context.TblOption.Where(e => e.QuestionId == item.QuestionId)
                //                                   .Select(x => new OptionViewModel
                //                                   {
                //                                       optionId = x.OptionId,
                //                                       option = x.OptionDescription
                //                                   })
                //                                   .ToList();


                //    model.option = option;//set list of option in vm model option list
                //    questionList.Add(model);
                //}

                //questionList.Shuffle();
                //return questionList;

                #endregion

            }
            catch (Exception ex)
            {

                _logger.LogError("Error in QuestionAndOptionRepository GetQuestionByCategory Methode in Sql Repository" + ex);

                return null;
            }
        }







    }
}
