using EasySales.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EasySales.Infrastructure.UI
{
    public abstract class EditableListViewModel<T> : EditableViewModel<T> where T: EntityBase
    {
        #region Private fields
        private IView view;
        private List<T> entitiesList;
        private ListCollectionView entitiesView;
        private DelegateCommand newCommand;
        private DelegateCommand deleteCommand;
        #endregion

        #region Constructors
        public EditableListViewModel():this(null)
        {

        }

        public EditableListViewModel(IView view) : base(view)
        {
            this.view = view;
            newCommand = new DelegateCommand(NewCommandHandler);
            entitiesList = this.GetEntitiesList();
            entitiesView = new ListCollectionView(entitiesList);
            deleteCommand = new DelegateCommand(DeleteCommandHandler);
        }
        #endregion

        #region Abstract methods
        protected abstract T BuildNewEntity();
        protected abstract List<T> GetEntitiesList();
        protected abstract void DeleteEntity(T entity);
        #endregion

        #region Properties
        public List<T> EntitiesList
        {
            get { return entitiesList; }
        }

        public ListCollectionView EntitiesView
        {
            get { return entitiesView; }
        }

        public DelegateCommand NewCommand
        {
            get { return newCommand; }
        }

        public DelegateCommand DeleteCommand
        {
            get { return deleteCommand; }
        }
        #endregion

        #region Handlers
        protected virtual void NewCommandHandler(object sender, EventArgs e)
        {
            this.CurrentObjectState = ObjectState.New;
            this.entitiesList.Add(this.BuildNewEntity());
            this.CurrentEntity = null;
            this.entitiesView.Refresh();
            this.entitiesView.MoveCurrentToLast();
        }

        protected virtual void DeleteCommandHandler(object sender, EventArgs e)
        {
            this.CurrentObjectState = ObjectState.Deleted;
            this.DeleteEntity(CurrentEntity);
            this.entitiesList.Remove(CurrentEntity);
            this.CurrentEntity = null;
            this.entitiesView.Refresh();
            this.entitiesView.MoveCurrentToPrevious();
        }
        #endregion
    }
}
