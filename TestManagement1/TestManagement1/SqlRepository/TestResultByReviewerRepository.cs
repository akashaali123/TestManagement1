using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagement1.SqlRepository;
using TestManagementCore.MyTriggerMethode;
using TestManagementCore.RepositoryInterface;
using TestManagementCore.ViewModel;

namespace TestManagementCore.SqlRepository
{
    public class TestResultByReviewerRepository : BaseRepository<TestResultByReviewerRepository>, ITestResultByReviewer
    {
        public TestResultByReviewerRepository(TestManagementContext context,
                                              ILogger<TestResultByReviewerRepository> logger,
                                              IHttpContextAccessor httpContextAccessor,
                                              TriggerClass trigger) : base(context,
                                                                           logger,
                                                                           httpContextAccessor,
                                                                           trigger)
        {

        }


        public List<TestResultViewModel> DisplayResultAllCandidate()
        {
            try
            {
                var categoryId = _context.TblVerifierCategoryAndRole
                    .Where(e => e.UserId == GetUserId())
                    .Select(x => x.CategoryId)
                    .SingleOrDefault();

                


                var test = _context.TblTest.Where(e => e.CategoryId == Convert.ToInt32(categoryId))
                                    .Select(x => new TestResultViewModel
                                    {
                                        candidateId = x.CandidateId,
                                        
                                        candidateName = _context.TblCandidate.Where(c => c.CandidateId == x.CandidateId)
                                                                             .Select(c => c.FirstName)
                                                                             .SingleOrDefault(),
                                        
                                        category = _context.TblCategory.Where(c => c.CategoryId == x.CategoryId)
                                                                       .Select(c => c.Name)
                                                                       .SingleOrDefault(),
                                        
                                        experienceLevel = _context.TblExperienceLevel.Where(e => e.Id == x.ExpLevelId)
                                                                                     .Select(e => e.Name)
                                                                                     .SingleOrDefault(),
                                        
                                        testDate = x.TestDate,
                                        testStatus = x.TestStatus,
                                        totalQuestion = x.TotalQuestion,
                                        attemptedQuestion = x.AttemptedQuestion,
                                        correctAnswer = x.CorrectAnswer,
                                        wrongQuestion = x.WrongAnswer,
                                        skippedQuestion = x.QuestionSkipped,
                                        percentage = x.Percentage,
                                        Duration = x.Duration

                                    })
                                    .ToList(); ;


                return test;

                #region Above Query Is replica of this comment code
                //var test = _context.TblTest
                //    .Where(e=>e.CategoryId == Convert.ToInt32(categoryId) )
                //    .Select(x => new TestResultMapModel//select statement give anonyms type so we map it in TestResultMapModel
                //    {                                  //which is pass as a parameter in helperMethode which implementation is below
                //        candidateId = x.CandidateId,
                //        CategoryId = x.CategoryId,
                //        ExpLevelId = x.ExpLevelId,
                //        testDate = x.TestDate,
                //        testStatus = x.TestStatus,
                //        totalQuestion = x.TotalQuestion,
                //        correctAnswer = x.CorrectAnswer,
                //        wrongQuestion = x.WrongAnswer,
                //        skippedQuestion = x.QuestionSkipped,
                //        attemptedQuestion = x.AttemptedQuestion,
                //        percentage = x.Percentage,
                //        Duration = x.Duration
                //    })
                //    .ToList();

                //return helperMethode(test);
                #endregion




            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultByReviewerRepository DisplayResultAllCandidate Methode in Sql Repository" + ex);
                return null;
            }


        }





