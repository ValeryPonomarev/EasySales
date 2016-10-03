using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Configurator
{
    public class PropertyItem<T> : IPropertyItem
    {
        private string name;
        private object value;

        public PropertyItem(string name, T value) {
            this.name = name;
            this.value = value;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public object Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }
    }
}
