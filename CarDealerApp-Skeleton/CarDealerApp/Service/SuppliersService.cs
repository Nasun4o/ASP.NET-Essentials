using CarDealerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerApp.Service
{
    public class SuppliersService : Service
    {

       public SuppliersAllViewModel GetSuppliers(string supplier)
        {
            SuppliersAllViewModel savm = new SuppliersAllViewModel();
            List<SupplierViewModel> listOfSuppliers = new List<SupplierViewModel>();

            if (supplier == "local")
            {
                foreach (var item in this.Context.Suppliers.Where(s => s.IsImporter == false))
                {
                    SupplierViewModel model = new SupplierViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        NumberOfParts = item.Parts.Count,
                    };
                    listOfSuppliers.Add(model);
                }
                savm.Suppliers = listOfSuppliers;
                return savm;
            }
            else
            {
                foreach (var item in this.Context.Suppliers.Where(s => s.IsImporter == true))
                {
                    SupplierViewModel model = new SupplierViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        NumberOfParts = item.Parts.Count,
                    };
                    listOfSuppliers.Add(model);
                }
                savm.Suppliers = listOfSuppliers;
                return savm;
            }
           
        }
    }
}