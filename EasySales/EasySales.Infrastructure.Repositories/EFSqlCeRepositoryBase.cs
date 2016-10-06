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
    public abstract class EFSqlCeRepositoryBase<T> : EFDBContext, IRepository<T> where T : EntityBase
    {
        protected EFSqlCeRepositoryBase() : base("name=EasySalesSqlServer") { }

        public DbSet<T> Entities
        {
            get;
            set;
        }

        #region IRepository implementation

        public T this[Guid key]
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

        public T FindBy(Guid key)
        {
            return Entities.FirstOrDefault(_=>_.Key == key);
        }

        public T FindById(int id)
        {
            return Entities.FirstOrDefault(_ => _.Id == id);
        }

        public void Remove(T item)
        {
            Entities.Remove(item);
        }

        public void Save()
        {
            -+this.SaveChanges();
        }
        #endregion
    }
}