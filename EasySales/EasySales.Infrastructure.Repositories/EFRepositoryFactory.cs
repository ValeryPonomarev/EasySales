using EasySales.Infrastructure.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Infrastructure.Repositories
{
    public static class EFRepositoryFactory
    {
        private static Dictionary<string, object> repositories = new Dictionary<string, object>();

        public static TRepository GetRepository<TRepository, TEntity>()
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

                object[] constructorArgs = null;
                repository = (TRepository)Activator.CreateInstance(repositoryType, constructorArgs);
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
            types.Add("ICustomerRepository", "EasySales.Infrastructure.Repositories.CustomerRepository, EasySales.Infrastructure.Repositories, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null");
        }

        public static Type GetRepositoryType(string interfaceShortTypeName)
        {
            string typeName = types[interfaceShortTypeName];
            return Type.GetType(typeName);
        }
    }
}
