﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;

namespace CarDealerApp
{
    using BindingModels;
    using CarDealer.Models;
    using CarDealerApp.ViewModels;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.RegisterMaps();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterMaps()
        {
            Mapper.Initialize(
                expression =>
                {
                    expression.CreateMap<Customer, EditUserViewModel>();
                    expression.CreateMap<Part, AllPartsViewModel>();
                    expression.CreateMap<Part, DeletePartViewModel>();
                });
        }
    }
}

