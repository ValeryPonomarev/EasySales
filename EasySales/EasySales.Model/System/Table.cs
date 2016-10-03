using EasySales.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Model.System
{
    public class Table : EntityBase, IEntity
    {
        private string name;

        public Table() : base() { }
        public Table(Guid key) : base(key) { }

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

        public virtual ICollection<Column> Columns { get; set; }
    }
}
