using System;
using System.Collections.Generic;
using Models;
using Models.Interfaces;

namespace FlooringMastery.Data.Test
{
    public class TestOrderRepository : IOrderRepository
    {
        public Order GetOrder(int orderNumber, DateTime orderDate)
        {
            var myOrder = new Order
            {
                Area = 100.00M,
                CostPerSquareFoot = 5.15M,
                CustomerName = "Wise",
                LaborCost = 475.00M,
                LaborCostPerSquareFoot = 4.75M,
                MaterialCost = 515M,
                OrderNumber = 1,
                ProductType = "Wood",
                State = "OH",
                Tax = 61.88M,
                Total = 1051.88M
            };

            return myOrder;
        }

        public void AddOrder(Order orderToAdd)
        {
            return;
        }

        public void DeleteOrder(int orderNumber, DateTime orderDate)
        {
            return;
        }

        public void WriteLog(string message)
        {
            return;
        }

        public List<Order> GetAllOrders(DateTime date)
        {
            List<Order> list = new List<Order> {this.GetOrder(1, DateTime.Today)};
            return list;
        }

        public void EditOrder(Order orderToEdit, DateTime orderDate)
        {
            return;
        }
       
    }
}
