using EasySales.Infrastructure.Repositories.Customers;
using EasySales.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Infrastructure.Repositories
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CustomerRepository())
            {
                db.Entities.Add(new Customer { Name = "Test" });
                db.SaveChanges();

                foreach (var customer in db.FindAll())
                {
                    Console.WriteLine(string.Format("Customer {0}, {1}", customer.Name, customer.DateCreate.ToShortDateString()));
                }
            }
            Console.ReadLine();
        }
    }
}
