using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerApp.Service
{
    using CarDealerApp.ViewModels;

    public class CustomerService : Service
    {
        public CustomersAllViewModel GeneretaCustomerViewModel()
        {
            CustomersAllViewModel cavm = new CustomersAllViewModel();

            List<CustomerViewModel> lkvm = new List<CustomerViewModel>();

            foreach (var v in this.Context.Customers)
            {
                CustomerViewModel cvm = new CustomerViewModel()
                {

                    BirthDate = v.BirthDate,
                    IsYoungDriver = v.IsYoungDriver,
                    Name = v.Name,
                    Id = v.Id
                };
                lkvm.Add(cvm);

            }
            cavm.Customers = lkvm;
            return cavm;
        }

        public CustomersAllViewModel OrderBy(string order)
        {
            CustomersAllViewModel cavm = new CustomersAllViewModel();

            List<CustomerViewModel> lkvm = new List<CustomerViewModel>();

            if (order == "Ascending" || order == "ascending")
            {
                foreach (var v in this.Context.Customers.OrderBy(x => x.BirthDate).ThenBy(s => s.IsYoungDriver))
                {
                    CustomerViewModel cvm = new CustomerViewModel()
                    {
                        BirthDate = v.BirthDate,
                        IsYoungDriver = v.IsYoungDriver,
                        Name = v.Name,
                        Id = v.Id
                    };
                    lkvm.Add(cvm);

                }
            }
            else
            {
                foreach (var v in this.Context.Customers.OrderByDescending(x => x.BirthDate).ThenByDescending(s => s.IsYoungDriver))
                {
                    CustomerViewModel cvm = new CustomerViewModel()
                    {
                        BirthDate = v.BirthDate,
                        IsYoungDriver = v.IsYoungDriver,
                        Name = v.Name,
                        Id = v.Id
                    };
                    lkvm.Add(cvm);

                }
            }
         
            cavm.Customers = lkvm;
            return cavm;
        }
    }
}