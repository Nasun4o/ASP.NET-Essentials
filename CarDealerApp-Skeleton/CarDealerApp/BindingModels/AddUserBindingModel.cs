using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerApp.BindingModels
{
    public class AddUserBindingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsYoungDriver { get; set; }

    }
}