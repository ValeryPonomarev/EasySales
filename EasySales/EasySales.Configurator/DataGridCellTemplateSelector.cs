using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EasySales.Configurator
{
    public class DataGridCellTemplateSelector : DataTemplateSelector
    {
        public DataTemplate StringTemplate { get; set; }
        public DataTemplate IntTemplate { get; set; }


        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is IPropertyItem)
            {
                IPropertyItem property = (IPropertyItem)item;
                if (property.Value is string) { return this.StringTemplate; }
                else if (property.Value is int) { return IntTemplate; }
            }

            return StringTemplate;
        }
    }
}
