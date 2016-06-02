using EasySales.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EasySales.Infrastructure.UI
{
    public abstract class ListViewModel<T> : EditableViewModel<T> where T: EntityBase
    {
        #region Private fields
        private IView view;
        private DelegateCommand newCommand;
        private IList<T> entitiesList;
        private CollectionView entitiesView;
        #endregion

        #region Constructors
        public ListViewModel():this(null)
        {

        }

        public ListViewModel(IView view) : base(view)
        {
            this.view = view;
            newCommand = new DelegateCommand(SaveCommandHandler);
            entitiesList = this.GetEntitiesList();
        }
        #endregion

        #region Abstract methods
        protected abstract T BuildNewEntity();
        protected abstract List<T> GetEntitiesList();
        #endregion

        #region Properties
        public IList<T> EntitiesList
        {
            get { return entitiesList; }
        }

        public CollectionView EntitiesView
        {
            get { return entitiesView; }
        }

        public DelegateCommand NewCommand
        {
            get { return newCommand; }
        }
        #endregion

        #region Handlers
        protected virtual void SaveCommandHandler()
        {
            this.CurrentObjectState = ObjectState.New;
            this.entitiesList.Add(this.BuildNewEntity());
            this.CurrentEntity = null;
            this.entitiesView.Refresh();
            this.entitiesView.MoveCurrentToLast();
        }
        #endregion
    }
}
