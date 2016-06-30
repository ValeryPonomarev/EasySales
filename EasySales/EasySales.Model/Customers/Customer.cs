using EasySales.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Model.Customers
{
    public class Customer: EntityBase
    {
        public Customer():this(null)
        {
        }

        public Customer(object key)
            :base(key)
        {
            this.DateCreate = DateTime.Now;
        }

        
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