        public TestResultViewModel DisplayResultcandidateById(int candidateId)
        {

            try
            {
                //get category Id of Test
                var categoryId = _context.TblVerifierCategoryAndRole
                    .Where(e => e.UserId == GetUserId())
                    .Select(x => x.CategoryId)
                    .SingleOrDefault();


                var test = _context.TblTest.Where(x => x.CandidateId == candidateId &&
                                                    x.CategoryId == Convert.ToInt32(categoryId))
                                     .Select(x => new TestResultViewModel
                                     {
                                         candidateId = x.CandidateId,

                                         candidateName = _context.TblCandidate.Where(c => c.CandidateId == x.CandidateId)
                                                                             .Select(c => c.FirstName)
                                                                             .SingleOrDefault(),

                                         category = _context.TblCategory.Where(c => c.CategoryId == x.CategoryId)
                                                                       .Select(c => c.Name)
                                                                       .SingleOrDefault(),

                                         experienceLevel = _context.TblExperienceLevel.Where(e => e.Id == x.ExpLevelId)
                                                                                     .Select(e => e.Name)
                                                                                     .SingleOrDefault(),

                                         testDate = x.TestDate,
                                         testStatus = x.TestStatus,
                                         totalQuestion = x.TotalQuestion,
                                         attemptedQuestion = x.AttemptedQuestion,
                                         correctAnswer = x.CorrectAnswer,
                                         wrongQuestion = x.WrongAnswer,
                                         skippedQuestion = x.QuestionSkipped,
                                         percentage = x.Percentage,
                                         Duration = x.Duration
                                     })
                                     .SingleOrDefault();



                return test;


                #region above query is replica of the comment code

                //var test = _context.TblTest
                //    .Where(e => e.CandidateId == candidateId &&
                //                e.CategoryId ==Convert.ToInt32(categoryId))
                //    .Select(x => new
                //    {
                //        x.CandidateId,
                //        x.CategoryId,
                //        x.ExpLevelId,
                //        x.TestDate,
                //        x.TestStatus,
                //        x.TotalQuestion,
                //        x.CorrectAnswer,
                //        x.WrongAnswer,
                //        x.QuestionSkipped,
                //        x.AttemptedQuestion,
                //        x.Percentage,
                //        x.Duration
                //    })
                //    .SingleOrDefault();


                //TestResultViewModel model = new TestResultViewModel();

                //var candidate = _context.TblCandidate.Where(e => e.CandidateId == test.CandidateId)
                //    .Select(x => new
                //    {
                //        x.FirstName,
                //        x.CandidateId
                //    })
                //    .SingleOrDefault();


                //model.candidateName = candidate.FirstName;
                //model.candidateId = candidate.CandidateId;

                //string categoryName = _context.TblCategory.Where(e => e.CategoryId == test.CategoryId)
                //    .Select(x => x.Name)
                //    .SingleOrDefault();


                //model.category = categoryName;

                //string experience = _context.TblExperienceLevel.Where(e => e.Id == test.ExpLevelId)
                //    .Select(x => x.Name)
                //    .SingleOrDefault();


                //model.experienceLevel = experience;



                //model.testDate = test.TestDate;
                //model.testStatus = test.TestStatus;
                //model.totalQuestion = test.TotalQuestion;
                //model.attemptedQuestion = test.AttemptedQuestion;
                //model.skippedQuestion = test.QuestionSkipped;
                //model.wrongQuestion = test.WrongAnswer;
                //model.correctAnswer = test.CorrectAnswer;
                //model.percentage = test.Percentage;
                //model.Duration = test.Duration;




                //return model;
                #endregion

            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultByReviewerRepository DisplayResultcandidateById Methode in Sql Repository" + ex);
                return null;
            }


        }



