using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealerApp.Controllers
{
    using System.Collections;
    using CarDealerApp.Service;
    using CarDealerApp.ViewModels;

    [RoutePrefix("Sales")]
    public class SalesController : Controller
    {
        // GET: Sales
        private SalesService salesService;

        public SalesController()
        {
            this.salesService = new SalesService();
        }
        public ActionResult All()
        {
            SaleViewModel svm = this.salesService.GetAllSales();
            return View(svm);
        }
    }
}