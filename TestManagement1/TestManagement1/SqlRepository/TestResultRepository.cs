using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagement1.SqlRepository;
using TestManagementCore.Extension;
using TestManagementCore.RepositoryInterface;
using TestManagementCore.ViewModel;

namespace TestManagementCore.SqlRepository
{
    public class TestResultRepository : BaseRepository<TestResultRepository>, ITestResult
    {
        public TestResultRepository(TestManagementContext context, ILogger<TestResultRepository> logger, IHttpContextAccessor httpContextAccessor) :base(context, logger, httpContextAccessor)
        {

        }

       
        
        public Dictionary<string,bool> AddResult(int candidateId)
        {
            try
            {
                var proceed = new Dictionary<string, bool>(); //Initialize Dictionary For return


                int totalQusetion = 0;
                int correctAnswer = 0;
                int skippedQuestion = 0;
                int wrongAnswer = 0;
                int attemptedQuestion = 0;
                double percentage = 0;
                double roundof = 0;//For round Of percentage

                //For avoid the duplicate Record of candidate
               int checkCandidate =  _context.TblTest.Where(e => e.CandidateId == candidateId)
                    .Select(x=>x.CandidateId)
                    .Count();

                //If test Not Found in TblTest than added 
                if (checkCandidate == 0) 
                {
                    var candidate = _context.TblCandidate.Find(candidateId);//First we find that candidate Register 
                    if (candidate != null)//If candidate not register so we did'nt save his result
                    {
                        //get their data of test Table
                        var test = _context.TblTestDetails.Where(e => e.CandidateId == candidateId)
                            .Select(x => new 
                            {
                                x.SelectedOptionId,
                                x.CorrectOptionId,
                                x.CandidateId 
                            });

                        foreach (var item in test)
                        {
                            //check candidate attempt the  Question
                            if (!string.IsNullOrEmpty(item.SelectedOptionId))
                            {
                                if (!string.IsNullOrEmpty(item.CorrectOptionId))
                                {
                                    //take the value of selected option In Array
                                    int[] selectOption = Array.ConvertAll(item.SelectedOptionId.Split(','), s => int.Parse(s));

                                    //take the value of Correct Option In Array 
                                    int[] correctOption = Array.ConvertAll(item.CorrectOptionId.Split(','), s => int.Parse(s));


                                    //Array ItemsEqual it is an extension methode to check the value of array is equal its implementation in Extension folder
                                    if (correctOption.ItemsEqual(selectOption))//Check selected option and correct option
                                    {
                                        correctAnswer++;//Increment in Correct question
                                    }
                                    else
                                    {
                                        wrongAnswer++;
                                    }
                                }
                                else
                                {
                                    //If admin not set the correct option 
                                    //Do Logic here
                                }

                            }
                            else
                            {
                                skippedQuestion++;//If  selectedOptionId in null so increment in skipped Question
                            }


                        }

                        totalQusetion = skippedQuestion + correctAnswer + wrongAnswer;

                        attemptedQuestion = correctAnswer + wrongAnswer;

                        percentage = (Convert.ToDouble(correctAnswer) / Convert.ToDouble(totalQusetion)) * 100;

                        roundof = Math.Round(percentage, 2);//roundOf the percentage

                        TblTest postTest = new TblTest
                        {

                            CandidateId = candidate.CandidateId,
                            CategoryId = candidate.CategoryId,
                            ExpLevelId = candidate.ExperienceLevelId,
                            TotalQuestion = totalQusetion,
                            AttemptedQuestion = attemptedQuestion,
                            Percentage = roundof,
                            CorrectAnswer = correctAnswer,
                            WrongAnswer = wrongAnswer,
                            QuestionSkipped = skippedQuestion,
                            Duration = null,
                            IsActive = true,
                            CreatedBy = null,
                            CreatedDate = DateTime.Today,/*DateTime.Now.ToString("dd/MM/yyyy")*/
                            UpdatedBy = null,
                            UpdatedDate = null,
                            TestDate = DateTime.Today,
                            
                             

                        };
                        
                        if(percentage > 50)
                        {
                            postTest.TestStatus = "Pass";
                        }
                        else
                        {
                            postTest.TestStatus = "Fail";
                        }

                        _context.TblTest.Add(postTest);
                        int result = _context.SaveChanges();
                        if (result != 0)
                        {
                            proceed.Add("Result", true);
                            return proceed;
                        }
                        else
                        {
                            proceed.Add("Result", false);
                            return proceed;
                        }



                    }
                    else
                    {
                        proceed.Add("Candidate Not Found", false);
                        return proceed;
                    }

                }
                else
                {
                    proceed.Add("Already Record Added",false);
                    return proceed;
                }

               
            }
            catch (Exception ex)
            {
              
                _logger.LogError("Error in TestResultRepository AddResult Methode in Sql Repository" + ex);

                var proceed = new Dictionary<string, bool>();
                proceed.Add("Exception Found",false);

                return proceed;
            }
            
        }

       
       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
        public List<TestResultViewModel> DisplayResultAllCandidate()
        {
            try
            {

                var test = _context.TblTest 
                    .Select(x => new TestResultMapModel//select statement give anonyms type so we map it in TestResultMapModel
                    {                                  //which is pass as a parameter in helperMethode which implementation is below
                        candidateId = x.CandidateId,
                        CategoryId=x.CategoryId,
                        ExpLevelId=x.ExpLevelId,
                        testDate=x.TestDate,
                        testStatus=x.TestStatus,
                        totalQuestion=x.TotalQuestion,
                        correctAnswer=x.CorrectAnswer,
                        wrongQuestion=x.WrongAnswer,
                        skippedQuestion=x.QuestionSkipped,
                        attemptedQuestion=x.AttemptedQuestion,
                        percentage=x.Percentage,
                        Duration=x.Duration
                    })
                    .ToList();


                return helperMethode(test);
                
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultRepository DisplayResultAllCandidate Methode in Sql Repository" + ex);
                 return null;
            }
                

        }


       






