using EasySales.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Model.System
{
    public class Column : EntityBase, IEntity
    {
        private string name;
        private int tableID;
        private int dataTypeID;
        private Table table;
        private DataType dataType;

        public Column() : base() {
            dataTypeID = 2;//NVarchar
        }
        public Column(Guid key) : base(key) { }

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

        public int TableID
        {
            get
            {
                return tableID;
            }

            set
            {
                tableID = value;
            }
        }

        public int DataTypeID
        {
            get
            {
                return dataTypeID;
            }

            set
            {
                dataTypeID = value;
            }
        }

        public Table Table
        {
            get
            {
                return table;
            }

            set
            {
                table = value;
            }
        }

        public DataType DataType
        {
            get
            {
                return dataType;
            }

            set
            {
                dataType = value;
            }
        }
    }
}
