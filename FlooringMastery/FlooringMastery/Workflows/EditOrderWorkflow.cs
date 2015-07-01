using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using Models;

namespace FlooringMastery.Workflows
{
    class EditOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Edit an Order");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("============================================\n");

            var orderNumber = UserPrompts.PromptUserForNumber();
            var orderDate = UserPrompts.PromptUserForDate();

            Order order;

            var ops = OperatorFactory.CreateOrderOperations();

            var response = ops.GetOrder(orderNumber, orderDate);

            if (response.Success)
            {
                order = response.Data;
            }
            else
            {
                Console.WriteLine(response.Message);
                Console.ReadKey();
                return;
            }

            var name = UserPrompts.PromptForCustomerName(order);
            var area = UserPrompts.PromptForArea(order);
            var state = UserPrompts.PromptForState(order);
            var product = UserPrompts.PromptForProductType(order);

            var newOrder = new Order { CustomerName = name, Area = area, State = state, ProductType = product };            

            if (Confirm(newOrder))
            {
                newOrder.OrderNumber = order.OrderNumber;
                response = ops.EditOrder(newOrder,orderDate);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(response.Message);
                Console.ForegroundColor = ConsoleColor.Yellow;

                UserPrompts.KeyToContinue();
            }  
        }

        public bool Confirm(Order order)
        {
            var ops = OperatorFactory.CreateOrderOperations();

            if (!ops.ValidTaxAndProduct(order))
            {
                return false;
            }

            order = ops.CompleteOrder(order);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(OrderConversion.OrderConvert(order));
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Confirm this order?");
            return UserPrompts.PromptForYesNo();

        }
    }
}
