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
    public class TestDetailsRepository : BaseRepository<TestDetailsRepository>, ITestDetails
    {
        public TestDetailsRepository(TestManagementContext context, ILogger<TestDetailsRepository> logger, IHttpContextAccessor httpContextAccessor):base(context, logger, httpContextAccessor)
        {

        }
        public TblTestDetails Add(TestDetailsViewModel model)
        {
            //get correct option Id of attempted question and save in array
            var correctoption = _context.TblOption.Where(e => e.QuestionId == model.QuestionId && e.IsCorrect == true).Select(x=>x.OptionId).ToArray();

            
            //Convert correctOption Array into , separated string
            var correctOptionString = string.Join(",",correctoption);

            //int[] myArray = Array.ConvertAll(correctOptionString.Split(','), s => int.Parse(s));
            //int[] myArray2 = Array.ConvertAll(model.SelectedOptionId.Split(','), s => int.Parse(s));

            //if (myArray.ItemsEqual(myArray2))
            //{

            //}
            
            
            TblTestDetails testDetails = new TblTestDetails
            {
               // TestId = model.TestId,
                CandidateId = model.Candidateid,
                QuestionId = model.QuestionId,
                SelectedOptionId = model.SelectedOptionId,
                CorrectOptionId = correctOptionString,
                AttemptedInDuration = model.AttemptedInDuration,
                IsActive = model.IsActive


            };

            //int[] myArray = StringToIntArray(myNumbers);

            _context.TblTestDetails.Add(testDetails);
            _context.SaveChanges();
            return testDetails;

        }
    }
}
