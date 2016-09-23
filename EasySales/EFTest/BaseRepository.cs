using EasySales.Infrastructure.DomainBase;
using EasySales.Infrastructure.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest
{
    public abstract class BaseRepository<T> : DbContext, IRepository<T> where T : EntityBase
    {
        protected BaseRepository()
            : base("SqlServer")
        {
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

        T IRepository<T>.this[Guid key]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public T FindBy(Guid key)
        {
            throw new NotImplementedException();
        }

        public T FindById(int id)
        {
            throw new NotImplementedException();
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
