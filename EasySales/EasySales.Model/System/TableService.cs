using EasySales.Infrastructure.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Model.System
{
    public static class TableService
    {
        private static ITableRepository repository;

        static TableService()
        {
            repository = EFRepositoryFactory.GetRepository<ITableRepository, Table>();
        }

        public static IList<Table> GetAll() {
            return repository.FindAll();
        }

        public static void SaveTable(Table table)
        {
            table.DateEdit = DateTime.Now;
            repository[table.Key] = table;
            repository.Save();
        }

        public static void RemoveTable(Table table) {
            repository.Remove(table);
            repository.Save();
        }
    }
}
