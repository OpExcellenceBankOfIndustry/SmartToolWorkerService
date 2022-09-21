using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_SmartToolWorkerService.Interface
{
    public interface IEmailSender
    {
        Task<bool> SendEmailBonitaURLDownAsync(string url);
        Task<bool> SendEmailBonitaServerDownAsync(string ipAddress);
    }
}