        public TestResultViewModel DisplayResultcandidateById(int candidateId)
        {

            try
            {
                var test = _context.TblTest.Where(e => e.CandidateId == candidateId)
                    .Select(x => new 
                    {
                        x.CandidateId,
                        x.CategoryId,
                        x.ExpLevelId,
                        x.TestDate,
                        x.TestStatus,
                        x.TotalQuestion,
                        x.CorrectAnswer,
                        x.WrongAnswer,
                        x.QuestionSkipped, 
                        x.AttemptedQuestion,
                        x.Percentage,
                        x.Duration 
                    })
                    .SingleOrDefault();


                TestResultViewModel model = new TestResultViewModel();

                var candidate = _context.TblCandidate.Where(e => e.CandidateId == test.CandidateId)
                    .Select(x => new
                    { 
                        x.FirstName,
                        x.CandidateId 
                    })
                    .SingleOrDefault();
               
                
                model.candidateName = candidate.FirstName;
                model.candidateId = candidate.CandidateId;

                string categoryName = _context.TblCategory.Where(e => e.CategoryId == test.CategoryId)
                    .Select(x => x.Name)
                    .SingleOrDefault();
               
                
                model.category = categoryName;

                string experience = _context.TblExperienceLevel.Where(e => e.Id == test.ExpLevelId)
                    .Select(x => x.Name)
                    .SingleOrDefault();
                
                
                model.experienceLevel = experience;

                
                
                model.testDate = test.TestDate;
                model.testStatus = test.TestStatus;
                model.totalQuestion = test.TotalQuestion;
                model.attemptedQuestion = test.AttemptedQuestion;
                model.skippedQuestion = test.QuestionSkipped;
                model.wrongQuestion = test.WrongAnswer;
                model.correctAnswer = test.CorrectAnswer;
                model.percentage = test.Percentage;
                model.Duration = test.Duration;




                return model;
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultRepository DisplayResultcandidateById Methode in Sql Repository" + ex);
                return null;
            }
          

        }



        public List<TestResultViewModel> DisplayResultbyDate(DateTime fromDate,DateTime toDate)
        {
            try
            {
                                                                                                                                 //Map anonyms methode to TestResultMap which is pass in parameter                              
                //Use For Between data
                var test = _context.TblTest
                    .Where(e => e.TestDate >= fromDate)
                    .Where(e => e.TestDate <= toDate).
                    Select(x => 
                    new TestResultMapModel //select statement give anonyms type so we map it in TestResultMapModel
                    {
                        candidateId = x.CandidateId,
                        CategoryId = x.CategoryId,
                        ExpLevelId = x.ExpLevelId,
                        testDate = x.TestDate,
                        testStatus = x.TestStatus,
                        totalQuestion = x.TotalQuestion,
                        correctAnswer = x.CorrectAnswer,
                        wrongQuestion = x.WrongAnswer,
                        skippedQuestion = x.QuestionSkipped,
                        attemptedQuestion = x.AttemptedQuestion,
                        percentage = x.Percentage,
                        Duration = x.Duration
                    })
                    .ToList();
                
                return helperMethode(test);
               
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultRepository DisplayResultbyDate Methode in Sql Repository" + ex);
                return null;
            }
           

        }


      
        
        
        public List<TestResultViewModel> DisplayResultbyPercentage()
        {
            try
            {
                var test = _context.TblTest
                               .Select(x => new TestResultMapModel //select statement give anonyms type so we map it in TestResultMapModel
                               {
                                   candidateId = x.CandidateId,
                                   CategoryId = x.CategoryId,
                                   ExpLevelId = x.ExpLevelId,
                                   testDate = x.TestDate,
                                   testStatus = x.TestStatus,
                                   totalQuestion = x.TotalQuestion,
                                   correctAnswer = x.CorrectAnswer,
                                   wrongQuestion = x.WrongAnswer,
                                   skippedQuestion = x.QuestionSkipped,
                                   attemptedQuestion = x.AttemptedQuestion,
                                   percentage = x.Percentage,
                                   Duration = x.Duration
                               })
                               .OrderByDescending(x => x.percentage).ToList();



                return helperMethode(test);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultRepository DisplayResultbyPercentage Methode in Sql Repository" + ex);
                return null;
            }
           
            
        }

