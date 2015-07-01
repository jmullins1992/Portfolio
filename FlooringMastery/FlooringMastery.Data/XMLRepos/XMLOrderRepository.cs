using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Models;
using Models.Interfaces;

namespace FlooringMastery.Data.XMLRepos
{
    public class XMLOrderRepository : IOrderRepository
    {
        private const string FilePath = @"Orders\orders_";

        public Order GetOrder(int orderNumber, DateTime orderDate)
        {
             List<Order> orders = GetAllOrders(orderDate);


            var order = orders.FirstOrDefault(o => o.OrderNumber == orderNumber);

            return order;
        }

        public void AddOrder(Order orderToAdd)
        {
            List<Order> orders = GetAllOrders(DateTime.Today);

            if (orders.LongCount() > 0)
                orderToAdd.OrderNumber = orders.Max(o => o.OrderNumber) + 1;
            else
                orderToAdd.OrderNumber = 1;

            orders.Add(orderToAdd);
            OverWriteFile(DateTime.Today, orders);
        }

        public void EditOrder(Order orderToEdit, DateTime orderDate)
        {
            List<Order> orders = GetAllOrders(orderDate);

            var existingOrder = orders.First(o => o.OrderNumber == orderToEdit.OrderNumber);
            orders.Remove(existingOrder);
            OverWriteFile(orderDate, orders);

            orders = GetAllOrders(DateTime.Today);
            AddOrder(orderToEdit);
        }

        public void DeleteOrder(int orderNumber, DateTime orderDate)
        {
            var orders = GetAllOrders(orderDate);

            var existingOrder = orders.First(o => o.OrderNumber == orderNumber);
            orders.Remove(existingOrder);

            OverWriteFile(orderDate, orders);
        }

        private void OverWriteFile(DateTime orderDate, List<Order> orders )
        {
            
            Directory.CreateDirectory(@"Orders");

            File.Delete(FilePath + orderDate.ToString("MMddyyyy") + ".xml");

            using (TextWriter writer = new StreamWriter(FilePath + orderDate.ToString("MMddyyyy") + ".xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof (List<Order>));
                serializer.Serialize(writer, orders);
            }
        }

        public List<Order> GetAllOrders(DateTime orderDate)
        {
            List<Order> orders = new List<Order>();

            Directory.CreateDirectory(@"Orders");

            if ((File.Exists(FilePath + orderDate.ToString("MMddyyyy") + ".xml")))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<Order>));

                using (var reader = new StreamReader(FilePath + orderDate.ToString("MMddyyyy") + ".xml"))
                {
                    orders = (List<Order>) deserializer.Deserialize(reader); 
                }
            }

            return orders;
        }
    }
}
