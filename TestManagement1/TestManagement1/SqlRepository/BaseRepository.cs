using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagementCore.SessionManager;

namespace TestManagement1.SqlRepository
{
    public class BaseRepository<T> where T : class
    {
        protected readonly TestManagementContext _context;
        protected readonly ILogger<T> _logger;
        
        //SessionManager Class Contain the Definition Of Set and get Session 
      
        protected SessionManager sessionManager;//Obj Of the SessionManager
        public BaseRepository(TestManagementContext context, ILogger<T> logger, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _logger = logger;
            
            //SessionManager Required the httpContextAccessor in constructor Parameter For better Explanation
            //see the implementation
            sessionManager = new SessionManager(httpContextAccessor);
        }
    }
}
