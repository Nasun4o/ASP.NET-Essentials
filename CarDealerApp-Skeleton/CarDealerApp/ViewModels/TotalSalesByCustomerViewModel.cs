using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerApp.ViewModels
{
    public class TotalSalesByCustomerViewModel
    {
        public string Name { get; set; }

        public int BoughtCars { get; set; }

        public double? MoneySpent { get; set; }

    }
}