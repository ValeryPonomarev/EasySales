using EasySales.Infrastructure.DomainBase;
using EasySales.Infrastructure.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Infrastructure.RepositoryFramework
{
    public static class EFRepositoryFactory
    {
        private static Dictionary<string, object> repositories = new Dictionary<string, object>();

        public static TRepository GetRepository<TRepository, TEntity>() where TRepository : class, IRepository<TEntity>
                                                                        where TEntity : EntityBase
        {
            TRepository repository = default(TRepository);
            string interfaceShortName = typeof(TRepository).Name;

            if (!repositories.ContainsKey(interfaceShortName))
            {
                Type repositoryType = EFRepositoryMapping.GetRepositoryType(interfaceShortName);

                if (repositoryType == null)
                {
                    throw new ArgumentException("Cannot create repository. Repository does not exists in RepositoryMappings");
                }

                repository = Activator.CreateInstance(repositoryType) as TRepository;
                repositories.Add(interfaceShortName, repository);
            }
            else
            {
                repository = (TRepository)repositories[interfaceShortName];
            }

            return repository;
        }
    }

    internal static class EFRepositoryMapping
    {
        private static Dictionary<string, string> types;

        static EFRepositoryMapping()
        {
            types = new Dictionary<string, string>();
            types.Add("ICustomerRepository", "EasySales.Infrastructure.Repositories.Customers.CustomerRepository, EasySales.Infrastructure.Repositories, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null");
        }

        public static Type GetRepositoryType(string interfaceShortTypeName)
        {
            string typeName = types[interfaceShortTypeName];
            return Type.GetType(typeName);
        }
    }
}