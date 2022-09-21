using BOI_SmartToolWorkerService.ConfigurationModels;
using BOI_SmartToolWorkerService.Entities;
using BOI_SmartToolWorkerService.Interface;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BOI_SmartToolWorkerService.Service
{
    public class BaseEmailSender : IBaseEmailSender
    {
        
        private readonly ILogger<BaseEmailSender> _logger;

        public BaseEmailSender(ILogger<BaseEmailSender> logger)
        {
            _logger = logger;
        }

        public async Task<bool> SendAsyncSmtpClient(EmailRequest model)
        {          
            try
            {
                var mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(model.smtpHost);

                mail.From = new MailAddress(model.FromRecipient != null ? model.FromRecipient : " " );
                mail.To.Add(model.ToRecipient != null ? model.ToRecipient : " ");
                mail.CC.Add(model.CCSupervisorRecipient != null ? model.CCSupervisorRecipient : " ");
                mail.CC.Add(model.CcRecipient != null ? model.CcRecipient : " ");
                mail.Subject = model.Subject;
                mail.Body = model.Body;
                mail.IsBodyHtml = true;
                SmtpServer.Port = model.smtpPort;

                SmtpServer.Credentials = new NetworkCredential(model.smtpUser, model.smtpPassword);

                //SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = true;

                await SmtpServer.SendMailAsync(mail);
                _logger.LogInformation("after calling smtp server", "");

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> SendSVCAsyncSmtpClient(EmailRequest model)
        {
            try
            {
                var mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(model.smtpHost);

                mail.From = new MailAddress(model.FromRecipient != null ? model.FromRecipient : " ");
                mail.To.Add(model.ToRecipient != null ? model.ToRecipient : " ");
                mail.CC.Add(model.CCSupervisorRecipient != null ? model.CCSupervisorRecipient : " ");
                mail.CC.Add(model.ITSupervisorRecipient != null ? model.ITSupervisorRecipient : " ");
                mail.CC.Add(model.DHSupervisorRecipient != null ? model.DHSupervisorRecipient : " ");
                mail.CC.Add(model.CcRecipient != null ? model.CcRecipient : " ");
                mail.Subject = model.Subject;
                mail.Body = model.Body;
                mail.IsBodyHtml = true;
                SmtpServer.Port = model.smtpPort;

                SmtpServer.Credentials = new NetworkCredential(model.smtpUser, model.smtpPassword);

                //SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = true;

                await SmtpServer.SendMailAsync(mail);
                _logger.LogInformation("after calling smtp server", "");

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
