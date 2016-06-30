using EasySales.Infrastructure.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Model.Customers
{
    public static class CustomerService
    {
        private static ICustomerRepository repository;

        static CustomerService()
        {
            repository = EFRepositoryFactory.GetRepository<ICustomerRepository, Customer>();
        }

        public static IList<Customer> GetAllCustomers()
        {
            return repository.FindAll();
        }

        public static Customer GetCustomer(object key)
        {
            return repository.FindBy(key);
        }

        public static void SaveCustomer(Customer customer)
        {
            repository[customer.Key] = customer;
            repository.Save();
        }
    }
}
