using EasySales.Infrastructure.UI;
using EasySales.Model.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Configurator.Nodes
{
    class ColumnsNode : NodeBase
    {
        public ColumnsNode(ConfiguratorViewModel context, NodeBase parent, Table table) : base(context, parent, table) {
            this.AddAction(new EntityAction("Добавить столбец", new DelegateCommand(AddColumn)));
        }

        public override string Name
        {
            get
            {
                return "Столбцы";
            }

            set { }
        }

        protected override IEnumerable<NodeBase> GetChildNodes()
        {
            if (((Table)this.Entity).Columns != null) {
                foreach (Column column in ((Table)this.Entity).Columns) {
                    yield return new ColumnNode(Context, this, column);
                }
            }
        }

        protected override IEnumerable<IPropertyItem> GetProperties()
        {
            PropertyItem<string> name = new PropertyItem<string>("Наименование", "Колонка");
            yield return name;
        }

        private void AddColumn(object sender, DelegateCommandEventArgs args) {
            Column column = new Column();
            column.Name = "NewColumn";
            column.Table = (Table)Entity;
            ColumnService.SaveColumn(column);
            ColumnNode node = new ColumnNode(Context, this, column);
            this.ChildNodes.Add(node);
        }
    }
}
