using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Models;
using FlooringMastery.BLL;
using FlooringMastery.Data;
using Models.Interfaces;


namespace FlooringMastery.Tests
{
    [TestFixture]
    public class OrderOperationsTests
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
        }

        [Test]
        public void TestANotFoundOrderReturnsFail()
        {
            var ops = OperatorFactory.CreateOrderOperations();
            var response = ops.GetOrder(500, DateTime.Parse("2013-06-01"));

            Assert.IsFalse(response.Success);
        }

        [Test]
        public void TestBFoundOrderReturnsSuccess()
        {
            var ops = OperatorFactory.CreateOrderOperations();
            var response = ops.GetOrder(1, DateTime.Parse("2013-06-01"));

            Assert.AreEqual(1, response.Data.OrderNumber);
            Assert.AreEqual("Wise", response.Data.CustomerName);
            Assert.AreEqual("OH", response.Data.State);
            Assert.AreEqual(6.25M, response.Data.TaxRate);
            Assert.AreEqual("Wood", response.Data.ProductType);
            Assert.AreEqual(100.00M, response.Data.Area);
            Assert.AreEqual(5.15M, response.Data.CostPerSquareFoot);
            Assert.AreEqual(4.75M, response.Data.LaborCostPerSquareFoot);
            Assert.AreEqual(515.00M, response.Data.MaterialCost);
            Assert.AreEqual(475.00M, response.Data.LaborCost);
            Assert.AreEqual(61.88M, response.Data.Tax);
            Assert.AreEqual(1051.88M, response.Data.Total);
        }

        [Test]
        public void TestCCanAddOrder()
        {
            var order = new Order()
            {
                CustomerName = "Jimmy",
                Area = 100M,
                State = "OH",
                ProductType = "Wood"
            };

            var ops = OperatorFactory.CreateOrderOperations();

            var response = ops.NewOrder(order);
            
            Assert.IsTrue(response.Success);

            Assert.AreEqual("Jimmy", response.Data.CustomerName);
            Assert.AreEqual("OH", response.Data.State);
            Assert.AreEqual(6.25M, response.Data.TaxRate);
            Assert.AreEqual("Wood", response.Data.ProductType);
            Assert.AreEqual(100.00M, response.Data.Area);
            Assert.AreEqual(5.15M, response.Data.CostPerSquareFoot);
            Assert.AreEqual(4.75M, response.Data.LaborCostPerSquareFoot);
            Assert.AreEqual(515.00M, response.Data.MaterialCost);
            Assert.AreEqual(475.00M, response.Data.LaborCost);
            Assert.AreEqual(61.88M, response.Data.Tax);
            Assert.AreEqual(1051.88M, response.Data.Total);
        }

        [Test]
        public void TestDCanEditOrder()
        {
            var order = new Order()
            {
                OrderNumber = 1,
                CustomerName = "Jimmy",
                Area = 100M,
                State = "OH",
                ProductType = "Wood"
            };

            var ops = OperatorFactory.CreateOrderOperations();

            var response = ops.EditOrder(order, DateTime.Parse("2013-06-01"));

            Assert.IsTrue(response.Success);
            
            Assert.AreEqual("Jimmy", response.Data.CustomerName);
            Assert.AreEqual("OH", response.Data.State);
            Assert.AreEqual(6.25M, response.Data.TaxRate);
            Assert.AreEqual("Wood", response.Data.ProductType);
            Assert.AreEqual(100.00M, response.Data.Area);
            Assert.AreEqual(5.15M, response.Data.CostPerSquareFoot);
            Assert.AreEqual(4.75M, response.Data.LaborCostPerSquareFoot);
            Assert.AreEqual(515.00M, response.Data.MaterialCost);
            Assert.AreEqual(475.00M, response.Data.LaborCost);
            Assert.AreEqual(61.88M, response.Data.Tax);
            Assert.AreEqual(1051.88M, response.Data.Total);
        }

        [Test]
        public void TestECanDeleteOrder()
        {
            var ops = OperatorFactory.CreateOrderOperations();

            int orderNum = 2;

            var response = ops.DeleteOrder(orderNum, DateTime.Parse("2013-06-01"));

            Assert.IsTrue(response.Success);
        }

        
    }
}
