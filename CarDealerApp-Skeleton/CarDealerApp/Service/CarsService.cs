using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerApp.Service
{
    using CarDealerApp.ViewModels;

    public class CarsService : Service
    {
        
        public CarsAllViewModel GetAllCarsByModel(string model)
        {
            CarsAllViewModel cavm = new CarsAllViewModel();
            List<CarViewModel> carsList = new List<CarViewModel>();

            foreach (var v in this.Context.Cars.Where(x => x.Make == model).OrderBy(x => x.Model).ThenBy(s => s.TravelledDistance))
            {

                CarViewModel car = new CarViewModel()
                                       {
                                           Id = v.Id,
                                           Model = v.Model,
                                           TravelDistance = v.TravelledDistance
                                       };
                carsList.Add(car);
            }
            cavm.CarViewModels = carsList;
            return cavm;
        }
    }
}