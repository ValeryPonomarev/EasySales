using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySales.Model.System;
using EasySales.Infrastructure.UI;

namespace EasySales.Configurator.Nodes
{
    public class TablesNode : NodeBase
    {
        public TablesNode(ConfiguratorViewModel context, NodeBase parent) : base(context, parent)
        {
            this.AddAction(new EntityAction("Добавить таблицу", new DelegateCommand(AddTable)));
        }

        protected override IEnumerable<NodeBase> GetChildNodes()
        {
            foreach (Table table in TableService.GetAll())
            {
                yield return new TableNode(Context, this, table);
            }
        }

        protected override IEnumerable<IPropertyItem> GetProperties()
        {
            return Enumerable.Empty<IPropertyItem>();
        }

        public override string Name
        {
            get
            {
                return "Таблицы";
            }

            set { }
        }

        private void AddTable(object sender, DelegateCommandEventArgs args)
        {
            Table table = new Table();
            table.Name = "NewTable";
            TableService.SaveTable(table);
            TableNode node = new TableNode(Context, this, table);
            this.ChildNodes.Add(node);
        }

    }
}
