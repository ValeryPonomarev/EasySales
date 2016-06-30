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
        private DelegateCommand newCommand;
        private List<T> entitiesList;
        private ObservableCollection<T> entitiesView;
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
            entitiesView = new ObservableCollection<T>(entitiesList);
        }
        #endregion

        #region Abstract methods
        protected abstract T BuildNewEntity();
        protected abstract List<T> GetEntitiesList();
        #endregion

        #region Properties
        public List<T> EntitiesList
        {
            get { return entitiesList; }
        }

        public ObservableCollection<T> EntitiesView
        {
            get { return entitiesView; }
        }

        public DelegateCommand NewCommand
        {
            get { return newCommand; }
        }
        #endregion

        #region Handlers
        protected virtual void NewCommandHandler(object sender, EventArgs e)
        {
            this.CurrentObjectState = ObjectState.New;
            this.entitiesList.Add(this.BuildNewEntity());
            this.CurrentEntity = null;
            //this.entitiesView.Refresh();
            //this.entitiesView.MoveCurrentToLast();
        }
        #endregion
    }
}
