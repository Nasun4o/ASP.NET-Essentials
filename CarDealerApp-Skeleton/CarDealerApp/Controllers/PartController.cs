using CarDealerApp.BindingModels;
using CarDealerApp.Service;
using CarDealerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealerApp.Controllers
{
    [RoutePrefix("parts")]
    public class PartController : Controller
    {
        private PartsService service;

        public PartController()
        {
            this.service = new PartsService();
        }
        // GET: Part
        [Route("all")]
        public ActionResult All()
        {
            IEnumerable<AllPartsViewModel> vms = this.service.GetAllParts();
            //TODO: Implement
            return View(vms);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            DeletePartViewModel model = this.service.DeleteViewModel(id);
            return this.View(model);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public ActionResult Delete([Bind(Include = "PartId")] DeletePartBindingModel bind)
        {
            if (ModelState.IsValid)
            {
                this.service.DeletePart(bind);
                return RedirectToAction("All");
            }
            DeletePartViewModel model = this.service.DeleteViewModel(bind.PartId);
            return this.View(model);
        }
    }
}