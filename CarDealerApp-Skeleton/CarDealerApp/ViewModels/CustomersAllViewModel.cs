using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerApp.ViewModels
{
    public class CustomersAllViewModel
    {
        public CustomersAllViewModel()
        {
            this.Customers = new List<CustomerViewModel>();
        }
        public List<CustomerViewModel> Customers { get; set; }
    }
}