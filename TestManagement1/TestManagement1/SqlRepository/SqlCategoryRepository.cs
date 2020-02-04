using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagement1.RepositoryInterface;

namespace TestManagement1.SqlRepository
{
    public class SqlCategoryRepository : ICategory
    {
        private readonly ILogger<SqlCategoryRepository> _logger;
        private readonly TestManagementContext _context;

        public SqlCategoryRepository(TestManagementContext context, ILogger<SqlCategoryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public TblCategory Add(TblCategory category)
        {
            try
            {
                category.IsActive = true;
                category.CreatedBy = 1;
                category.CreatedDate = DateTime.Now;

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

        public TblCategory Update(TblCategory category)
        {
            throw new NotImplementedException();
        }
    }
}
