using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;

namespace FlooringMastery.Workflows
{
    class DisplayOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Order Information");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("============================================\n");

            var orderNumber = UserPrompts.PromptUserForNumber();
            var orderDate = UserPrompts.PromptUserForDate();

            var ops = OperatorFactory.CreateOrderOperations();

            var response = ops.GetOrder(orderNumber,orderDate);

            Console.ForegroundColor = ConsoleColor.White;
            if (response.Data != null)
            {
                Console.WriteLine(OrderConversion.OrderConvert(response.Data));
            }
            else
            {
                Console.WriteLine("Order not found.");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            UserPrompts.KeyToContinue();
        }        
    }
}
