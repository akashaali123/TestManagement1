using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
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
    public class TestResultByReviewerRepository : BaseRepository<TestResultByReviewerRepository>, ITestResultByReviewer
    {
        public TestResultByReviewerRepository(TestManagementContext context, ILogger<TestResultByReviewerRepository> logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {

        }


        public List<TestResultViewModel> DisplayResultAllCandidate()
        {
            try
            {
                var categoryId = _context.TblVerifierCategoryAndRole
                    .Where(e => e.UserId == sessionManager.getSession("userid"))
                    .Select(x => x.CategoryId)
                    .SingleOrDefault();

                var test = _context.TblTest
                    .Where(e=>e.CategoryId == Convert.ToInt32(categoryId) )
                    .Select(x => new TestResultMapModel//select statement give anonyms type so we map it in TestResultMapModel
                    {                                  //which is pass as a parameter in helperMethode which implementation is below
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

                _logger.LogError("Error in TestResultByReviewerRepository DisplayResultAllCandidate Methode in Sql Repository" + ex);
                return null;
            }


        }



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


    }
}
