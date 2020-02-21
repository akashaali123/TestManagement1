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
               int checkCandidate =  _context.TblTest.Where(e => e.CandidateId == candidateId).Select(x=>x.CandidateId).Count();

                //If test Not Found in TblTest than added 
                if (checkCandidate == 0) 
                {
                    var candidate = _context.TblCandidate.Find(candidateId);//First we find that candidate Register 
                    if (candidate != null)//If candidate not register so we did'nt save his result
                    {
                        //get their data of test Table
                        var test = _context.TblTestDetails.Where(e => e.CandidateId == candidateId).Select(x => new { x.SelectedOptionId, x.CorrectOptionId, x.CandidateId });

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

       
        
        
        
        public List<TestResultViewModel> DisplayResultAllCandidate()
        {


            try
            {
                var result = new List<TestResultViewModel>();



                var test = _context.TblTest.Select(x => new { x.CandidateId, x.CategoryId, x.ExpLevelId, x.TestDate, x.TestStatus, x.TotalQuestion, x.CorrectAnswer, x.WrongAnswer, x.QuestionSkipped, x.AttemptedQuestion, x.Percentage, x.Duration }).ToList();

                foreach (var item in test)
                {
                    TestResultViewModel model = new TestResultViewModel();

                    var candidate = _context.TblCandidate.Where(e => e.CandidateId == item.CandidateId).Select(x => new { x.FirstName, x.CandidateId }).SingleOrDefault();
                    model.candidateName = candidate.FirstName;
                    model.candidateId = candidate.CandidateId;

                    string categoryName = _context.TblCategory.Where(e => e.CategoryId == item.CategoryId).Select(x => x.Name).SingleOrDefault();
                    model.category = categoryName;

                    string experience = _context.TblExperienceLevel.Where(e => e.Id == item.ExpLevelId).Select(x => x.Name).SingleOrDefault();
                    model.experienceLevel = experience;

                    model.testDate = item.TestDate;
                    model.testStatus = item.TestStatus;
                    model.totalQuestion = item.TotalQuestion;
                    model.attemptedQuestion = item.AttemptedQuestion;
                    model.skippedQuestion = item.QuestionSkipped;
                    model.wrongQuestion = item.WrongAnswer;
                    model.correctAnswer = item.CorrectAnswer;
                    model.percentage = item.Percentage;
                    model.Duration = item.Duration;
                    result.Add(model);


                }
                return result;
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
                var test = _context.TblTest.Where(e => e.CandidateId == candidateId).Select(x => new { x.CandidateId, x.CategoryId, x.ExpLevelId, x.TestDate, x.TestStatus, x.TotalQuestion, x.CorrectAnswer, x.WrongAnswer, x.QuestionSkipped, x.AttemptedQuestion, x.Percentage, x.Duration }).SingleOrDefault();


                TestResultViewModel model = new TestResultViewModel();

                var candidate = _context.TblCandidate.Where(e => e.CandidateId == test.CandidateId).Select(x => new { x.FirstName, x.CandidateId }).SingleOrDefault();
                model.candidateName = candidate.FirstName;
                model.candidateId = candidate.CandidateId;

                string categoryName = _context.TblCategory.Where(e => e.CategoryId == test.CategoryId).Select(x => x.Name).SingleOrDefault();
                model.category = categoryName;

                string experience = _context.TblExperienceLevel.Where(e => e.Id == test.ExpLevelId).Select(x => x.Name).SingleOrDefault();
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
                var result = new List<TestResultViewModel>();
                //Use For Between data
                var test = _context.TblTest.Where(e => e.TestDate >= fromDate).Where(e => e.TestDate <= toDate).Select(x => new { x.CandidateId, x.CategoryId, x.ExpLevelId, x.TestDate, x.TestStatus, x.TotalQuestion, x.CorrectAnswer, x.WrongAnswer, x.QuestionSkipped, x.AttemptedQuestion, x.Percentage, x.Duration }).ToList();

                foreach (var item in test)
                {
                    TestResultViewModel model = new TestResultViewModel();

                    var candidate = _context.TblCandidate.Where(e => e.CandidateId == item.CandidateId).Select(x => new { x.FirstName, x.CandidateId }).SingleOrDefault();
                    model.candidateName = candidate.FirstName;
                    model.candidateId = candidate.CandidateId;

                    string categoryName = _context.TblCategory.Where(e => e.CategoryId == item.CategoryId).Select(x => x.Name).SingleOrDefault();
                    model.category = categoryName;

                    string experience = _context.TblExperienceLevel.Where(e => e.Id == item.ExpLevelId).Select(x => x.Name).SingleOrDefault();
                    model.experienceLevel = experience;

                    model.testDate = item.TestDate;
                    model.testStatus = item.TestStatus;
                    model.totalQuestion = item.TotalQuestion;
                    model.attemptedQuestion = item.AttemptedQuestion;
                    model.skippedQuestion = item.QuestionSkipped;
                    model.wrongQuestion = item.WrongAnswer;
                    model.correctAnswer = item.CorrectAnswer;
                    model.percentage = item.Percentage;
                    model.Duration = item.Duration;
                    result.Add(model);
                }





                return result;
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestResultRepository DisplayResultbyDate Methode in Sql Repository" + ex);
                return null;
            }
           

        }



    }
}