        public List<TestQuestionOptionViewModel> DisplayCandidateQuestion(int candidateId)
        {
            try
            {
                var vmList = new List<TestQuestionOptionViewModel>();//Initialize the List of ViewModel Which Return

                //Find Record of Candidate and select its question Id , correct option id and question Id
                var test = _context.TblTestDetails
                                                .Where(e => e.CandidateId == candidateId)
                                                .Select(x => new 
                                                { 
                                                    x.QuestionId,
                                                    x.SelectedOptionId,
                                                    x.CorrectOptionId
                                                })
                                                .ToList();


                foreach (var item in test)
                {


                    /*################################### For Finding of the Attempted Question ############################*/


                    //Initialize Model 
                    TestQuestionOptionViewModel model = new TestQuestionOptionViewModel();


                    //Find Question Which is attempted by Candidate
                    model.Description = _context.TblQuestion.Where(e => e.QuestionId == item.QuestionId)
                                                             .Select(x => x.Description)
                                                             .SingleOrDefault();






                    /*############################# For Finding of the Attempted Question Option ##########################*/


                    //Find Option Of Candidate Attempted Question
                    var options = _context.TblOption.Where(e => e.QuestionId == item.QuestionId)
                                                    .Select(x => x.OptionDescription)
                                                    .ToList();





                    //Set List Of Option In ViewModel List options
                    model.option = options;







                    /*##################################### For Finding Selected Option ###################################*/



                    //Get selected Option Id for each Question which is attempted by candidate and parse into array
                    int[] selectOption = Array.ConvertAll(item.SelectedOptionId.Split(','), s => int.Parse(s));




                    //Initialize the List of Select optionList in which we add the option of selected by candidate 
                    List<string> selectOptionList = new List<string>();



                    // Loop is required because sometime candidate select multiple Question
                    foreach (var selectoption in selectOption)
                    {


                        //Find the option which is select by candidate One by one
                        var option = _context.TblOption.Where(e => e.OptionId == selectoption)
                                                       .Select(x => x.OptionDescription)
                                                       .SingleOrDefault();


                        //And add them in  select option List
                        selectOptionList.Add(option);


                    }


                    //We make a viewModel of TestQuestionOptionViewModel in which we declare selectOption List type variable
                    //so we have a selected option in select optionList which is assigning in TestQuestionOptionViewModel 
                    //select List Option
                    model.selectOption = selectOptionList;





                    /*##################################### For Finding Correct Option ######################################*/




                    //Get Correct Option Id for each Question which is attempted by candidate and parse into array
                    int[] correctOption = Array.ConvertAll(item.CorrectOptionId.Split(','), s => int.Parse(s));




                    //Initialize the List of Select correctOptionList in which we add the option which is correct 
                    List<string> correctOptionList = new List<string>();



                    // Loop is required because sometime multiple option set to correct
                    foreach (var correctoption in correctOption)
                    {


                        //Find the option which is correct One by One
                        var option = _context.TblOption.Where(e => e.OptionId == correctoption)
                                                       .Select(x => x.OptionDescription)
                                                       .SingleOrDefault();


                        //And add them in  correct Option List
                        correctOptionList.Add(option);


                    }


                    //We make a viewModel of TestQuestionOptionViewModel in which we declare correctOption List type variable
                    //so we have a correct option in correctOptionList which is assigning in TestQuestionOptionViewModel 
                    //correctListOption
                    model.correctOption = correctOptionList;







                    //return List
                    vmList.Add(model);


                }


                return vmList;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultByReviewerRepository DisplayCandidateQuestion Methode in Sql Repository" + ex);
                return null;
            }
            
        }








