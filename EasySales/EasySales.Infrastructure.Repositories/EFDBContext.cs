using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Infrastructure.Repositories
{
    public abstract class EFDBContext : DbContext
    {
        static EFDBContext()
        {
            // ROLA - This is a hack to ensure that Entity Framework SQL Provider is copied across to the output folder.
            // As it is installed in the GAC, Copy Local does not work. It is required for probing.
            // Fixed "Provider not loaded" error

            //Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0", "", @"Data Source = c:\EasySales.sdf");
            //Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
            //var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            //var ensureDLLIsCopied2 = System.Data.Entity.SqlServerCompact.SqlCeProviderServices.Instance;
        }

        public EFDBContext() : base()
        {
        }

        public EFDBContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
    }
}
