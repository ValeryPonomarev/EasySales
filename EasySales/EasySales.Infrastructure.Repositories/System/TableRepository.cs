using EasySales.Infrastructure.RepositoryFramework;
using EasySales.Model.System;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Infrastructure.Repositories.System
{
    public class TableRepository : EFSqlCeRepositoryBase<Table>, ITableRepository
    {
        public TableRepository() : base() {
            Database.SetInitializer<TableRepository>(new CreateDatabaseIfNotExists<TableRepository>());
        }

        public Table FindByName(string name)
        {
            return this.Entities.FirstOrDefault(_ => _.Name == name);
        }
    }
}
