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

namespace TestManagement1.SqlRepository
{
    public class CategoryRepository : BaseRepository<CategoryRepository>,ICategory
    {

       

        // IHttpContextAccessor Required For Get Session implementation in baseClass
        public CategoryRepository(TestManagementContext context,
                                  ILogger<CategoryRepository> logger,
                                  IHttpContextAccessor httpContextAccessor,
                                  TriggerClass trigger) :base(context,
                                                              logger,
                                                              httpContextAccessor,
                                                              trigger)
        {
           
        }

       
        
        
        
        
        public TblCategory Add(CategoryViewModel categoryModel)
        {
            try
            {
                
                TblCategory category = new TblCategory
                {
                    
                    Name = categoryModel.Name,
                    IsActive = true,
                    CreatedBy = GetUserId(),//GetUserId implementation is sql Repository
                    CreatedDate = DateTime.Today

            };

             

                _context.TblCategory.Add(category);
                _context.SaveChanges();
               
                
                  
                
                return category;

            }
            catch(Exception ex)
            {
                _logger.LogError("Error in Category Add Methode in Sql Repository" +ex);
                return null;
            }
            
        }

      
        
        
        
        
        public bool Delete(int id)
        {
            try
            {
                var category = _context.TblCategory.Find(id);
                if (category != null)
                {
                    _context.TblCategory.Remove(category);
                    _context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in Category Delete Methode in Sql Repository" +ex);
                return false; 
            }
           
        }

       
        
        
        
        public IEnumerable<TblCategory> GetAllCategory()
        {
            try 
            {
            
                return _context.TblCategory.Where(e=>e.IsActive ==  true)
                    .OrderByDescending(x=>x.CreatedDate)
                    .ThenByDescending(x => x.CategoryId)
                    .ThenByDescending(e => e.UpdatedDate);
                
            }
            catch(Exception ex)
            {
                _logger.LogError("Error in Category GetAllCategory Methde in Sql Repository" + ex);
                return null;
            }
        }

       
        
        
        
        
        
        
        public TblCategory GetCategory(int id)
        {
            try 
            {
                return _context.TblCategory.Find(id);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error in Category GetCategory Methde in Sql Repository" + ex);
                return null;
            }
        }

        
        
        
        
        
        
        
        public TblCategory Update(CategoryViewModel categoryModel,
                                  int id)
        {
            try
            {
                var categoryChanges = _context.TblCategory.Where(e => e.CategoryId == id)
                                                          .SingleOrDefault();

                categoryChanges.Name = categoryModel.Name;
                categoryChanges.UpdatedBy = GetUserId();
                categoryChanges.UpdatedDate = DateTime.Today;

                var category = _context.TblCategory.Attach(categoryChanges);
                category.State = EntityState.Modified;
                _context.SaveChanges();
                return categoryChanges;
            }
            catch (Exception ex)
            {

                _logger.LogError("Error in Category Update Methde in Sql Repository" + ex);
                return null;
            }
            
        }
    
    
    
    
    
    
    
    }
}
