using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_SmartToolWorkerService.Interface
{
    public interface IInitiateBaseProcess
    {
        Task<bool> Start();
    }
}
