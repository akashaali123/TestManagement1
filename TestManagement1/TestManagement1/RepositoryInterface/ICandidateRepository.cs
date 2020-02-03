using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;

namespace TestManagement1.RepositoryInterface
{
    public interface ICandidateRepository
    {
        TblCandidate GetCandidate(int id);
        IEnumerable<TblCandidate> GetAllCandidate();

        TblCandidate Add(TblCandidate candidate);

        TblCandidate Update(TblCandidate candidate);

        TblCandidate Delete(int id);




    }
}
