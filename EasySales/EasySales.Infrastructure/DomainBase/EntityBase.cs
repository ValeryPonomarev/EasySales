using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Infrastructure.DomainBase
{
    public abstract class EntityBase : IEntity
    {
        private object key;

        protected EntityBase() : this(null)
        {
        }

        protected EntityBase(object key)
        {
            this.key = key;
        }

        public object Key
        {
            get { return key; }
        }
    }
}