        public List<TestResultViewModel> DisplayResultbyPercentageAndCategory(int categoryId)
        {
            try
            {
                var test = _context.TblTest.Where(e => e.CategoryId == categoryId)
               .Select(x => new TestResultMapModel //select statement give anonyms type so we map it in TestResultMapModel
               {
                   candidateId = x.CandidateId,
                   CategoryId = x.CategoryId,
                   ExpLevelId = x.ExpLevelId,
                   testDate = x.TestDate,
                   testStatus = x.TestStatus,
                   totalQuestion = x.TotalQuestion,
                   correctAnswer = x.CorrectAnswer,
                   wrongQuestion = x.WrongAnswer,
                   skippedQuestion = x.QuestionSkipped,
                   attemptedQuestion = x.AttemptedQuestion,
                   percentage = x.Percentage,
                   Duration = x.Duration
               })
               .OrderByDescending(x => x.percentage).ToList();



                return helperMethode(test);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultRepository DisplayResultbyPercentageAndCategory Methode in Sql Repository" + ex);
                return null;
            }
           
           
        }

        public List<TestResultViewModel> DisplayResultbyPercentageAndCategoryAndExperience(int categoryId,int experienceLevelId)
        {
            try
            {
                var test = _context.TblTest.Where(e => e.CategoryId == categoryId && e.ExpLevelId == experienceLevelId)
               .Select(x => new TestResultMapModel//select statement give anonyms type so we map it in TestResultMapModel
               {
                   candidateId = x.CandidateId,
                   CategoryId = x.CategoryId,
                   ExpLevelId = x.ExpLevelId,
                   testDate = x.TestDate,
                   testStatus = x.TestStatus,
                   totalQuestion = x.TotalQuestion,
                   correctAnswer = x.CorrectAnswer,
                   wrongQuestion = x.WrongAnswer,
                   skippedQuestion = x.QuestionSkipped,
                   attemptedQuestion = x.AttemptedQuestion,
                   percentage = x.Percentage,
                   Duration = x.Duration
               })
               .OrderByDescending(x => x.percentage).ToList();


                return helperMethode(test);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultRepository DisplayResultbyPercentageAndCategoryAndExperience Methode in Sql Repository" + ex);
                return null;
            }
           
           
        }



        public List<TestResultViewModel> DisplayResultbyPercentageAndExperience(int experienceId)
        {
            try
            {
                var test = _context.TblTest.Where(e => e.ExpLevelId == experienceId)
                               .Select(x => new TestResultMapModel//select statement give anonyms type so we map it in TestResultMapModel
                               {
                                   candidateId = x.CandidateId,
                                   CategoryId = x.CategoryId,
                                   ExpLevelId = x.ExpLevelId,
                                   testDate = x.TestDate,
                                   testStatus = x.TestStatus,
                                   totalQuestion = x.TotalQuestion,
                                   correctAnswer = x.CorrectAnswer,
                                   wrongQuestion = x.WrongAnswer,
                                   skippedQuestion = x.QuestionSkipped,
                                   attemptedQuestion = x.AttemptedQuestion,
                                   percentage = x.Percentage,
                                   Duration = x.Duration
                               })
                               .OrderByDescending(x => x.percentage)
                               .ToList();


                return helperMethode(test);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultRepository DisplayResultbyPercentageAndExperience Methode in Sql Repository" + ex);
                return null;
            }
           
           
        }



        public List<TestResultViewModel> DisplayResultbyCategory(int categoryId)
        {
            try
            {
                var test = _context.TblTest.Where(e => e.CategoryId == categoryId)
               .Select(x => new TestResultMapModel//select statement give anonyms type so we map it in TestResultMapModel
               {
                   candidateId = x.CandidateId,
                   CategoryId = x.CategoryId,
                   ExpLevelId = x.ExpLevelId,
                   testDate = x.TestDate,
                   testStatus = x.TestStatus,
                   totalQuestion = x.TotalQuestion,
                   correctAnswer = x.CorrectAnswer,
                   wrongQuestion = x.WrongAnswer,
                   skippedQuestion = x.QuestionSkipped,
                   attemptedQuestion = x.AttemptedQuestion,
                   percentage = x.Percentage,
                   Duration = x.Duration
               })
               .ToList();



                return helperMethode(test);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultRepository DisplayResultbyPercentageAndExperience Methode in Sql Repository" + ex);
                return null;
            }
           
            
        }



