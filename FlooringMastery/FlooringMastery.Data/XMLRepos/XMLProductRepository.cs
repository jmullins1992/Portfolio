using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Interfaces;
using System.IO;
using System.Xml.Serialization;

namespace FlooringMastery.Data.XMLRepos
{
    public class XMLProductRepository : IProductRepository
    {
        private const string FilePath = @"DataFiles\Products.xml";
        private List<Product> _products; 

        public List<Product> ListAll()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof (List<Product>));
            using (var textReader = new StreamReader(FilePath))
            {
                _products = (List<Product>) deserializer.Deserialize(textReader);
            }

            return _products;
        }
    }
}
