using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealerApp.Controllers
{
    using CarDealerApp.Service;
    using CarDealerApp.ViewModels;

    [RoutePrefix("Customers")]
    public class CustomersController : Controller
    {
        private CustomerService customerService;

        public CustomersController()
        {
            this.customerService = new CustomerService();
        }
        // GET: User
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("All")]
 
        public ActionResult All()
        {
            CustomersAllViewModel cavm = this.customerService.GeneretaCustomerViewModel();
           
            return this.View(cavm);
        }

        [Route("All/{Order?}")]
        public ActionResult OrderByBirthDate(string order)
        {
            CustomersAllViewModel cvm = this.customerService.OrderBy(order);
            return this.View(cvm);
         
        }
        //[Route("{id}")]
        //public ActionResult CustomerSales(int id)
        //{

        //}

    }
}