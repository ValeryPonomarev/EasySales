using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Infrastructure.DomainBase
{
    public abstract class EntityBase : IEntity
    {
        protected EntityBase() : this(null)
        {
        }

        protected EntityBase(Guid? key)
        {
            if (!key.HasValue) {
                Key = NewKey();
            }
            else {
                this.Key = key.Value;
            }
            this.DateCreate = DateTime.Now;
            this.DateEdit = DateTime.Now;
        }

        public virtual int Id { get; set; }
        public virtual Guid Key { get; set; }
        public virtual DateTime DateEdit { get; set; }
        public virtual DateTime DateCreate { get; private set; }
        
        protected virtual Guid NewKey()
        {
            return Guid.NewGuid();
        }

        #region Equiality
        public override bool Equals(object entity)
        {
            return entity != null
                && entity is EntityBase
                && this == (EntityBase)entity;
        }

        public static bool operator ==(EntityBase base1, EntityBase base2)
        {
            if ((object)base1 == null && (object)base2 == null)
            {
                return true;
            }

            if ((object)base1 == null || (object)base2 == null)
            {
                return false;
            }

            if (!base1.Key.Equals(base2.Key))
            {
                return false;
            }
            return true;
        }

        public static bool operator !=(EntityBase base1, EntityBase base2)
        {
            return (!(base1 == base2));
        }

        public override int GetHashCode()
        {
            if (this.Key != null)
            {
                return this.Key.GetHashCode();
            }
            else
            {
                return 0;
            }
        }
        #endregion
    }
}
