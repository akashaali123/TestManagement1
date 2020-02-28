using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagement1.ViewModel;

namespace TestManagement1.RepositoryInterface
{
    public interface ICandidate
    {
        TblCandidate GetCandidate(int id);
        IEnumerable<TblCandidate> GetAllCandidate();

        public TblCandidate Update(CandidateViewModel candidateModel, int id);

        public bool Delete(int id);

        TblCandidate Add(CandidateViewModel candidateModel);

        public object JwtForCandidate(int candidateId, int numberOfQuestion);




    }
}
