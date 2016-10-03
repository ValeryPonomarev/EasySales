using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Configurator
{
    public interface IPropertyItem
    {
        string Name { get; }
        object Value { get; set; }
    }
}
