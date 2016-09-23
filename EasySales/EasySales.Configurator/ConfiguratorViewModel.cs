using EasySales.Configurator.Nodes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EasySales.Configurator
{
    public class ConfiguratorViewModel
    {
        private ObservableCollection<NodeBase> nodes;

        public ConfiguratorViewModel()
        {
            nodes = new ObservableCollection<NodeBase>();
            nodes.Add(new RootNode(this, null));
        }

        public ObservableCollection<NodeBase> Nodes { get { return nodes; } }
    }
}
