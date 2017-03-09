using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerApp.Service
{
    using CarDealer.Data;

    public abstract class Service
    {
        public Service()
        {
            Context = Data.Context;
        }

        public CarDealerContext Context { get; }
    }
}