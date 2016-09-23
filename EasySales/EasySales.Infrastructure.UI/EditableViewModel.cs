using EasySales.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EasySales.Infrastructure.UI
{
    public abstract class EditableViewModel<T> : ViewModel, INotifyPropertyChanged where T : EntityBase
    {
        public enum ObjectState
        {
            New, Existing, Deleted
        }

        #region Private fields
        private const string currentObjectStatePropertyName = "CurrentObjectState";
        private const string currentEntityPropertyName = "CurrentEntity";

        private ObjectState currentObjectState;
        private T currentEntity;
        private DelegateCommand saveCommand;
        #endregion

        #region Constructors
        public EditableViewModel() :this(null)
        {
        }

        public EditableViewModel(IView view) : base(view)
        {
            currentObjectState = ObjectState.Existing;
            currentEntity = default(T);
            saveCommand = new DelegateCommand(SaveCommandHandler);
        }
        #endregion

        #region AbstractMethods
        protected abstract void SaveCurrentEntity(object sender, EventArgs e);
        protected abstract void SetCurrentEntity(T entity);
        #endregion

        #region Properties
        public ObjectState CurrentObjectState
        {
            get {
                return currentObjectState;
            }
            set {
                if (this.currentObjectState != value)
                {
                    this.currentObjectState = value;
                    this.OnPropertyChanged(currentObjectStatePropertyName);
                }
            }
        }

        public T CurrentEntity
        {
            get {
                return this.currentEntity;
            }

            set {
                if(this.currentEntity != value)
                {
                    this.currentEntity = value;
                    SetCurrentEntity(value);
                    this.saveCommand.IsEnabled = (this.currentEntity != null);
                    this.OnPropertyChanged(currentEntityPropertyName);
                }
            }
        }

        public DelegateCommand SaveCommand
        {
            get { return saveCommand; }
        }
        #endregion

        #region Handlers
        protected virtual void SaveCommandHandler(object sender, EventArgs e)
        {
            this.SaveCurrentEntity(sender, e);
            this.currentObjectState = ObjectState.Existing;
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
