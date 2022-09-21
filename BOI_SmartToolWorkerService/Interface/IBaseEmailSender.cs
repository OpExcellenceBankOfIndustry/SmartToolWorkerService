using BOI_SmartToolWorkerService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_SmartToolWorkerService.Interface
{
    public interface IBaseEmailSender
    {
        Task<bool> SendAsyncSmtpClient(EmailRequest model);
        Task<bool> SendSVCAsyncSmtpClient(EmailRequest model);
    }
}
