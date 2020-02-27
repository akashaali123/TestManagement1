using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestManagement1.Model;
using TestManagementCore.Model;

namespace TestManagementCore.MyTriggerMethode
{
    public  class TriggerClass
    {

        //make for future configuration if we want trigger Like functionality in Future so we use it 


        private readonly TestManagementContext _context;
        public TriggerClass(TestManagementContext context)
        {
            _context = context;
        }
        

        public  void Add(string UserId, string RoleId, string Actionperform, string TableName, DateTime ActionDate)
        {
            TblAction action = new TblAction
            { 
                UserId = UserId,
                RoleId = RoleId,
                Actionperform = Actionperform,
                TableName = TableName,
                ActionDate = ActionDate
         
            };

            _context.Add(action);
            _context.SaveChanges();
            
        }
    }
}
