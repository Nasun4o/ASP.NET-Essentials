using CarDealerApp.Service;
using CarDealerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealerApp.Controllers
{
    [RoutePrefix("Suppliers")]
    public class SuppliersController : Controller
    {
        private SuppliersService service;
        public SuppliersController()
        {
            this.service = new SuppliersService();
        }
        // GET: Suppliers
        public ActionResult Index()
        {
            return View();
        }
        [Route("{supplier}")]
        public ActionResult Suppliers (string supplier)
        {
            SuppliersAllViewModel savm = this.service.GetSuppliers(supplier);
            return this.View(savm);
        }
    }
}