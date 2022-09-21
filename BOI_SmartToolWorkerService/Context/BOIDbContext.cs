using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI_SmartToolWorkerService.Context
{
    public class BOIDbContext : DbContext
    {
        public BOIDbContext(DbContextOptions<BOIDbContext> options) : base(options)
        {

        }
    }
}
