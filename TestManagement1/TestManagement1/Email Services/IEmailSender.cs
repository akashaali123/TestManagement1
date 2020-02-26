using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestManagementCore.Email_Services
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
