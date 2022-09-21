using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_SmartToolWorkerService.ConfigurationModels
{
    public class EmailSettings
    {
        public string? smtpHost { get; set; }
        public int smtpPort { get; set; }
        public string? EmailFrom { get; set; }
        public string? EmailToURL { get; set; }
        public string? EmailToSVR { get; set; }
        public string? BankName { get; set; }
        public string? smtpUser { get; set; }
        public string? smtpPassword { get; set; }
        public string? EmailCCSupervisor { get; set; }
        public string? EmailITSupervisor { get; set; }
        public string? EmailDHSupervisor { get; set; }
        public string? EmailCCURL { get; set; }
        public string? EmailCCSVR { get; set; }
    }

}
