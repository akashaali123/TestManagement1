using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagement1.RepositoryInterface;

namespace TestManagement1.Presenter
{
    public class CandidatePresenter
    {
        private readonly IWebHostEnvironment _env;
        private readonly ICandidateRepository _repository;
        private readonly ILogger<CandidatePresenter> _logger;
        public CandidatePresenter(IWebHostEnvironment env, ICandidateRepository repository, ILogger<CandidatePresenter> logger)
        {
            _env = env;
            _repository = repository;
            _logger = logger;
        }
        
       
        
        public IEnumerable<TblCandidate> GetAllCandidate()
        {
            try
            {
                return _repository.GetAllCandidate();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in Candidate GetAllCandidate Methode in CandidatePresenter" +ex);
                return null;
            }           
        }




        public TblCandidate Add(TblCandidate candidate)
        {
            try
            {
                return _repository.Add(candidate);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in Candidate Add Methode in CandidatePresenter" + ex);
                return null;
            }            
        }

       
        
        
        public TblCandidate Delete(int id)
        {
            try
            {
                return _repository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in Candidate Delete Methode in CandidatePresenter" + ex);
                return null;
            }            
        }





    }
}