        public List<TestResultViewModel> DisplayResultbyExperience(int experienceId)
        {
            try
            {
                var test = _context.TblTest.Where(e => e.ExpLevelId == experienceId)
               .Select(x => new TestResultMapModel //select statement give anonyms type so we map it in TestResultMapModel
               {
                   candidateId = x.CandidateId,
                   CategoryId = x.CategoryId,
                   ExpLevelId = x.ExpLevelId,
                   testDate = x.TestDate,
                   testStatus = x.TestStatus,
                   totalQuestion = x.TotalQuestion,
                   correctAnswer = x.CorrectAnswer,
                   wrongQuestion = x.WrongAnswer,
                   skippedQuestion = x.QuestionSkipped,
                   attemptedQuestion = x.AttemptedQuestion,
                   percentage = x.Percentage,
                   Duration = x.Duration
               })
               .ToList();



                return helperMethode(test);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultRepository DisplayResultbyExperience Methode in Sql Repository" + ex);
                return null;
            }
           
           
           

        }


        public List<TestResultViewModel> DisplayResultbyCategoryAndExperience(int categoryId,int experienceId)
        {
            try
            {
                var test = _context.TblTest.Where(e => e.CategoryId == categoryId && e.ExpLevelId == experienceId)
                               .Select(x => new TestResultMapModel //select statement give anonyms type so we map it in TestResultMapModel
                               {
                                   candidateId = x.CandidateId,
                                   CategoryId = x.CategoryId,
                                   ExpLevelId = x.ExpLevelId,
                                   testDate = x.TestDate,
                                   testStatus = x.TestStatus,
                                   totalQuestion = x.TotalQuestion,
                                   correctAnswer = x.CorrectAnswer,
                                   wrongQuestion = x.WrongAnswer,
                                   skippedQuestion = x.QuestionSkipped,
                                   attemptedQuestion = x.AttemptedQuestion,
                                   percentage = x.Percentage,
                                   Duration = x.Duration
                               })
                               .ToList();

                return helperMethode(test);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultRepository DisplayResultbyCategoryAndExperience Methode in Sql Repository" + ex);
                return null;
            }
           
            
            
            
           
           

        }


        public List<TestResultViewModel> DisplayResultbyCategoryFromDate(int categoryId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var test = _context.TblTest
                     .Where(e => e.CategoryId == categoryId && (e.TestDate >= fromDate && e.TestDate <= toDate))
                     .Select(x => new TestResultMapModel //select statement give anonyms type so we map it in TestResultMapModel
                     {
                               candidateId = x.CandidateId,
                               CategoryId = x.CategoryId,
                               ExpLevelId = x.ExpLevelId,
                               testDate = x.TestDate,
                               testStatus = x.TestStatus,
                               totalQuestion = x.TotalQuestion,
                               correctAnswer = x.CorrectAnswer,
                               wrongQuestion = x.WrongAnswer,
                               skippedQuestion = x.QuestionSkipped,
                               attemptedQuestion = x.AttemptedQuestion,
                               percentage = x.Percentage,
                               Duration = x.Duration
                     })
                     .ToList();



                return helperMethode(test);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultRepository DisplayResultbyCategoryFromDate Methode in Sql Repository" + ex);
                return null;
            }
           
           

        }

