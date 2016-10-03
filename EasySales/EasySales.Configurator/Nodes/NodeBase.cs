using EasySales.Infrastructure.DomainBase;
using EasySales.Infrastructure.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Configurator.Nodes
{
    public abstract class NodeBase
    {
        private ConfiguratorViewModel context;
        private string name;
        private EntityBase entity;
        private ObservableCollection<NodeBase> childNodes;
        private IList<EntityAction> actions;
        private NodeBase parentNode;
        private ObservableCollection<IPropertyItem> properties;

        public NodeBase(ConfiguratorViewModel context, NodeBase parent) : this(context, parent, null) { }

        public NodeBase(ConfiguratorViewModel context, NodeBase parent, EntityBase entity)
        {
            this.context = context;
            this.parentNode = parent;
            this.entity = entity;
            childNodes = new ObservableCollection<NodeBase>(GetChildNodes());
            actions = new List<EntityAction>();
            properties = new ObservableCollection<IPropertyItem>(GetProperties());
        }

        public abstract string Name { get; set; }
        protected abstract IEnumerable<NodeBase> GetChildNodes();
        protected abstract IEnumerable<IPropertyItem> GetProperties();

        public EntityBase Entity
        {
            get
            {
                return entity;
            }

            set
            {
                entity = value;
            }
        }

        public virtual ObservableCollection<NodeBase> ChildNodes
        {
            get {
                return childNodes;
            }

            set {
                childNodes = value;
            }
        }

        public virtual IEnumerable<EntityAction> Actions {
            get
            {
                return actions;
            }
        }

        public virtual IEnumerable<PropertyItem<string>> Properties {
            get { yield return new PropertyItem<string>("name", "values"); }
        }

        protected ConfiguratorViewModel Context { get { return context; } }

        protected NodeBase ParentNode {
            get { return parentNode; }
            set { parentNode = value; }
        }

        protected void AddAction(EntityAction action) {
            this.actions.Add(action);
        }

        protected void RemoveNode() {
            if (this.ParentNode != null) {
                this.ParentNode.ChildNodes.Remove(this);
            }
        }
    }
}
