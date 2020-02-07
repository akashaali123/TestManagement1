using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;

namespace TestManagement1.SqlRepository
{
    public class BaseRepository<T> where T : class
    {
        protected readonly TestManagementContext _context;
        protected readonly ILogger<T> _logger;
        public BaseRepository(TestManagementContext context, ILogger<T> logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
