using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagement1.RepositoryInterface;
using TestManagement1.ViewModel;
using TestManagementCore.MyTriggerMethode;
using TestManagementCore.SessionManager;

namespace TestManagement1.SqlRepository
{
    public class ExperienceLevelRepository : BaseRepository<ExperienceLevelRepository>,IExperienceLevel
    {

                                                                                                                   //Required For Get Session implementation in baseClass
        public ExperienceLevelRepository(TestManagementContext context,
                                         ILogger<ExperienceLevelRepository> logger,
                                         IHttpContextAccessor httpContextAccessor,
                                         TriggerClass trigger) : base(context,
                                                                       logger,
                                                                       httpContextAccessor,
                                                                       trigger)
        {
            

        }

       
        
        
        
        
        public TblExperienceLevel Add(ExperienceLevelViewModel experienceLevelModel)
        {
            
           try
            {
                TblExperienceLevel experienceLevel = new TblExperienceLevel
                {
                    Name = experienceLevelModel.Name,
                    MinExp = experienceLevelModel.MinExp,
                    MaxExp = experienceLevelModel.MaxExp,
                    IsActive = true,
                    CreatedBy =sessionManager.getSession("userid"),
                    CreatedDate = DateTime.Today,
                    UpdatedBy = null,
                    UpdatedDate = null
                };

               
                _context.TblExperienceLevel.Add(experienceLevel);
                _context.SaveChanges();
                return experienceLevel;
            }
            catch(Exception ex)
            {
                _logger.LogError("Error in ExperienceLevel Add Methode in Sql Repository" +ex);

                return null;

            }
        }

       
        
        
        
        
        public bool Delete(int id)
        {
            try
            {
                var experience = _context.TblExperienceLevel.Find(id);
                if (experience != null)
                {
                    _context.TblExperienceLevel.Remove(experience);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {

               _logger.LogError("Error in ExperienceLevel Delete Methode in Sql Repository" + ex);
                return false;
            }
        }

        
        
        
        
        
        
        public IEnumerable<TblExperienceLevel> GetAll()
        {
            try
            {
                return _context.TblExperienceLevel.Where(e=>e.IsActive ==  true)
                    .OrderByDescending(x=>x.CreatedDate)
                    .ThenByDescending(x => x.Id)
                    .ThenByDescending(e => e.UpdatedDate);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in ExperienceLevel GetAll Methode in Sql Repository" + ex);
                return null;
            }
        }

        
        
        
        
        
        public TblExperienceLevel GetExperience(int id)
        {
            try
            {
                return _context.TblExperienceLevel.Find(id);
            }
            catch (Exception ex)
            {

               _logger.LogError("Error in ExperienceLevel GetExperience Methode in Sql Repository" + ex);
                return null;
            }
        }

       
        
        
        
        
        
        
        public TblExperienceLevel Update(ExperienceLevelViewModel experienceLevelModel,
                                         int id)
        {
            try
            {
                var experienceLevelChanges = _context.TblExperienceLevel.Where(e => e.Id == id)
                                                                        .SingleOrDefault();

                experienceLevelChanges.Name = experienceLevelModel.Name;
                experienceLevelChanges.MinExp = experienceLevelModel.MinExp;
                experienceLevelChanges.MaxExp = experienceLevelModel.MaxExp;
                experienceLevelChanges.UpdatedBy = GetUserId();
                experienceLevelChanges.UpdatedDate = DateTime.Today;

                var experiencceLevel = _context.TblExperienceLevel.Attach(experienceLevelChanges);

                experiencceLevel.State = EntityState.Modified;

                _context.SaveChanges();
                return experienceLevelChanges;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in ExperienceLevel Update Methode in Sql Repository" + ex);
                return null;
            }
            
        }
  
    
    
    
    }
}
