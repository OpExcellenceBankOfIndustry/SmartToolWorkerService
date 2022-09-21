using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_SmartToolWorkerService.ConfigurationModels
{
    public class SmartBotSettings
    {
        public string? BonitaURL { get; set; }
        public string? BonitaServerIP { get; set; }
        public int checkURLTime { get; set; }
        public int checkServerTime { get; set; }
        public int restTime { get; set; }
    }
}
