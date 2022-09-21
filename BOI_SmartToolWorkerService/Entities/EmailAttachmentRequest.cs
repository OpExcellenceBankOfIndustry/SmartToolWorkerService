using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_SmartToolWorkerService.Entities
{
    public class EmailAttachmentRequest
    {
        public byte[]? Attachment { get; set; }
        public string? ContentType { get; set; }
        public string? FileName { get; set; }
    }
}
