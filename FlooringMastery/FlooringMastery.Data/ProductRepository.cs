using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Interfaces;
using System.Xml;
using System.Xml.Serialization;

namespace FlooringMastery.Data
{
    public class ProductRepository : IProductRepository
    {
        private const string FilePath = @"DataFiles\Products.txt";
        private List<Product> _products; 

        public List<Product> ListAll()
        {
            _products = new List<Product>();
            string[] reader = File.ReadAllLines(FilePath);                        

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var product = new Product
                {
                    ProductType = columns[0],
                    CostPerSquareFoot= decimal.Parse(columns[1]),
                    LaborCostPerSquareFoot = decimal.Parse(columns[2]),
                };

                _products.Add(product);
            }

            return _products;
        }
    }
}
