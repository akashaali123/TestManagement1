using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagement1.SqlRepository;
using TestManagementCore.Model;
using TestManagementCore.RepositoryInterface;

namespace TestManagementCore.SqlRepository
{
    public class CompanyRepository: BaseRepository<CompanyRepository>, ICompany
    {
        public CompanyRepository(TestManagementContext context, ILogger<CompanyRepository> logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {

        }
        public IEnumerable<TblCompany> GetAllCompany()
        {
            try
            {
                return _context.TblCompany;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in CompanyRepository GetAllCompany Methde in Sql Repository" + ex);
                return null;
            }
        }


    }
}
