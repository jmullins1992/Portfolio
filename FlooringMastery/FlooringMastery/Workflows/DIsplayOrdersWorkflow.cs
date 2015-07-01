using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;

namespace FlooringMastery.Workflows
{
    class DisplayOrdersWorkflow
    {
        public void Execute()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Orders Information");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("============================================\n");

            var orderDate = UserPrompts.PromptUserForDate();

            var ops = OperatorFactory.CreateOrderOperations();

            var response = ops.GetAllOrders(orderDate);

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(response.Message);

            foreach (var order in response.Data)
            {
                Console.WriteLine(OrderConversion.OrderConvert(order));
            }            
            Console.ForegroundColor = ConsoleColor.Yellow;
            UserPrompts.KeyToContinue();
        }
    }
}
