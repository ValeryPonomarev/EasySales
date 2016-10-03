using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Configurator.Nodes
{
    public class RootNode : NodeBase
    {
        public RootNode(ConfiguratorViewModel context, NodeBase parent) : base(context, parent) { }


        public override string Name
        {
            get
            {
                return "EasySales";
            }

            set
            {
            }
        }

        protected override IEnumerable<NodeBase> GetChildNodes()
        {
            yield return new ConfigurationNode(Context, this);
        }

        protected override IEnumerable<IPropertyItem> GetProperties()
        {
            return Enumerable.Empty<IPropertyItem>();
        }
    }
}
