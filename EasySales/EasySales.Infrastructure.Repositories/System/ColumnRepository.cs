using EasySales.Model.System;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Infrastructure.Repositories.System
{
    public class ColumnRepository : EFSqlCeRepositoryBase<Column>, IColumnRepository
    {
        public ColumnRepository() : base() {
            Database.SetInitializer<ColumnRepository>(new CreateDatabaseIfNotExists<ColumnRepository>());
        }
    }
}
