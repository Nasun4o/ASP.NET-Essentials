using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerApp.ViewModels
{
    public class CarPartsViewModel
    {
        public CarPartsViewModel()
        {
            this.Parts = new List<PartsViewModel>();
        }
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public long TravellDistance { get; set; }
        public ICollection<PartsViewModel> Parts { get; set; }
    }
}