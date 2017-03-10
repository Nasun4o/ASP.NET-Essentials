using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerApp.ViewModels
{
    public class SuppliersAllViewModel
    {
        public SuppliersAllViewModel()
        {
            this.Suppliers = new List<SupplierViewModel>();
        }
        public ICollection<SupplierViewModel> Suppliers { get; set; }
    }
}