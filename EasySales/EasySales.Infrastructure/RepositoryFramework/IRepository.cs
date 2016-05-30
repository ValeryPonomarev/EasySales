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
        T FindBy(object key);
        IList<T> FindAll();
        void Add(T item);
        T this[object key] { get; set; }
        void Remove(T item);
    }
}