        public List<TestResultViewModel> DisplayResultbyDate(DateTime fromDate, DateTime toDate)
        {
            try
            {


                var categoryId = _context.TblVerifierCategoryAndRole
                                         .Where(e => e.UserId == GetUserId())
                                         .Select(x => x.CategoryId)
                                         .SingleOrDefault();



                var test = _context.TblTest
                                   .Where(e => e.TestDate >= fromDate)
                                   .Where(e => e.TestDate <= toDate)
                                   .Where(e => e.CategoryId == Convert.ToInt32(categoryId))
                                   .Select(x =>new TestResultViewModel //select statement give anonyms type so we map it in TestResultMapModel
                                   {
                                       candidateId = x.CandidateId,

                                       candidateName = _context.TblCandidate.Where(c => c.CandidateId == x.CandidateId)
                                                                            .Select(c => c.FirstName)
                                                                            .SingleOrDefault(),

                                       category = _context.TblCategory.Where(c => c.CategoryId == x.CategoryId)
                                                                      .Select(c => c.Name)
                                                                      .SingleOrDefault(),

                                       experienceLevel = _context.TblExperienceLevel.Where(e => e.Id == x.ExpLevelId)
                                                                                    .Select(e => e.Name)
                                                                                    .SingleOrDefault(),

                                       testDate = x.TestDate,
                                       testStatus = x.TestStatus,
                                       totalQuestion = x.TotalQuestion,
                                       attemptedQuestion = x.AttemptedQuestion,
                                       correctAnswer = x.CorrectAnswer,
                                       wrongQuestion = x.WrongAnswer,
                                       skippedQuestion = x.QuestionSkipped,
                                       percentage = x.Percentage,
                                       Duration = x.Duration
                                   })
                                   .ToList();


                return test;

                #region above code is a replica of comment code
                //Map anonyms methode to TestResultMap which is pass in parameter                              
                //Use For Between data
                //var test = _context.TblTest
                //    .Where(e => e.TestDate >= fromDate)
                //    .Where(e => e.TestDate <= toDate)
                //    .Where(e=>e.CategoryId == Convert.ToInt32(categoryId))
                //    .Select(x =>
                //    new TestResultMapModel //select statement give anonyms type so we map it in TestResultMapModel
                //    {
                //        candidateId = x.CandidateId,
                //        CategoryId = x.CategoryId,
                //        ExpLevelId = x.ExpLevelId,
                //        testDate = x.TestDate,
                //        testStatus = x.TestStatus,
                //        totalQuestion = x.TotalQuestion,
                //        correctAnswer = x.CorrectAnswer,
                //        wrongQuestion = x.WrongAnswer,
                //        skippedQuestion = x.QuestionSkipped,
                //        attemptedQuestion = x.AttemptedQuestion,
                //        percentage = x.Percentage,
                //        Duration = x.Duration
                //    })
                //    .ToList();

                //return helperMethode(test);
                #endregion


            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultByReviewerRepository DisplayResultbyDate Methode in Sql Repository" + ex);
                return null;
            }


        }


        public List<TestResultViewModel> DisplayResultbyPercentage()
        {
            try
            {

                var categoryId = _context.TblVerifierCategoryAndRole
                  .Where(e => e.UserId == GetUserId())
                  .Select(x => x.CategoryId)
                  .SingleOrDefault();

                var test = _context.TblTest
                             .Where(e => e.CategoryId == Convert.ToInt32(categoryId))
                             .Select(x => new TestResultViewModel //select statement give anonyms type so we map it in TestResultMapModel
                             {
                                 candidateId = x.CandidateId,

                                 candidateName = _context.TblCandidate.Where(c => c.CandidateId == x.CandidateId)
                                                                      .Select(c => c.FirstName)
                                                                      .SingleOrDefault(),

                                 category = _context.TblCategory.Where(c => c.CategoryId == x.CategoryId)
                                                                .Select(c => c.Name)
                                                                .SingleOrDefault(),

                                 experienceLevel = _context.TblExperienceLevel.Where(e => e.Id == x.ExpLevelId)
                                                                              .Select(e => e.Name)
                                                                              .SingleOrDefault(),

                                 testDate = x.TestDate,
                                 testStatus = x.TestStatus,
                                 totalQuestion = x.TotalQuestion,
                                 attemptedQuestion = x.AttemptedQuestion,
                                 correctAnswer = x.CorrectAnswer,
                                 wrongQuestion = x.WrongAnswer,
                                 skippedQuestion = x.QuestionSkipped,
                                 percentage = x.Percentage,
                                 Duration = x.Duration
                             })
                             .OrderByDescending(x => x.percentage)
                             .ToList();



                return test;

                #region above query is replica of comment code
                //var test = _context.TblTest
                //               .Where(e=>e.CategoryId ==Convert.ToInt32(categoryId))
                //               .Select(x => new TestResultMapModel //select statement give anonyms type so we map it in TestResultMapModel
                //               {
                //                   candidateId = x.CandidateId,
                //                   CategoryId = x.CategoryId,
                //                   ExpLevelId = x.ExpLevelId,
                //                   testDate = x.TestDate,
                //                   testStatus = x.TestStatus,
                //                   totalQuestion = x.TotalQuestion,
                //                   correctAnswer = x.CorrectAnswer,
                //                   wrongQuestion = x.WrongAnswer,
                //                   skippedQuestion = x.QuestionSkipped,
                //                   attemptedQuestion = x.AttemptedQuestion,
                //                   percentage = x.Percentage,
                //                   Duration = x.Duration
                //               })
                //               .OrderByDescending(x => x.percentage)
                //               .ToList();



                //return helperMethode(test);
                #endregion


            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultRepository DisplayResultbyPercentage Methode in Sql Repository" + ex);
                return null;
            }


        }


