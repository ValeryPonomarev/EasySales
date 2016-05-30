using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySalesTest
{

    public class WorkContext : DbContext
    {
        public DbSet<Work> Works { get; set; }
        public DbSet<WorkProject> Projects { get; set; }
    }
}
