using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using Models;

namespace FlooringMastery.Workflows
{
    class AddOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Add an Order");
            Console.WriteLine("============================================\n");
            Console.ForegroundColor = ConsoleColor.Yellow;

            var ops = OperatorFactory.CreateOrderOperations();

            var name = UserPrompts.PromptForCustomerName();
            var area = UserPrompts.PromptForArea();
            var state = UserPrompts.PromptForState();
            var product = UserPrompts.PromptForProductType();

            var order = new Order {CustomerName = name, Area = area, State = state, ProductType = product};
            
            if (Confirm(order))
            {
                var response = ops.NewOrder(order);

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