        public List<TestResultViewModel> DisplayResultbyExpFromDate(int experienceId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var test = _context.TblTest
               .Where(e => e.ExpLevelId == experienceId && (e.TestDate >= fromDate && e.TestDate <= toDate))
               .Select(x => new TestResultMapModel //select statement give anonyms type so we map it in TestResultMapModel
                {
                   candidateId = x.CandidateId,
                   CategoryId = x.CategoryId,
                   ExpLevelId = x.ExpLevelId,
                   testDate = x.TestDate,
                   testStatus = x.TestStatus,
                   totalQuestion = x.TotalQuestion,
                   correctAnswer = x.CorrectAnswer,
                   wrongQuestion = x.WrongAnswer,
                   skippedQuestion = x.QuestionSkipped,
                   attemptedQuestion = x.AttemptedQuestion,
                   percentage = x.Percentage,
                   Duration = x.Duration
               })
               .ToList();




                return helperMethode(test);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultRepository DisplayResultbyExpFromDate Methode in Sql Repository" + ex);
                return null;
            }
           
           

        }


        public List<TestResultViewModel> DisplayResultbyCatAndExpFromDate(int categoryId, int experienceId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var test = _context.TblTest
                     .Where(e => e.ExpLevelId == experienceId && e.CategoryId == categoryId && (e.TestDate >= fromDate && e.TestDate <= toDate))
                     .Select(x => new TestResultMapModel //select statement give anonyms type so we map it in TestResultMapModel
                     {
                               candidateId = x.CandidateId,
                               CategoryId = x.CategoryId,
                               ExpLevelId = x.ExpLevelId,
                               testDate = x.TestDate,
                               testStatus = x.TestStatus,
                               totalQuestion = x.TotalQuestion,
                               correctAnswer = x.CorrectAnswer,
                               wrongQuestion = x.WrongAnswer,
                               skippedQuestion = x.QuestionSkipped,
                               attemptedQuestion = x.AttemptedQuestion,
                               percentage = x.Percentage,
                               Duration = x.Duration
                     })
                     .ToList();


                return helperMethode(test);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultRepository DisplayResultbyCatAndExpFromDate Methode in Sql Repository" + ex);
                return null;
            }
            
            

        }

        public List<TestResultViewModel> DisplayResultbyTestStatus(string status)
        {
            try
            {
                var test = _context.TblTest.Where(e => e.TestStatus == status)
                .Select(x => new TestResultMapModel //select statement give anonyms type so we map it in TestResultMapModel
                {
                    candidateId = x.CandidateId,
                    CategoryId = x.CategoryId,
                    ExpLevelId = x.ExpLevelId,
                    testDate = x.TestDate,
                    testStatus = x.TestStatus,
                    totalQuestion = x.TotalQuestion,
                    correctAnswer = x.CorrectAnswer,
                    wrongQuestion = x.WrongAnswer,
                    skippedQuestion = x.QuestionSkipped,
                    attemptedQuestion = x.AttemptedQuestion,
                    percentage = x.Percentage,
                    Duration = x.Duration
                })
                .ToList();


                return helperMethode(test);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultRepository DisplayResultbyTestStatus Methode in Sql Repository" + ex);
                return null;
            }
            
           

        }


        public List<TestResultViewModel> DisplayResultbyTestStatusAndCat(string status,int categoryId)
        {
            try
            {
                var test = _context.TblTest.Where(e => e.TestStatus == status && e.CategoryId == categoryId)
                .Select(x => new TestResultMapModel //select statement give anonyms type so we map it in TestResultMapModel
                {
                    candidateId = x.CandidateId,
                    CategoryId = x.CategoryId,
                    ExpLevelId = x.ExpLevelId,
                    testDate = x.TestDate,
                    testStatus = x.TestStatus,
                    totalQuestion = x.TotalQuestion,
                    correctAnswer = x.CorrectAnswer,
                    wrongQuestion = x.WrongAnswer,
                    skippedQuestion = x.QuestionSkipped,
                    attemptedQuestion = x.AttemptedQuestion,
                    percentage = x.Percentage,
                    Duration = x.Duration
                })
                .ToList();


                return helperMethode(test);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultRepository DisplayResultbyTestStatusAndCat Methode in Sql Repository" + ex);
                return null;

            }
            
            

        }

        public List<TestResultViewModel> DisplayResultbyTestStatusAndExp(string status, int experienceId)
        {
            try
            {
                var test = _context.TblTest.Where(e => e.TestStatus == status && e.ExpLevelId == experienceId)
                .Select(x => new TestResultMapModel //select statement give anonyms type so we map it in TestResultMapModel
                {
                    candidateId = x.CandidateId,
                    CategoryId = x.CategoryId,
                    ExpLevelId = x.ExpLevelId,
                    testDate = x.TestDate,
                    testStatus = x.TestStatus,
                    totalQuestion = x.TotalQuestion,
                    correctAnswer = x.CorrectAnswer,
                    wrongQuestion = x.WrongAnswer,
                    skippedQuestion = x.QuestionSkipped,
                    attemptedQuestion = x.AttemptedQuestion,
                    percentage = x.Percentage,
                    Duration = x.Duration
                })
                .ToList();


                return helperMethode(test);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultRepository DisplayResultbyTestStatusAndCat Methode in Sql Repository" + ex);
                return null;

            }  
            
            

        }

        public List<TestResultViewModel> DisplayResultbyTestStatusAndExpAndCat(string status, int experienceId,int categoryId)
        {
            try
            {
                var test = _context.TblTest.Where(e => e.TestStatus == status && e.ExpLevelId == experienceId && e.CategoryId == categoryId)
                 .Select(x => new TestResultMapModel //select statement give anonyms type so we map it in TestResultMapModel
                 {
                     candidateId = x.CandidateId,
                     CategoryId = x.CategoryId,
                     ExpLevelId = x.ExpLevelId,
                     testDate = x.TestDate,
                     testStatus = x.TestStatus,
                     totalQuestion = x.TotalQuestion,
                     correctAnswer = x.CorrectAnswer,
                     wrongQuestion = x.WrongAnswer,
                     skippedQuestion = x.QuestionSkipped,
                     attemptedQuestion = x.AttemptedQuestion,
                     percentage = x.Percentage,
                     Duration = x.Duration
                 })
                 .ToList();


                return helperMethode(test);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultRepository DisplayResultbyTestStatusAndExpAndCat Methode in Sql Repository" + ex);
                return null;
            }
            
           

        }



        public List<TestResultViewModel> DisplayResultbyTestStatusFromDate(string status, DateTime fromDate, DateTime toDate)
        {
            try
            {
              var test = _context.TblTest.Where(e => e.TestStatus == status && (e.TestDate >= fromDate && e.TestDate <= toDate))
                .Select(x => new TestResultMapModel //select statement give anonyms type so we map it in TestResultMapModel
                { 
                    candidateId = x.CandidateId,
                    CategoryId = x.CategoryId,
                    ExpLevelId = x.ExpLevelId,
                    testDate = x.TestDate,
                    testStatus = x.TestStatus,
                    totalQuestion = x.TotalQuestion,
                    correctAnswer = x.CorrectAnswer,
                    wrongQuestion = x.WrongAnswer,
                    skippedQuestion = x.QuestionSkipped,
                    attemptedQuestion = x.AttemptedQuestion,
                    percentage = x.Percentage,
                    Duration = x.Duration
                })
                .ToList();
            
            
            return helperMethode(test);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultRepository DisplayResultbyTestStatusFromDate Methode in Sql Repository" + ex);
                return null;

            }
           
           

        }



        public List<TestResultViewModel> DisplayResultbyTestStatusandCatFromDate(string status,int categoryId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var test = _context.TblTest.Where(e => e.CategoryId == categoryId && e.TestStatus == status && (e.TestDate >= fromDate && e.TestDate <= toDate))
               .Select(x => new TestResultMapModel //select statement give anonyms type so we map it in TestResultMapModel
                {
                   candidateId = x.CandidateId,
                   CategoryId = x.CategoryId,
                   ExpLevelId = x.ExpLevelId,
                   testDate = x.TestDate,
                   testStatus = x.TestStatus,
                   totalQuestion = x.TotalQuestion,
                   correctAnswer = x.CorrectAnswer,
                   wrongQuestion = x.WrongAnswer,
                   skippedQuestion = x.QuestionSkipped,
                   attemptedQuestion = x.AttemptedQuestion,
                   percentage = x.Percentage,
                   Duration = x.Duration
               })
               .ToList();


                return helperMethode(test);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultRepository DisplayResultbyTestStatusandCatFromDate Methode in Sql Repository" + ex);
                return null;
            }
           
           

        }


        public List<TestResultViewModel> DisplayResultbyTestStatusandCatAndExpFromDate(string status, int categoryId,int experienceId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var test = _context.TblTest.Where(e => e.CategoryId == categoryId && e.TestStatus == status && e.ExpLevelId == experienceId && (e.TestDate >= fromDate && e.TestDate <= toDate))
               .Select(x => new TestResultMapModel  //select statement give anonyms type so we map it in TestResultMapModel
                {
                   candidateId = x.CandidateId,
                   CategoryId = x.CategoryId,
                   ExpLevelId = x.ExpLevelId,
                   testDate = x.TestDate,
                   testStatus = x.TestStatus,
                   totalQuestion = x.TotalQuestion,
                   correctAnswer = x.CorrectAnswer,
                   wrongQuestion = x.WrongAnswer,
                   skippedQuestion = x.QuestionSkipped,
                   attemptedQuestion = x.AttemptedQuestion,
                   percentage = x.Percentage,
                   Duration = x.Duration
               })
               .ToList();


                return helperMethode(test);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultRepository DisplayResultbyTestStatusandCatAndExpFromDate Methode in Sql Repository" + ex);
                return null;

            }
           
          
        }

        public List<TestResultViewModel> DisplayResultbyTop10Percentage()
        {

            try
            {
                var test = _context.TblTest
                .Select(x => new TestResultMapModel  //select statement give anonyms type so we map it in TestResultMapModel
                {
                    candidateId = x.CandidateId,
                    CategoryId = x.CategoryId,
                    ExpLevelId = x.ExpLevelId,
                    testDate = x.TestDate,
                    testStatus = x.TestStatus,
                    totalQuestion = x.TotalQuestion,
                    correctAnswer = x.CorrectAnswer,
                    wrongQuestion = x.WrongAnswer,
                    skippedQuestion = x.QuestionSkipped,
                    attemptedQuestion = x.AttemptedQuestion,
                    percentage = x.Percentage,
                    Duration = x.Duration
                })
                .OrderByDescending(x => x.percentage)
                .Take(10)
                .ToList();

                return helperMethode(test);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultRepository DisplayResultbyTop10Percentage Methode in Sql Repository" + ex);
                return null;

            }
            
           
        }

        public List<TestResultViewModel> DisplayResultbyTop10PercentageAndCategory(int categoryId)
        {
            try
            {
             var test = _context.TblTest.Where(e => e.CategoryId == categoryId)
                .Select(x => new TestResultMapModel //select statement give anonyms type so we map it in TestResultMapModel
                { 
                    candidateId = x.CandidateId,
                    CategoryId = x.CategoryId, 
                    ExpLevelId = x.ExpLevelId,
                    testDate = x.TestDate, 
                    testStatus = x.TestStatus,
                    totalQuestion = x.TotalQuestion,
                    correctAnswer = x.CorrectAnswer, 
                    wrongQuestion = x.WrongAnswer,
                    skippedQuestion = x.QuestionSkipped,
                    attemptedQuestion = x.AttemptedQuestion,
                    percentage = x.Percentage,
                    Duration = x.Duration 
                })
                .OrderByDescending(x => x.percentage)
                .Take(10)
                .ToList();
            
            return helperMethode(test);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultRepository DisplayResultbyTop10PercentageAndCategory Methode in Sql Repository" + ex);
                return null;
            }
            
           
        }

        public List<TestResultViewModel> DisplayResultbyTop10PercentageAndCategoryAndExperience(int categoryId, int experienceLevelId)
        {
            try
            {
                var test = _context.TblTest.Where(e => e.CategoryId == categoryId && e.ExpLevelId == experienceLevelId)
                .Select(x => new TestResultMapModel //select statement give anonyms type so we map it in TestResultMapModel
                {
                    candidateId = x.CandidateId,
                    CategoryId = x.CategoryId,
                    ExpLevelId = x.ExpLevelId,
                    testDate = x.TestDate,
                    testStatus = x.TestStatus,
                    totalQuestion = x.TotalQuestion,
                    correctAnswer = x.CorrectAnswer,
                    wrongQuestion = x.WrongAnswer,
                    skippedQuestion = x.QuestionSkipped,
                    attemptedQuestion = x.AttemptedQuestion,
                    percentage = x.Percentage,
                    Duration = x.Duration
                })
                .OrderByDescending(x => x.percentage)
                .Take(10)
                .ToList();
              return helperMethode(test);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultRepository DisplayResultbyTop10PercentageAndCategoryAndExperience Methode in Sql Repository" + ex);
                return null;
            }
           
            
            
            
            
        }


        public List<TestResultViewModel> DisplayResultbyTop10PercentageAndExperience(int experienceId)
        {
            try
            {
                var test = _context.TblTest.Where(e => e.ExpLevelId == experienceId)
                .Select(x => new TestResultMapModel //select statement give anonyms type so we map it in TestResultMapModel
                {
                    candidateId = x.CandidateId,
                    CategoryId = x.CategoryId,
                    ExpLevelId = x.ExpLevelId,
                    testDate = x.TestDate,
                    testStatus = x.TestStatus,
                    totalQuestion = x.TotalQuestion,
                    correctAnswer = x.CorrectAnswer,
                    wrongQuestion = x.WrongAnswer,
                    skippedQuestion = x.QuestionSkipped,
                    attemptedQuestion = x.AttemptedQuestion,
                    percentage = x.Percentage,
                    Duration = x.Duration
                })
                .OrderByDescending(x => x.percentage)
                .Take(10)
                .ToList();

                return helperMethode(test);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultRepository DisplayResultbyTop10PercentageAndExperience Methode in Sql Repository" + ex);
                return null;

            }
            
            
        }

        public List<TestResultViewModel> DisplayResultbyTop10TestStatus(string status)
        {
            try
            {
                var test = _context.TblTest.Where(e => e.TestStatus == status)
                .Select(x => new TestResultMapModel  //select statement give anonyms type so we map it in TestResultMapModel
                {
                    candidateId = x.CandidateId,
                    CategoryId = x.CategoryId,
                    ExpLevelId = x.ExpLevelId,
                    testDate = x.TestDate,
                    testStatus = x.TestStatus,
                    totalQuestion = x.TotalQuestion,
                    correctAnswer = x.CorrectAnswer,
                    wrongQuestion = x.WrongAnswer,
                    skippedQuestion = x.QuestionSkipped,
                    attemptedQuestion = x.AttemptedQuestion,
                    percentage = x.Percentage,
                    Duration = x.Duration
                })
                .Take(10)
                .ToList();


                return helperMethode(test);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TestResultRepository DisplayResultbyTop10TestStatus Methode in Sql Repository" + ex);
                return null;
            }
            
           

        }




        public List<TestResultViewModel> DisplayResultbyTop10TestStatusAndCat(string status, int categoryId)
        {
            try
            {
                var test = _context.TblTest.Where(e => e.TestStatus == status && e.CategoryId == categoryId)
                .Select(x => new TestResultMapModel //select statement give anonyms type so we map it in TestResultMapModel
                {
                    candidateId = x.CandidateId,
                    CategoryId = x.CategoryId,
                    ExpLevelId = x.ExpLevelId,
                    testDate = x.TestDate,
                    testStatus = x.TestStatus,
                    totalQuestion = x.TotalQuestion,
                    correctAnswer = x.CorrectAnswer,
                    wrongQuestion = x.WrongAnswer,
                    skippedQuestion = x.QuestionSkipped,
                    attemptedQuestion = x.AttemptedQuestion,
                    percentage = x.Percentage,
                    Duration = x.Duration
                })
                .Take(10)
                .ToList();

                return helperMethode(test);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultRepository DisplayResultbyTop10TestStatusAndCat Methode in Sql Repository" + ex);
                return null;
            }
            
            

        }

        public List<TestResultViewModel> DisplayResultbyTop10TestStatusAndExp(string status, int experienceId)
        {
            try
            {
                var test = _context.TblTest.Where(e => e.TestStatus == status && e.ExpLevelId == experienceId)
               .Select(x => new TestResultMapModel //select statement give anonyms type so we map it in TestResultMapModel
                {
                   candidateId = x.CandidateId,
                   CategoryId = x.CategoryId,
                   ExpLevelId = x.ExpLevelId,
                   testDate = x.TestDate,
                   testStatus = x.TestStatus,
                   totalQuestion = x.TotalQuestion,
                   correctAnswer = x.CorrectAnswer,
                   wrongQuestion = x.WrongAnswer,
                   skippedQuestion = x.QuestionSkipped,
                   attemptedQuestion = x.AttemptedQuestion,
                   percentage = x.Percentage,
                   Duration = x.Duration
               })
               .Take(10)
               .ToList();

                return helperMethode(test);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultRepository DisplayResultbyTop10TestStatusAndExp Methode in Sql Repository" + ex);
                return null;
            }
            
           
            

        }

        public List<TestResultViewModel> DisplayResultbyTop10TestStatusAndExpAndCat(string status, int experienceId, int categoryId)
        {
            try
            {
                var test = _context.TblTest.Where(e => e.TestStatus == status && e.ExpLevelId == experienceId && e.CategoryId == categoryId)
                .Select(x => new TestResultMapModel //select statement give anonyms type so we map it in TestResultMapModel
                {
                    candidateId = x.CandidateId,
                    CategoryId = x.CategoryId,
                    ExpLevelId = x.ExpLevelId,
                    testDate = x.TestDate,
                    testStatus = x.TestStatus,
                    totalQuestion = x.TotalQuestion,
                    correctAnswer = x.CorrectAnswer,
                    wrongQuestion = x.WrongAnswer,
                    skippedQuestion = x.QuestionSkipped,
                    attemptedQuestion = x.AttemptedQuestion,
                    percentage = x.Percentage,
                    Duration = x.Duration
                })
                .Take(10)
                .ToList();


                return helperMethode(test);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultRepository DisplayResultbyTop10TestStatusAndExpAndCat Methode in Sql Repository" + ex);
                return null;
            }
           
          
        }

        //helper methode which is return List of query

        //TestResultMapModel which is map during query 
        public List<TestResultViewModel> helperMethode(List<TestResultMapModel> test)
        {
            var result = new List<TestResultViewModel>();
          
             
            foreach (var item in test)
            {
                TestResultViewModel model = new TestResultViewModel();
                
                var candidate = _context.TblCandidate.Where(e => e.CandidateId == item.candidateId).Select(x => new { x.FirstName, x.CandidateId }).SingleOrDefault();
                model.candidateName = candidate.FirstName;
                model.candidateId = candidate.CandidateId;

                string categoryName = _context.TblCategory.Where(e => e.CategoryId == item.CategoryId).Select(x => x.Name).SingleOrDefault();
                model.category = categoryName;

                string experience = _context.TblExperienceLevel.Where(e => e.Id == item.ExpLevelId).Select(x => x.Name).SingleOrDefault();
                model.experienceLevel = experience;

                model.testDate = item.testDate;
                model.testStatus = item.testStatus;
                model.totalQuestion = item.totalQuestion;
                model.attemptedQuestion = item.attemptedQuestion;
                model.skippedQuestion = item.skippedQuestion;
                model.wrongQuestion = item.wrongQuestion;
                model.correctAnswer = item.correctAnswer;
                model.percentage = item.percentage;
                model.Duration = item.Duration;
                
                result.Add(model);


            }
            return result;

        }


       //above function is replica of this code
        
        //var result = new List<TestResultViewModel>();
        //var test = _context.TblTest.Where(e => e.TestStatus == status && e.ExpLevelId == experienceId && e.CategoryId == categoryId).Select(x => new TestResultMapModel { candidateId = x.CandidateId, CategoryId = x.CategoryId, ExpLevelId = x.ExpLevelId, testDate = x.TestDate, testStatus = x.TestStatus, totalQuestion = x.TotalQuestion, correctAnswer = x.CorrectAnswer, wrongQuestion = x.WrongAnswer, skippedQuestion = x.QuestionSkipped, attemptedQuestion = x.AttemptedQuestion, percentage = x.Percentage, Duration = x.Duration }).Take(10).ToList();
        //foreach (var item in test)
        //{
        //    TestResultViewModel model = new TestResultViewModel();

        //    var candidate = _context.TblCandidate.Where(e => e.CandidateId == item.CandidateId).Select(x => new { x.FirstName, x.CandidateId }).SingleOrDefault();
        //    model.candidateName = candidate.FirstName;
        //    model.candidateId = candidate.CandidateId;

        //    string categoryName = _context.TblCategory.Where(e => e.CategoryId == item.CategoryId).Select(x => x.Name).SingleOrDefault();
        //    model.category = categoryName;

        //    string experience = _context.TblExperienceLevel.Where(e => e.Id == item.ExpLevelId).Select(x => x.Name).SingleOrDefault();
        //    model.experienceLevel = experience;

        //    model.testDate = item.TestDate;
        //    model.testStatus = item.TestStatus;
        //    model.totalQuestion = item.TotalQuestion;
        //    model.attemptedQuestion = item.AttemptedQuestion;
        //    model.skippedQuestion = item.QuestionSkipped;
        //    model.wrongQuestion = item.WrongAnswer;
        //    model.correctAnswer = item.CorrectAnswer;
        //    model.percentage = item.Percentage;
        //    model.Duration = item.Duration;
        //    result.Add(model);


        //}
        //return result;



    }
}
