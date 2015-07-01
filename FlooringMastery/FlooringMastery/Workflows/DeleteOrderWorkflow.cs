using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using Models;

namespace FlooringMastery.Workflows
{
    class DeleteOrderWorkflow
    {
        public void Execute()
        {            
            Console.Clear();
            Console.WriteLine("Remove an Order");
            Console.WriteLine("============================================\n");

            var orderNumber = UserPrompts.PromptUserForNumber();
            var orderDate = UserPrompts.PromptUserForDate();

            var ops = OperatorFactory.CreateOrderOperations();

            if (!Confirm(orderNumber, orderDate))
            {
                UserPrompts.KeyToContinue(); 
                return;
            }
                                         
            var response = ops.DeleteOrder(orderNumber, orderDate);
            
            Console.WriteLine(response.Message);
            Console.Write("Press any key to return to the Main Menu.");
            Console.ReadKey();            
        }

        private bool Confirm(int orderNum, DateTime orderDate)
        {
            var ops = OperatorFactory.CreateOrderOperations();

            var order = ops.GetOrder(orderNum, orderDate).Data;

            if (ops.GetOrder(orderNum, orderDate).Success == false)
            {
                Console.WriteLine("Order not found.");
                return false;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(OrderConversion.OrderConvert(order));
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Are you sure you want to delete this order?");

            return UserPrompts.PromptForYesNo();
        }
    }
}
