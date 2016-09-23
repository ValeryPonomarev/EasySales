using EasySales.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Model
{
    public class StudentGroup : EntityBase, IEntity
    {
        private string name;

        public StudentGroup(Guid? key) :base(key)
        {
            name = String.Empty;
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

        public virtual ICollection<Student> Students { get; set; }
    }
}
