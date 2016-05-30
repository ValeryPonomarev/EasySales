using EasySales.Infrastructure.DomainBase;
using EasySales.Infrastructure.EF;
using EasySales.Infrastructure.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Infrastructure.Repositories
{
    public abstract class EFSqlCeRepositoryBase<T> : DbContext, IRepository<T> where T : EntityBase
    {
        private DbSet<T> entities;

        protected EFSqlCeRepositoryBase()
        {
        }

        public DbSet<T> Entities
        {
            get { return entities; }
            set { entities = value; }
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
            entities.Add(item);
        }

        public IList<T> FindAll()
        {
            return entities.ToList();
        }

        public T FindBy(object key)
        {
            return entities.Find(key);
        }

        public void Remove(T item)
        {
            entities.Remove(item);
        }
        #endregion
    }
}
