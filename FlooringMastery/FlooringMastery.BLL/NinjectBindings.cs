using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Data;
using FlooringMastery.Data.Test;
using FlooringMastery.Data.XMLRepos;
using Models.Interfaces;
using Ninject.Modules;

namespace FlooringMastery.BLL
{
    public class NinjectBindings : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
             string mode = ConfigurationManager.AppSettings["Mode"];

            if (mode == "Test")
            {
                Bind<IProductRepository>().To<TestProductRepository>();
                Bind<IOrderRepository>().To<TestOrderRepository>();
                Bind<IStateTaxInfoRepository>().To<TestStateTaxInfoRepository>();
            }
            else if (mode == "XML")
            {
                Bind<IProductRepository>().To<XMLProductRepository>();
                Bind<IOrderRepository>().To<XMLOrderRepository>();
                Bind<IStateTaxInfoRepository>().To<XMLStateTaxInfoRepository>();
            }
            else
            {
                Bind<IProductRepository>().To<ProductRepository>();
                Bind<IOrderRepository>().To<OrderRepository>();
                Bind<IStateTaxInfoRepository>().To<StateTaxInfoRepository>();
            }
        }
    }
}
