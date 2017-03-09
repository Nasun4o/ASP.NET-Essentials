using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerApp.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public long TravelDistance { get; set; }
    }
}