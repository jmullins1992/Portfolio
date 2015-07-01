using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Interfaces;

namespace FlooringMastery.Data.Test
{
    public class TestProductRepository : IProductRepository
    {
        public List<Product> ListAll()
        {
            return new List<Product>
            {
                new Product() {ProductType = "Wood", CostPerSquareFoot = 5.15M, LaborCostPerSquareFoot = 4.75M},
                new Product() {ProductType = "Shag", CostPerSquareFoot = 4.10M, LaborCostPerSquareFoot = 4.00M},
                new Product() {ProductType = "Tile", CostPerSquareFoot = 4.20M, LaborCostPerSquareFoot = 4.50M}          
            };
        }
    }
}
