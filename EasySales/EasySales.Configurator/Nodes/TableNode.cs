using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySales.Infrastructure.DomainBase;
using EasySales.Model.System;
using EasySales.Infrastructure.RepositoryFramework;
using EasySales.Infrastructure.UI;

namespace EasySales.Configurator.Nodes
{
    public class TableNode : NodeBase
    {
        public TableNode(ConfiguratorViewModel context, NodeBase parent, Table entity) : base(context, parent, entity)
        {
            this.AddAction(new EntityAction("Удалить таблицу", new DelegateCommand(RemoveTable)));
        }

        public override string Name
        {
            get
            {
                return ((Table)Entity).Name;
            }

            set
            {
                ((Table)Entity).Name = value;
            }
        }

        protected override IEnumerable<NodeBase> GetChildNodes()
        {
            yield return new ColumnsNode(Context, this, (Table)Entity);
        }

        private void RemoveTable(object sender, DelegateCommandEventArgs args)
        {
            TableService.RemoveTable((Table)Entity);
            RemoveNode();
        }
    }
}
