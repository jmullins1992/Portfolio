using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Models;
using FlooringMastery.Data;
using Models.Interfaces;

namespace FlooringMastery.BLL
{
    public class OrderOperations
    {
        private readonly IOrderRepository _myOrderRepository;

        public OrderOperations(IOrderRepository aOrderRepository)
        {
            _myOrderRepository = aOrderRepository;
        }
        
        public Response<Order> GetOrder(int orderNum, DateTime orderDate)
        {            
            var response = new Response<Order>();

            try
            {
                var order = _myOrderRepository.GetOrder(orderNum, orderDate);

                if (order == null)
                {
                    response.Success = false;
                    response.Message = "Order not found.";
                }
                else
                {
                    response.Success = true;                    
                    response.Data = order;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

                try
                {
                    var repo = new LogRepository();
                    repo.WriteLog(ex.Message);
                }
                catch
                {
                    response.Message += "\nCould not write to log file.";
                }
            }

            return response;
        }

        public Response<Order> NewOrder(Order orderToAdd)
        {
            var response = new Response<Order>();

            orderToAdd = CompleteOrder(orderToAdd);

            try
            {
                var orders = _myOrderRepository.GetAllOrders(DateTime.Today);

                if (orders.LongCount() > 0)
                    orderToAdd.OrderNumber = orders.Max(o => o.OrderNumber) + 1;
                else
                    orderToAdd.OrderNumber = 1;

                _myOrderRepository.AddOrder(orderToAdd);

                response.Data = orderToAdd;
                response.Success = true;
                response.Message = "Order "+ orderToAdd.OrderNumber + " added.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

                try
                {
                    var repo = new LogRepository();
                    repo.WriteLog(ex.Message);
                }
                catch
                {
                    response.Message += "\nCould not write to log file.";
                }
            }

            return response;
        }

        public Response<Order> EditOrder(Order orderToEdit, DateTime orderDate)
        {
            var response = new Response<Order>();

            orderToEdit = CompleteOrder(orderToEdit);

            response.Data = orderToEdit;

            try
            {              
                _myOrderRepository.EditOrder(orderToEdit,orderDate);
                
                response.Success = true;
                response.Message = "Edit successful. Reference Order Number " + orderToEdit.OrderNumber + ".";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

                try
                {
                    var repo = new LogRepository();
                    repo.WriteLog(ex.Message);
                }
                catch
                {
                    response.Message += "\nCould not write to log file.";
                }
            }

            return response;
        }

        public Response<int> DeleteOrder(int orderNumber, DateTime orderDate)
        {
            var response = new Response<int>();
            try
            {
                _myOrderRepository.DeleteOrder(orderNumber, orderDate);

                response.Data = orderNumber;
                response.Success = true;
                response.Message = "Order " + orderNumber + " deleted.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

                try
                {
                    var repo = new LogRepository();
                    repo.WriteLog(ex.Message);
                }
                catch
                {
                    response.Message += "\nCould not write to log file.";
                }
            }

            return response;
        }

        public Response<List<Order>> GetAllOrders(DateTime orderDate)
        {
            var response = new Response<List<Order>>();
            
            try
            {
                var orders = _myOrderRepository.GetAllOrders(orderDate);

                response.Data = orders;

                if (orders.LongCount() == 0)
                {
                    response.Success = false;
                    response.Message = "File not found.";
                }
                else
                {
                    response.Success = true;                    
                    response.Data = orders;
                    response.Message = "";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

                try
                {
                    var repo = new LogRepository();
                    repo.WriteLog(ex.Message);
                }
                catch
                {
                    response.Message += "\nCould not write to log file.";
                }
            }

            return response;
        }

        public Order CompleteOrder(Order order)
        {
            var taxOps = OperatorFactory.CreateTaxOperations();
            var prodOps = OperatorFactory.CreateProductOperations();

            order.CostPerSquareFoot = prodOps.GetMaterialPerSquareFoot(order.ProductType).Data;
            order.LaborCostPerSquareFoot = prodOps.GetLaborPerSquareFoot(order.ProductType).Data;

            order.MaterialCost = order.CostPerSquareFoot * order.Area;
            order.LaborCost = order.LaborCostPerSquareFoot * order.Area;

            order.TaxRate = taxOps.GetRate(order.State).Data;
            order.Tax = Math.Round((order.MaterialCost + order.LaborCost) * order.TaxRate / 100M, 2);
            order.Total = (order.MaterialCost + order.LaborCost) + order.Tax;

            return order;
        }

        public bool ValidTaxAndProduct(Order order)
        {
            var taxOps = OperatorFactory.CreateTaxOperations();
            var prodOps = OperatorFactory.CreateProductOperations();

            if (!prodOps.IsValidProduct(order.ProductType).Data)
            {
                Console.WriteLine("We do not carry that product type.");
                return false;
            }

            if (!taxOps.IsValidState(order.State).Data)
            {
                Console.WriteLine("We do not operate within that state.");
                return false;
            }

            return true;
        }               
    }
}
