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
        public SqlCandidateRepository(TestManagementContext context)
        {
            _context = context;
        }



        public TblCandidate Add(TblCandidate candidate)
        {
            candidate.CreatedDate = DateTime.Now;
            candidate.IsActive = true;
            candidate.CreatedBy = 1;
           
            
            
            _context.TblCandidate.Add(candidate);
            _context.SaveChanges();
            return candidate;
        }

        public TblCandidate Delete(int id)
        {
            var candidate = _context.TblCandidate.Find(id);
            if(candidate != null)
            {
               
                    _context.TblCandidate.Remove(candidate);
                    _context.SaveChanges();
               
            }

            return candidate;
        }

        public IEnumerable<TblCandidate> GetAllCandidate()
        {
            return _context.TblCandidate;
        }

        public TblCandidate GetCandidate(int id)
        {
            return _context.TblCandidate.Find(id);
        }

        public TblCandidate Update(TblCandidate candidate)
        {
            throw new NotImplementedException();
        }
    }
}
