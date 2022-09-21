using BOI_SmartToolWorkerService.ConfigurationModels;
using BOI_SmartToolWorkerService.Entities;
using BOI_SmartToolWorkerService.Interface;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_SmartToolWorkerService.Service
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;
        private readonly ILogger<EmailSender> _logger;
        private readonly IBaseEmailSender _baseEmail;

        public EmailSender(IOptions<EmailSettings> options, ILogger<EmailSender> logger, IBaseEmailSender baseEmail)
        {
            _emailSettings = options.Value;
            _logger = logger;
            _baseEmail = baseEmail;
        }

        public async Task<bool> SendEmailBonitaURLDownAsync(string url)
        {
            try
            {
                var email = new EmailRequest()
                {
                    smtpHost = _emailSettings.smtpHost,
                    smtpPort = _emailSettings.smtpPort,
                    smtpUser = _emailSettings.smtpUser,
                    smtpPassword = _emailSettings.smtpPassword,

                    FromRecipient = _emailSettings.EmailFrom,
                    ToRecipient = _emailSettings.EmailToURL,
                    CCSupervisorRecipient = _emailSettings.EmailCCSupervisor,
                    CcRecipient = _emailSettings.EmailCCURL,
                    Subject = "WARNING ALERT 🚦🚧⚠ 🙆‍♂️👉  BONITA LINK IS DOWN ",
                    Body = $"<hr><br><strong> Dear Team </strong><br><br><p> Kindly note that Bonita Portal is not reachable.  Here is the Link: {url}</p><p> Please assist ensure that the portal is up and running. Thanks</p><br><strong> Kind Regards </strong><br><small><strong> BOI Smart Bot </strong></small><br><hr> ",
                };

                if (await _baseEmail.SendAsyncSmtpClient(email)) 
                { 
                    return true; 
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> SendEmailBonitaServerDownAsync(string ipAddress)
        {
            try
            {
                var email = new EmailRequest()
                {
                    smtpHost = _emailSettings.smtpHost,
                    smtpPort = _emailSettings.smtpPort,
                    smtpUser = _emailSettings.smtpUser,
                    smtpPassword = _emailSettings.smtpPassword,

                    FromRecipient = _emailSettings.EmailFrom,
                    ToRecipient = _emailSettings.EmailToSVR,
                    CCSupervisorRecipient = _emailSettings.EmailCCSupervisor,
                    ITSupervisorRecipient = _emailSettings.EmailITSupervisor,
                    DHSupervisorRecipient = _emailSettings.EmailDHSupervisor,
                    CcRecipient = _emailSettings.EmailCCSVR,
                    Subject = "WARNING ALERT 🚦 ⚠ 🙆‍♂ 👉  BONITA SERVER IS DOWN ",
                    Body = $"<hr><br><strong>Dear Team </strong><br><br><p>Kindly note that Bonita Server is down and not reachable. Here is the server IP Address: {ipAddress}</p><p>Please assist ensure that the server is up and running. Thanks</p><br><strong> Kind Regards </strong><br><small><strong> BOI Smart Bot </strong></small><br><hr> ",
                };

                if (await _baseEmail.SendSVCAsyncSmtpClient(email))
                {
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
