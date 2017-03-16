using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerApp.ViewModels
{
    public class SaleViewModel
    {
        public AnyCarViewModel Car { get; set; }

        public CustomerViewModel Customer { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }

    }
}