using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerApp.ViewModels
{
    public class CarsAllViewModel
    {
        public CarsAllViewModel()
        {
            this.CarViewModels = new List<CarViewModel>();
        }
        public ICollection<CarViewModel> CarViewModels { get; set; }
    }
}