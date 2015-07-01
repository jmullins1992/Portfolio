using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.IO;
using Models.Interfaces;


namespace FlooringMastery.Data
{
    public class OrderRepository : IOrderRepository
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
            OverWriteFile(DateTime.Today,orders);
        }

        public void EditOrder(Order orderToEdit,DateTime orderDate)
        {
            List<Order> orders = GetAllOrders(orderDate);

            var existingOrder = orders.First(o => o.OrderNumber == orderToEdit.OrderNumber);
            orders.Remove(existingOrder);
            OverWriteFile(orderDate, orders);

            orders = GetAllOrders(DateTime.Today);
            AddOrder(orderToEdit);
            
            //OverWriteFile(DateTime.Today, orders);
        }

        public void DeleteOrder(int orderNumber, DateTime orderDate)
        {
            List<Order> orders = GetAllOrders(orderDate);

            var existingOrder = orders.First(o => o.OrderNumber == orderNumber);
            orders.Remove(existingOrder);            

            OverWriteFile(orderDate, orders);
        }

        public void OverWriteFile(DateTime orderDate,List<Order> orders)
        {
            Directory.CreateDirectory(@"Orders");
            
            File.Delete(FilePath + orderDate.ToString("MMddyyyy") + ".txt");
            using (var writer = File.CreateText(FilePath + orderDate.ToString("MMddyyyy") + ".txt"))
            {
                writer.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot," +
                                 "LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");

                foreach (var order in orders)
                {
                    writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", 
                        order.OrderNumber, order.CustomerName.Replace(',','|'), order.State, order.TaxRate, order.ProductType, order.Area, 
                        order.CostPerSquareFoot, order.LaborCostPerSquareFoot, order.MaterialCost, order.LaborCost, order.Tax, 
                        order.Total);
                }
            }
        }

        public List<Order> GetAllOrders(DateTime orderDate)
        {
            List<Order> orders =  new List<Order>();
            string[] reader;

            Directory.CreateDirectory(@"Orders");

            if (File.Exists(FilePath + orderDate.ToString("MMddyyyy") + ".txt"))
            {
                reader = File.ReadAllLines(FilePath + orderDate.ToString("MMddyyyy") + ".txt");
            }
            else
            {
                return orders;
            }

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var order = new Order
                {
                    OrderNumber = int.Parse(columns[0]),
                    CustomerName = columns[1].Replace('|',','),
                    State = columns[2],
                    TaxRate = decimal.Parse(columns[3]),
                    ProductType = columns[4],
                    Area = decimal.Parse(columns[5]),
                    CostPerSquareFoot = decimal.Parse(columns[6]),
                    LaborCostPerSquareFoot = decimal.Parse(columns[7]),
                    MaterialCost = decimal.Parse(columns[8]),
                    LaborCost = decimal.Parse(columns[9]),
                    Tax = decimal.Parse(columns[10]),
                    Total = decimal.Parse(columns[11])
                };


                orders.Add(order);
            }

            return orders;
        }        
    }
}
