using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using NUnit.Framework;
using Models;
using FlooringMastery.Data;

namespace FlooringMastery.Tests
{
    [TestFixture]
    public class OrderRepositoryTests
    {
        [SetUp]
        public void Init()
        {
            var repo = new OrderRepository();
            var orders = new List<Order>();

            orders.Add(new Order
            {
                OrderNumber = 1,
                CustomerName = "Wise",
                State = "OH",
                TaxRate = 6.25M,
                ProductType = "Wood",
                Area = 100M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M,
                MaterialCost = 515.00M,
                LaborCost = 475M,
                Tax = 61.88M,
                Total = 1051.88M
            });

            orders.Add(new Order
            {
                OrderNumber = 2,
                CustomerName = "Ward",
                State = "OH",
                TaxRate = 6.25M,
                ProductType = "Wood",
                Area = 100M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M,
                MaterialCost = 515.00M,
                LaborCost = 475M,
                Tax = 61.88M,
                Total = 1051.88M
            });

            orders.Add(new Order
            {
                OrderNumber = 3,
                CustomerName = "Smith",
                State = "OH",
                TaxRate = 6.25M,
                ProductType = "Wood",
                Area = 100M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M,
                MaterialCost = 515.00M,
                LaborCost = 475M,
                Tax = 61.88M,
                Total = 1051.88M
            });

            orders.Add(new Order
            {
                OrderNumber = 4,
                CustomerName = "Jones",
                State = "OH",
                TaxRate = 6.25M,
                ProductType = "Wood",
                Area = 100M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M,
                MaterialCost = 515.00M,
                LaborCost = 475M,
                Tax = 61.88M,
                Total = 1051.88M
            });

            repo.OverWriteFile(DateTime.Parse("2013-06-01"), orders);
        }

        [TearDown]
        public void Dispose()
        {
            var repo = new OrderRepository();
            var orders = new List<Order>();

            orders.Add(new Order
            {
                OrderNumber = 1,
                CustomerName = "Wise",
                State = "OH",
                TaxRate = 6.25M,
                ProductType = "Wood",
                Area = 100M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M,
                MaterialCost = 515.00M,
                LaborCost = 475M,
                Tax = 61.88M,
                Total = 1051.88M
            });

            orders.Add(new Order
            {
                OrderNumber = 2,
                CustomerName = "Ward",
                State = "OH",
                TaxRate = 6.25M,
                ProductType = "Wood",
                Area = 100M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M,
                MaterialCost = 515.00M,
                LaborCost = 475M,
                Tax = 61.88M,
                Total = 1051.88M
            });

            orders.Add(new Order
            {
                OrderNumber = 3,
                CustomerName = "Smith",
                State = "OH",
                TaxRate = 6.25M,
                ProductType = "Wood",
                Area = 100M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M,
                MaterialCost = 515.00M,
                LaborCost = 475M,
                Tax = 61.88M,
                Total = 1051.88M
            });

            orders.Add(new Order
            {
                OrderNumber = 4,
                CustomerName = "Jones",
                State = "OH",
                TaxRate = 6.25M,
                ProductType = "Wood",
                Area = 100M,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M,
                MaterialCost = 515.00M,
                LaborCost = 475M,
                Tax = 61.88M,
                Total = 1051.88M
            });

            repo.OverWriteFile(DateTime.Parse("2013-06-01"), orders);
            repo.OverWriteFile((DateTime.Today), new List<Order>());
        }

        [Test]        
        public void TestACanLoadOrder()
        {
            var repo = new OrderRepository();
           
            var order = repo.GetOrder(1, DateTime.Parse("2013-06-01"));

            Assert.AreEqual(1, order.OrderNumber);
            Assert.AreEqual("Wise", order.CustomerName);
            Assert.AreEqual("OH", order.State);
            Assert.AreEqual(6.25, order.TaxRate);
            Assert.AreEqual("Wood", order.ProductType);
            Assert.AreEqual(100.00, order.Area);
            Assert.AreEqual(5.15, order.CostPerSquareFoot);
            Assert.AreEqual(4.75, order.LaborCostPerSquareFoot);
            Assert.AreEqual(515.00, order.MaterialCost);
            Assert.AreEqual(475.00, order.LaborCost);
            Assert.AreEqual(61.88, order.Tax);
            Assert.AreEqual(1051.88, order.Total);           
        }

        [Test]
        public void TestBCanAddOrder()
        {


            var repo = new OrderRepository();

            var order = new Order
            {
                OrderNumber = 1,
                CustomerName = "Jerry",
                State = "OH",
                TaxRate = 6.25M,
                ProductType = "Wood",
                Area = 100,
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M,
                MaterialCost = 515.00M,
                LaborCost = 475.00M,
                Tax = 61.88M,
                Total = 1051.88M

            };

            repo.AddOrder(order);

            var result = repo.GetOrder(1, DateTime.Today);

            Assert.AreEqual(1, result.OrderNumber);
            Assert.AreEqual("Jerry", result.CustomerName);
            Assert.AreEqual("OH", result.State);
            Assert.AreEqual(6.25, result.TaxRate);
            Assert.AreEqual("Wood", result.ProductType);
            Assert.AreEqual(100.00, result.Area);
            Assert.AreEqual(5.15, result.CostPerSquareFoot);
            Assert.AreEqual(4.75, result.LaborCostPerSquareFoot);
            Assert.AreEqual(515.00, result.MaterialCost);
            Assert.AreEqual(475.00, result.LaborCost);
            Assert.AreEqual(61.88, result.Tax);
            Assert.AreEqual(1051.88, result.Total);
        }

        [Test]
        public void TestCCanEditOrder()
        {
            var repo = new OrderRepository();
            
            var order = repo.GetOrder(1, DateTime.Parse("2013-06-01"));
            
            order.CustomerName = "Eric";

            repo.EditOrder(order, DateTime.Parse("2013-06-01")); 
            order = repo.GetOrder(1, DateTime.Today);

            Assert.AreEqual("Eric", order.CustomerName);
        }

        [Test]
        public void TestDCanDeleteOrder()
        {
            var repo = new OrderRepository();

            int orderNum = 2;

            repo.DeleteOrder(orderNum, DateTime.Parse("2013-06-01"));

            var order = repo.GetOrder(2, DateTime.Parse("2013-06-01"));

            Assert.IsNull(order);
            
        }

        [Test]
        public void TestECanLogErrors()
        {
            var repo = new LogRepository();

            repo.WriteLog("Test");

            Assert.IsTrue(true);
        }
    }
}
