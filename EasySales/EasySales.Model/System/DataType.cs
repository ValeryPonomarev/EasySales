using EasySales.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Model.System
{
    public class DataType : EntityBase, IEntity
    {
        private SqlDataType sqlDataType;
        private string caption;

        public DataType() : base() { }
        public DataType(Guid key) : base(key) { }

        public SqlDataType SqlDataType
        {
            get
            {
                return sqlDataType;
            }

            set
            {
                sqlDataType = value;
            }
        }

        public string Caption
        {
            get
            {
                return caption;
            }

            set
            {
                caption = value;
            }
        }
    }
}
