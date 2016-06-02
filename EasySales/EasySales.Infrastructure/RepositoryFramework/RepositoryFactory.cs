using EasySales.Infrastructure.DomainBase;
using EasySales.Infrastructure.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Infrastructure.RepositoryFramework
{
    public abstract class RepositoryFactory
    {
        public abstract TRepository GetRepository<TRepository, TEntity>()
            where TRepository : IRepository<TEntity>
            where TEntity : EntityBase;
    }
}
