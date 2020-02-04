using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagement1.RepositoryInterface;

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



        public TblCandidate Add(TblCandidate candidate)
        {
            try
            {
                candidate.CreatedDate = DateTime.Now;
                candidate.IsActive = true;
                candidate.CreatedBy = 1;



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

        public TblCandidate Update(TblCandidate candidate)
        {
            throw new NotImplementedException();
        }
    }

    
}
