using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySales.Infrastructure.DomainBase;

namespace EasySales.Configurator.Nodes
{
    public class ConfigurationNode : NodeBase
    {
        public ConfigurationNode(ConfiguratorViewModel context, NodeBase parent) : base(context, parent) { }

        public override string Name
        {
            get
            {
                return "Конфигурация";
            }

            set
            {
            }
        }

        protected override IEnumerable<NodeBase> GetChildNodes()
        {
            yield return new TablesNode(Context, this);
        }

    }
}
