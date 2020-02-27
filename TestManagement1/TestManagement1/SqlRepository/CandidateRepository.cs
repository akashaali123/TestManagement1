using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagement1.RepositoryInterface;
using TestManagement1.ViewModel;
using TestManagementCore.MyTriggerMethode;

namespace TestManagement1.SqlRepository
{
                                        //Inherit with generic class and candidate Repository                
    public class CandidateRepository :BaseRepository<CandidateRepository> ,ICandidate
    {


        //Make BaseRepository in which we initialize our logger as a generic and context class
        //So we avoid duplication
        //TestManagementContext _context;
        //ILogger<SqlCandidateRepository> _logger; 
        //Required For Get Session implementation in baseClass

       
        
        
        private readonly ApplicationSettings _appSettings;//For Jwt
                                                                                                        //For jwt
        public CandidateRepository(TestManagementContext context, ILogger<CandidateRepository> logger, IOptions<ApplicationSettings> appSettings, IHttpContextAccessor httpContextAccessor, TriggerClass trigger) :base(context,logger,httpContextAccessor, trigger)
        {
            //_logger = logger;
            //_context = context;

            _appSettings = appSettings.Value;//For jwt

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
                    TechStack=candidateModel.TechStack,
                    CategoryId=candidateModel.categoryId,
                    ExperienceLevelId = candidateModel.ExperienceLevelId,
                    CreatedDate = DateTime.Today,
                    IsActive = true,
                    CreatedBy = GetUserId(),
                };
                _context.TblCandidate.Add(candidate);
                _context.SaveChanges();
                return candidate;
            }
            catch(Exception ex)
            {
                _logger.LogError("Error in Candidate Add Methode in Sql Repository" + ex);
                 //throw ex;
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
                CandidateId = candidateModel.CandidateId,
                FirstName = candidateModel.FirstName,
                LastName = candidateModel.LastName,
                Email = candidateModel.Email,
                CurrentCompany = candidateModel.CurrentCompany,
                //TechStack = candidateModel.CurrentCompany,
                CategoryId = candidateModel.categoryId,
                ExperienceLevelId = candidateModel.ExperienceLevelId,
                CreatedDate = DateTime.Today,
                IsActive = true,
                CreatedBy = GetUserId()

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

        public  object JwtForCandidate(int candidateId,int numberOfQuestion)
        {
            try
            {
                var candidate = _context.TblCandidate.Find(candidateId);
                if (candidate != null)
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                           {
                                new Claim("role", "candidate"),//We access this userID in UserProfile Controller
                                 new Claim("candidateid", candidate.CandidateId.ToString()),
                                 new Claim("number",numberOfQuestion.ToString())//sending no of question in jwt which is used to get test question


                           }),

                        Expires = DateTime.UtcNow.AddHours(5),

                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();

                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);

                    var token = tokenHandler.WriteToken(securityToken);
                    return token;

                }
                else
                {
                    return new { message = "Invalid Candidate" +candidateId };
                }
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in Candidate JwtForCandidate Methode in Sql Repository" + ex);
                return null;
            }
            

        
        }





    }

    
}
