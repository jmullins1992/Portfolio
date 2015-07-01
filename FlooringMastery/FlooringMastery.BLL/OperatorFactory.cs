using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Data;
using FlooringMastery.Data.Test;
using Models.Interfaces;
using Ninject;

namespace FlooringMastery.BLL
{
    public class OperatorFactory
    {
        public static TaxOperations CreateTaxOperations()
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            IStateTaxInfoRepository stateRepository = kernel.Get<IStateTaxInfoRepository>();

            return new TaxOperations(stateRepository);
        }

        public static ProductOperations CreateProductOperations()
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            IProductRepository productRepository = kernel.Get<IProductRepository>();

            return new ProductOperations(productRepository);
        }

        public static OrderOperations CreateOrderOperations()
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            IOrderRepository orderRepository = kernel.Get<IOrderRepository>();

            return new OrderOperations(orderRepository);
        }
    }
}
