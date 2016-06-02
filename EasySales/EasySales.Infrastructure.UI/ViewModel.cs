using System;

namespace EasySales.Infrastructure.UI
{
    public abstract class ViewModel
    {
        private IView view;
        private DelegateCommand cancelCommand;

        public ViewModel() 
            : this(null)
        {
        }

        public ViewModel(IView view)
        {
            this.view = view;
            this.cancelCommand = new DelegateCommand(CancelCommandHandler);
        }

        public DelegateCommand CancelCommand
        {
            get { return cancelCommand; }
        }

        protected virtual void CancelCommandHandler(object sender, EventArgs e)
        {
            this.CloseView();
        }

        protected void CloseView()
        {
            if (view != null)
            {
                view.Close();
            }
        }
    }
}