        public List<TestResultViewModel> DisplayResultbyTop10Percentage()
        {

            try
            {
                var categoryId = _context.TblVerifierCategoryAndRole
                 .Where(e => e.UserId == GetUserId())
                 .Select(x => x.CategoryId)
                 .SingleOrDefault();

                var test = _context.TblTest
                                  .Where(e => e.CategoryId == Convert.ToInt32(categoryId))
                                  .Select(x => new TestResultViewModel  //select statement give anonyms type so we map it in TestResultMapModel
                                  {
                                      candidateId = x.CandidateId,

                                      candidateName = _context.TblCandidate.Where(c => c.CandidateId == x.CandidateId)
                                                                           .Select(c => c.FirstName)
                                                                           .SingleOrDefault(),

                                      category = _context.TblCategory.Where(c => c.CategoryId == x.CategoryId)
                                                                     .Select(c => c.Name)
                                                                     .SingleOrDefault(),

                                      experienceLevel = _context.TblExperienceLevel.Where(e => e.Id == x.ExpLevelId)
                                                                                   .Select(e => e.Name)
                                                                                   .SingleOrDefault(),

                                      testDate = x.TestDate,
                                      testStatus = x.TestStatus,
                                      totalQuestion = x.TotalQuestion,
                                      attemptedQuestion = x.AttemptedQuestion,
                                      correctAnswer = x.CorrectAnswer,
                                      wrongQuestion = x.WrongAnswer,
                                      skippedQuestion = x.QuestionSkipped,
                                      percentage = x.Percentage,
                                      Duration = x.Duration
                                  })
                                  .OrderByDescending(x => x.percentage)
                                  .Take(10)
                                  .ToList();

                return test;

                #region above query is replica of comment code
                //var test = _context.TblTest
                //                   .Where(e => e.CategoryId == Convert.ToInt32(categoryId))
                //                   .Select(x => new TestResultMapModel  //select statement give anonyms type so we map it in TestResultMapModel
                //                   {
                //                       candidateId = x.CandidateId,
                //                       CategoryId = x.CategoryId,
                //                       ExpLevelId = x.ExpLevelId,
                //                       testDate = x.TestDate,
                //                       testStatus = x.TestStatus,
                //                       totalQuestion = x.TotalQuestion,
                //                       correctAnswer = x.CorrectAnswer,
                //                       wrongQuestion = x.WrongAnswer,
                //                       skippedQuestion = x.QuestionSkipped,
                //                       attemptedQuestion = x.AttemptedQuestion,
                //                       percentage = x.Percentage,
                //                       Duration = x.Duration
                //                   })
                //                   .OrderByDescending(x => x.percentage)
                //                   .Take(10)
                //                   .ToList();

                //return helperMethode(test);
                #endregion



            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultRepository DisplayResultbyTop10Percentage Methode in Sql Repository" + ex);
                return null;

            }


        }



