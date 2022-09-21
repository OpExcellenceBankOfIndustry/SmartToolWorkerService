using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_SmartToolWorkerService.Entities
{
    public class EmailRequest
    {
        public string? FromRecipient { get; set; }
        public string? ToRecipient { get; set; }

        public string? CCSupervisorRecipient { get; set; }
        public string? ITSupervisorRecipient { get; set; }
        public string? DHSupervisorRecipient { get; set; }
        public string? CcRecipient { get; set; }
        public string? BccRecipient { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public string? Type { get; set; }
        public bool IsHtml { get; set; }
        public string? smtpHost { get; set; }
        public int smtpPort { get; set; }
        public string? smtpUser { get; set; }
        public string? smtpPassword { get; set; }
        public bool HasAttachment { get; set; }
        public List<EmailAttachmentRequest>? EmailAttachmentsRequest { get; set; }
    }
}
