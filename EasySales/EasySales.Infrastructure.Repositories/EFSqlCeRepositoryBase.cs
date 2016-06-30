using EasySales.Infrastructure.DomainBase;
using EasySales.Infrastructure.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Infrastructure.Repositories
{
    public abstract class EFSqlCeRepositoryBase<T> : DbContext, IRepository<T> where T : EntityBase
    {
        static EFSqlCeRepositoryBase()
        {
            
        }

        protected EFSqlCeRepositoryBase()
        {
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
        }

        public DbSet<T> Entities
        {
            get;
            set;
        }

        #region IRepository implementation

        public T this[object key]
        {
            get
            {
                return FindBy(key);
            }

            set
            {
                T entity = FindBy(key);
                if (entity == null)
                {
                    Add(value);
                }
                else
                {
                    entity = value;
                }
            }
        }

        public void Add(T item)
        {
            Entities.Add(item);
        }

        public IList<T> FindAll()
        {
            return Entities.ToList();
        }

        public T FindBy(object key)
        {
            return Entities.Find(key);
        }

        public void Remove(T item)
        {
            Entities.Remove(item);
        }

        public void Save()
        {
            this.SaveChanges();
        }
        #endregion
    }
}
