using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new EasySales.Infrastructure.Repositories.Customers.CustomerRepository())
            {
                db.Entities.Add(new EasySales.Model.Customers.Customer { Name = "Test", DateCreate = DateTime.Now });
                db.SaveChanges();

                foreach (var customer in db.Entities)
                {
                    Console.WriteLine(string.Format("Customer {0}, {1}", customer.Name, customer.DateCreate.ToShortDateString()));
                }
            }
            Console.ReadLine();
        }
    }
}
