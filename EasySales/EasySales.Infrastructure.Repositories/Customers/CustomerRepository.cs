using System.Data.Entity;
using EasySales.Model;
using EasySales.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using EasySales.Infrastructure.Repositories.Migrations;
using EasySales.Model.Repositories;

namespace EasySales.Infrastructure.Repositories.Customers
{
    public class CustomerRepository : EFSqlCeRepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository() : base()
        {
            Database.SetInitializer<CustomerRepository>(new CreateDatabaseIfNotExists<CustomerRepository>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CustomerRepository>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CustomerRepository, Configuration>());
        }
    }
}
