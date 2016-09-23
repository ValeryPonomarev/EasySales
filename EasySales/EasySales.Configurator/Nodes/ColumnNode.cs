using EasySales.Infrastructure.UI;
using EasySales.Model.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Configurator.Nodes
{
    public class ColumnNode : NodeBase
    {
        public ColumnNode(ConfiguratorViewModel context, NodeBase parent, Column column) : base(context, parent, column)
        {
            this.AddAction(new EntityAction("Удалить столбец", new DelegateCommand(RemoveColumn)));
        }

        public override string Name
        {
            get
            {
                return ((Column)Entity).Name;
            }

            set
            {
                ((Column)Entity).Name = value;
            }
        }

        protected override IEnumerable<NodeBase> GetChildNodes()
        {
            return Enumerable.Empty<NodeBase>();
        }

        private void RemoveColumn(object sender, DelegateCommandEventArgs args)
        {
            ColumnService.RemoveColumn((Column)Entity);
            RemoveNode();
        }
    }
}
