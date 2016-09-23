using EasySales.Infrastructure.UI;
using EasySales.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EasySales.Model.Customers;

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
            customer.Name = "{Новый контрагент}";
            return customer;
        }

        protected override List<Customer> GetEntitiesList()
        {
            return new List<Customer>(CustomerService.GetAllCustomers());
        }

        protected override void DeleteEntity(Customer entity)
        {
            CustomerService.DeleteCustomer(entity);
        }

        protected override void SaveCurrentEntity(object sender, EventArgs e)
        {
            CustomerService.SaveCustomer(this.CurrentEntity);
        }

        protected override void SetCurrentEntity(Customer entity)
        {
        }
    }
}
