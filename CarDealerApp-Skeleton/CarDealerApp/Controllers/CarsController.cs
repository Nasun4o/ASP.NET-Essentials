using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealerApp.Service;
namespace CarDealerApp.Controllers
{
    using CarDealerApp.ViewModels;
    using CarDealerApp.Service;

    [RoutePrefix("Cars")]
    public class CarsController : Controller
    {
        private CarsService carsService;

        public CarsController()
        {
            this.carsService = new CarsService();
        }
        // GET: Cars
        public ActionResult Index()
        {
            return View();
        }
        [Route("All/{model}")]
        public ActionResult All(string model)
        {
            CarsAllViewModel cavm = this.carsService.GetAllCarsByModel(model);
            return this.View(cavm);
        }
    }
}