using EasySales.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Infrastructure.RepositoryFramework
{
    public interface IRepository<T> where T : IEntity
    {
        T FindBy(Guid key);
        T FindById(int id);
        IList<T> FindAll();
        void Add(T item);
        T this[Guid key] { get; set; }
        void Remove(T item);
        void Save();
    }
}
