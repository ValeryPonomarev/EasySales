using EasySales.Infrastructure.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Presentation.WPF.ViewModels
{
    public class CustomerListViewModel : ViewModel
    {
        public CustomerListViewModel() :base(null)
        {
        }

        public CustomerListViewModel(IView view) : base(view)
        {
        }
    }
}
