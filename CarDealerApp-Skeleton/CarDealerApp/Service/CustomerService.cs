using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerApp.Service
{
    using AutoMapper;
    using CarDealer.Models;
    using CarDealerApp.BindingModels;
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

        public TotalSalesByCustomerViewModel TotalSalesByCustomer(int id)
        {
            Customer customer;
            customer = this.Context.Customers.Find(id);

            TotalSalesByCustomerViewModel model = new TotalSalesByCustomerViewModel()
                                                      {
                                                          BoughtCars =
                                                              customer.Sales.Count,
                                                          MoneySpent =
                                                              customer.Sales.Sum(
                                                                  x =>
                                                                  x.Car.Parts.Sum(
                                                                      a => a.Price)),
                                                          Name = customer.Name
                                                      };
            return model;

        }

        public void AddUser(AddUserBindingModel addUserBindingModel)
        {
            var timeNow = DateTime.Now.Year;
            var eligbleForLicense = addUserBindingModel.BirthDate.Year + 18;
            if ((timeNow - eligbleForLicense) > 2)
            {
                var newUser = new Customer() { Name = addUserBindingModel.Name, BirthDate = addUserBindingModel.BirthDate, IsYoungDriver = false };
                this.Context.Customers.Add(newUser);
            }
            else
            {
                var newUser = new Customer() { Name = addUserBindingModel.Name, BirthDate = addUserBindingModel.BirthDate, IsYoungDriver = true };
                this.Context.Customers.Add(newUser);
            }

            this.Context.SaveChanges();
        }

        public EditUserViewModel EditUser(int id)
        {
            Customer user = this.Context.Customers.Find(id);
            EditUserViewModel model = Mapper.Instance.Map<Customer, EditUserViewModel>(user);
            return model;
        }
        public void Edit(AddUserBindingModel bind)
        {
            Customer user = this.Context.Customers.Find(bind.Id);

            if (user == null)
            {
                throw new ArgumentException("Cannot find customer with such id !!");
            }
            user.Name = bind.Name;
            user.BirthDate = bind.BirthDate;
            this.Context.SaveChanges();
        }
    }
}