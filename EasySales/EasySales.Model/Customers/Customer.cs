using EasySales.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasySales.Model.Customers
{
    public class Customer: EntityBase, IEntity
    {
        private int id;
        private string name;

        public Customer():this(null)
        {
        }

        public Customer(Guid? key)
            :base(key)
        {
        }

        [Key]
        public override int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
    }
}
