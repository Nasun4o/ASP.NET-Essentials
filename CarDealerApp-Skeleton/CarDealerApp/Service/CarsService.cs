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
            if (model == null)
            {
                foreach (var v in this.Context.Cars.OrderBy(x => x.Model).ThenBy(s => s.TravelledDistance))
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
        public CarPartsAllViewModel GetAllCarsById(int id)
        {
            CarPartsAllViewModel cpvm = new CarPartsAllViewModel();
            var item = this.Context.Cars.Where(s => s.Id == id).First();



            CarPartsViewModel model = new CarPartsViewModel()
            {
                Id = item.Id,
                Make = item.Make,
                Model = item.Model,
                TravellDistance = item.TravelledDistance,
                //SHould set Parts

            };
            foreach (var i in item.Parts)
            {
                PartsViewModel view = new PartsViewModel()
                {
                    Name = i.Name,
                    Price = i.Price
                };
                model.Parts.Add(view);
            }


            cpvm.CarParts = model;
            return cpvm;
        }
    }
}