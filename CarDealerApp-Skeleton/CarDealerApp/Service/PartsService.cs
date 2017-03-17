using CarDealer.Models;
using CarDealerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CarDealerApp.BindingModels;

namespace CarDealerApp.Service
{
    public class PartsService : Service
    {
        public IEnumerable<AllPartsViewModel> GetAllParts()
        {
            IEnumerable<Part> parts = this.Context.Parts;
            IEnumerable<AllPartsViewModel> vms = Mapper.Map<IEnumerable<Part>, IEnumerable<AllPartsViewModel>>(parts);
            return vms;
        }

        public DeletePartViewModel DeleteViewModel(int id)
        {
            Part model = this.Context.Parts.Find(id);
            DeletePartViewModel vm = Mapper.Map<Part, DeletePartViewModel>(model);
            return vm;
        }

        public void DeletePart(DeletePartBindingModel bind)
        {
            Part part = this.Context.Parts.Find(bind.PartId);
            this.Context.Parts.Remove(part);
            this.Context.SaveChanges();
        }
    }
}