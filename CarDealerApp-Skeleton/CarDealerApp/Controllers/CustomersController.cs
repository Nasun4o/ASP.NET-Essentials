using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealerApp.Controllers
{
    using CarDealerApp.BindingModels;
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
        [Route("{id}")]
        public ActionResult About(int id)
        {
            TotalSalesByCustomerViewModel tsbcvm = this.customerService.TotalSalesByCustomer(id);
            return this.View(tsbcvm);
        }

        [HttpGet]
        [Route("Add")]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add([Bind(Include = "Name, BirthDate")] AddUserBindingModel addUserBindingModel)
        {
            if (ModelState.IsValid)
            {
                this.customerService.AddUser(addUserBindingModel);
            }
            return this.Redirect("All");
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            EditUserViewModel model = this.customerService.EditUser(id);
            return this.View(model);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public ActionResult Edit([Bind(Include = "Id, Name, BirthDate")] AddUserBindingModel editUserBindingModel)
        {
            if (ModelState.IsValid)
            {
                this.customerService.Edit(editUserBindingModel);
            }
            return this.RedirectToAction("All");
        }

    }
}