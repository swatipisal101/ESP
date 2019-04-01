using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESPAPI.Services
{
    public interface ISendEmailService
    {
        Task SendEmail(string email, string message, string subject, string company_Admin_emailId);

        Task SendEmailWithAttachment(string email, string message, string subject, string fileName);
    }
}