        public List<TestResultViewModel> DisplayResultbyTop10TestStatus(string status)
        {
            try
            {

                var categoryId = _context.TblVerifierCategoryAndRole
                .Where(e => e.UserId == GetUserId())
                .Select(x => x.CategoryId)
                .SingleOrDefault();

                var test = _context.TblTest
                    .Where(e => e.TestStatus == status && e.CategoryId == Convert.ToInt32(categoryId))
                    .Select(x => new TestResultViewModel  //select statement give anonyms type so we map it in TestResultMapModel
                    {
                        candidateId = x.CandidateId,

                        candidateName = _context.TblCandidate.Where(c => c.CandidateId == x.CandidateId)
                                                             .Select(c => c.FirstName)
                                                             .SingleOrDefault(),

                        category = _context.TblCategory.Where(c => c.CategoryId == x.CategoryId)
                                                       .Select(c => c.Name)
                                                       .SingleOrDefault(),

                        experienceLevel = _context.TblExperienceLevel.Where(e => e.Id == x.ExpLevelId)
                                                                     .Select(e => e.Name)
                                                                     .SingleOrDefault(),

                        testDate = x.TestDate,
                        testStatus = x.TestStatus,
                        totalQuestion = x.TotalQuestion,
                        attemptedQuestion = x.AttemptedQuestion,
                        correctAnswer = x.CorrectAnswer,
                        wrongQuestion = x.WrongAnswer,
                        skippedQuestion = x.QuestionSkipped,
                        percentage = x.Percentage,
                        Duration = x.Duration
                    })
                    .Take(10)
                    .ToList();


                return test;

                #region above query is replica of comment code
                //var test = _context.TblTest
                //    .Where(e => e.TestStatus == status && e.CategoryId == Convert.ToInt32(categoryId))
                //    .Select(x => new TestResultMapModel  //select statement give anonyms type so we map it in TestResultMapModel
                //    {
                //        candidateId = x.CandidateId,
                //        CategoryId = x.CategoryId,
                //        ExpLevelId = x.ExpLevelId,
                //        testDate = x.TestDate,
                //        testStatus = x.TestStatus,
                //        totalQuestion = x.TotalQuestion,
                //        correctAnswer = x.CorrectAnswer,
                //        wrongQuestion = x.WrongAnswer,
                //        skippedQuestion = x.QuestionSkipped,
                //        attemptedQuestion = x.AttemptedQuestion,
                //        percentage = x.Percentage,
                //        Duration = x.Duration
                //    })
                //    .Take(10)
                //    .ToList();


                //return helperMethode(test);
                #endregion


            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultRepository DisplayResultbyTop10TestStatus Methode in Sql Repository" + ex);
                return null;
            }



        }



        #region No in further Use it is used in comment code
        //public List<TestResultViewModel> helperMethode(List<TestResultMapModel> test)
        //{
        //    try
        //    {
        //        var result = new List<TestResultViewModel>();


        //        foreach (var item in test)
        //        {
        //            TestResultViewModel model = new TestResultViewModel();

        //            var candidate = _context.TblCandidate.Where(e => e.CandidateId == item.candidateId)
        //                .Select(x => new 
        //                { x.FirstName,
        //                  x.CandidateId
        //                })
        //                .SingleOrDefault();


        //            model.candidateName = candidate.FirstName;
        //            model.candidateId = candidate.CandidateId;

        //            string categoryName = _context.TblCategory.Where(e => e.CategoryId == item.CategoryId)
        //                .Select(x => x.Name)
        //                .SingleOrDefault();



        //            model.category = categoryName;

        //            string experience = _context.TblExperienceLevel.Where(e => e.Id == item.ExpLevelId)
        //                .Select(x => x.Name)
        //                .SingleOrDefault();



        //            model.experienceLevel = experience;

        //            model.testDate = item.testDate;
        //            model.testStatus = item.testStatus;
        //            model.totalQuestion = item.totalQuestion;
        //            model.attemptedQuestion = item.attemptedQuestion;
        //            model.skippedQuestion = item.skippedQuestion;
        //            model.wrongQuestion = item.wrongQuestion;
        //            model.correctAnswer = item.correctAnswer;
        //            model.percentage = item.percentage;
        //            model.Duration = item.Duration;

        //            result.Add(model);


        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {

        //        _logger.LogError("Error in TestResultByReviewerRepository helperMethode Methode in Sql Repository" + ex);
        //        return null;
        //    }
        // }
        #endregion




    }

}

