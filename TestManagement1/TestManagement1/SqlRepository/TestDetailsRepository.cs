using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagement1.SqlRepository;
using TestManagementCore.Extension;
using TestManagementCore.MyTriggerMethode;
using TestManagementCore.RepositoryInterface;
using TestManagementCore.ViewModel;

namespace TestManagementCore.SqlRepository
{
    public class TestDetailsRepository : BaseRepository<TestDetailsRepository>, ITestDetails
    {
        public TestDetailsRepository(TestManagementContext context,
                                     ILogger<TestDetailsRepository> logger,
                                     IHttpContextAccessor httpContextAccessor,
                                     TriggerClass trigger) :base(context,
                                                                 logger,
                                                                 httpContextAccessor,
                                                                 trigger)
        {

        }
        public bool Add(TestDetailsViewModel model)
        {
            try
            {
                //get correct option Id of attempted question and save in array
                var correctoption = _context.TblOption.Where(e => e.QuestionId == model.QuestionId &&
                                                                  e.IsCorrect == true &&
                                                                  e.IsActive == true)
                                                      .Select(x => x.OptionId)
                                                      .ToArray();


                //Convert correctOption Array into , separated string
                var correctOptionString = string.Join(",", correctoption);

              


                TblTestDetails testDetails = new TblTestDetails
                {
                   
                    CandidateId = model.Candidateid,
                    QuestionId = model.QuestionId,
                    SelectedOptionId = model.SelectedOptionId,
                    CorrectOptionId = correctOptionString,
                    AttemptedInDuration = model.AttemptedInDuration,
                    IsActive = true,




                };

                

                _context.TblTestDetails.Add(testDetails);
               int count =  _context.SaveChanges();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in TestDetailsRepository Add Methode in Sql Repository" + ex);

                return false;
            }
            

        }
   
    
    
    
    
    
    
    
    }
}
