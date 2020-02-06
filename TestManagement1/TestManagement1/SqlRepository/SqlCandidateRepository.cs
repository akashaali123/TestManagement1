using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagement1.RepositoryInterface;
using TestManagement1.ViewModel;

namespace TestManagement1.SqlRepository
{
    public class SqlCandidateRepository : ICandidateRepository
    {


        private readonly TestManagementContext _context;
        private readonly ILogger<SqlCandidateRepository> _logger;
        public SqlCandidateRepository(TestManagementContext context, ILogger<SqlCandidateRepository> logger)
        {
            _context = context;
            _logger = logger;
        }



        public TblCandidate Add(CandidateViewModel candidateModel)
        {
            try
            {
                TblCandidate candidate = new TblCandidate
                {
                    CandidateId=candidateModel.CandidateId,
                    FirstName = candidateModel.FirstName,
                    LastName=candidateModel.LastName,
                    Email=candidateModel.Email,
                    CurrentCompany=candidateModel.CurrentCompany,
                    TechStack=candidateModel.CurrentCompany,
                   
                    
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    CreatedBy = 1
            };
                _context.TblCandidate.Add(candidate);
                _context.SaveChanges();
                return candidate;
            }
            catch(Exception ex)
            {
                _logger.LogError("Error in Candidate Add Methode in Sql Repository" + ex);
                return null;
            }
            
        }

        public TblCandidate Delete(int id)
        {
            try
            {
                var candidate = _context.TblCandidate.Find(id);
                if (candidate != null)
                {

                    _context.TblCandidate.Remove(candidate);
                    _context.SaveChanges();

                }

                return candidate;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in Candidate Delete Methode in Sql Repository" + ex);
                return null;
            }


        }

        public IEnumerable<TblCandidate> GetAllCandidate()
        {
            try
            {

                return _context.TblCandidate;
                 
                    
                
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in Candidate GetAllCandidate Methode in Sql Repository" + ex);
                return null;
            }

        }

        public TblCandidate GetCandidate(int id)
        {
            try
            {
                return _context.TblCandidate.Find(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in Candidate GetCandidate Methode in Sql Repository" + ex);
                return null;
            }

        }

        public TblCandidate Update(CandidateViewModel candidateModel)
        {
            TblCandidate candidateChanges = new TblCandidate
            {
                CandidateId=candidateModel.CandidateId,
                FirstName = candidateModel.FirstName,
                LastName = candidateModel.LastName,
                Email = candidateModel.Email,
                CurrentCompany = candidateModel.CurrentCompany,
                TechStack = candidateModel.CurrentCompany,
                CreatedDate = DateTime.Now,
                IsActive = true,
                CreatedBy = 1
            };

            var candidate = _context.TblCandidate.Attach(candidateChanges);
            candidate.State = EntityState.Modified;
            _context.SaveChanges();
            return candidateChanges;

        }

        //public TblCandidate Update(int id, TblCandidate candidate)
        //{


        //    var candidateChanges = _context.TblCandidate.Where(x => x.CandidateId == id).FirstOrDefault();
        //    candidateChanges.FirstName = candidate.FirstName;
        //    candidateChanges.LastName = candidate.LastName;
        //    candidateChanges.Email = candidate.Email;
             

        //}




    }

    
}
