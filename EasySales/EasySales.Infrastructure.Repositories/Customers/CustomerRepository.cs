using EasySales.Model;
using EasySales.Model.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Infrastructure.Repositories.Customers
{
    public class CustomerRepository : EFSqlCeRepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository() : base()
        {
            
        } 
    }
}
