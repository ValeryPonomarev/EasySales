using EasySales.Infrastructure.UI;
using EasySales.Model;
using EasySales.Model.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySales.Presentation.WPF.ViewModels
{
    public class CustomerListViewModel : EditableListViewModel<Customer>
    {
        public CustomerListViewModel() :base(null)
        {
        }

        public CustomerListViewModel(IView view) : base(view)
        {
        }

        protected override Customer BuildNewEntity()
        {
            Customer customer = new Customer();
            customer.DateCreate = DateTime.Now;
            customer.Name = "{Новый контрагент}";
            return customer;
        }

        protected override List<Customer> GetEntitiesList()
        {
            return new List<Customer>(CustomerService.GetAllCustomers());
        }

        protected override void SaveCurrentEntity(object sender, EventArgs e)
        {
            CustomerService.SaveCustomer(this.CurrentEntity);
        }
        /**/
        protected override void SetCurrentEntity(Customer entity)
        {
        }
    }
}
