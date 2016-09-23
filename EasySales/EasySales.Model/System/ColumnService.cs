using EasySales.Infrastructure.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Model.System
{
    public static class ColumnService
    {
        private static IColumnRepository repository;

        static ColumnService()
        {
            repository = EFRepositoryFactory.GetRepository<IColumnRepository, Column>();
        }
        
        public static IList<Column> GetAll()
        {
            return repository.FindAll();
        }

        public static void SaveColumn(Column column)
        {
            repository[column.Key] = column;
            repository.Save();
        }

        public static void RemoveColumn(Column column)
        {
            repository.Remove(column);
            repository.Save();
        }
    }
}
