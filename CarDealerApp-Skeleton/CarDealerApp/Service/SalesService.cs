using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerApp.Service
{
    using System.Collections;
    using CarDealer.Models;
    using CarDealerApp.ViewModels;

    public class SalesService : Service
    {
     
        public SaleViewModel GetAllSales()
        {
            IEnumerable<Sale> sales = this.Context.Sales;
            SaleViewModel model = new SaleViewModel();
            foreach (var v in sales)
            {
                model = new SaleViewModel()
                {
                    Car =
                                                 new AnyCarViewModel()
                                                 {
                                                     Make = v.Car.Make,
                                                     Model = v.Car.Model,
                                                     TravellDistance =
                                                             v.Car.TravelledDistance
                                                 },
                    Customer =
                                                 new CustomerViewModel()
                                                 {
                                                     BirthDate =
                                                             v.Customer.BirthDate,
                                                     IsYoungDriver =
                                                             v.Customer
                                                             .IsYoungDriver,
                                                     Name = v.Customer.Name
                                                 },
                    Discount = v.Discount,
                    Price = 20
                };
             
            }
            return model;
        }
    }
}