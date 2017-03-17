using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerApp.ViewModels
{
    public class DeletePartViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
    }
}