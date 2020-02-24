﻿using Microsoft.AspNetCore.Http;
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
    public class CategoryRepository : BaseRepository<CategoryRepository>,ICategory
    {

                                                                                                      //Required For Get Session implementation in baseClass
        public CategoryRepository(TestManagementContext context, ILogger<CategoryRepository> logger, IHttpContextAccessor httpContextAccessor) :base(context,logger, httpContextAccessor)
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
                    CreatedBy = sessionManager.getSession("userid"),
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

      
        
        
        
        
        public TblCategory Delete(int id)
        {
            try
            {
                var category = _context.TblCategory.Find(id);
                if (category != null)
                {
                    _context.TblCategory.Remove(category);
                    _context.SaveChanges();
                }

                return category;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in Category Delete Methode in Sql Repository" +ex);
                return null; 
            }
           
        }

       
        
        
        
        public IEnumerable<TblCategory> GetAllCategory()
        {
            try 
            {
                return _context.TblCategory;
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

        
        
        
        
        
        
        
        public TblCategory Update(CategoryViewModel category)
        {
            throw new NotImplementedException();
        }
    
    
    
    
    
    
    
    }
}
