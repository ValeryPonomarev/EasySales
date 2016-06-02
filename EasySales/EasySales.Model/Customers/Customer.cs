using EasySales.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Model
{
    public class Customer: EntityBase
    {
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
