using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Workflows
{
    class MainMenu
    {
        public void Execute()
        {
            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("*****************************************");
                
                Console.Write("*            ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("SCG Flooring POS");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("           *");
                
                Console.WriteLine("*_______________________________________*");
                Console.WriteLine("*                                       *");
                Console.WriteLine("* 1. Display Orders                     *");
                Console.WriteLine("* 2. Display an Order                   *");
                Console.WriteLine("* 3. Add an Order                       *");
                Console.WriteLine("* 4. Edit an Order                      *");
                Console.WriteLine("* 5. Remove an Order                    *");
                
                Console.Write("* 6. ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Quit");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("                               *");

                Console.WriteLine("*                                       *");
                Console.WriteLine("*****************************************");

                Console.Write("\nEnter choice: ");

                Console.ForegroundColor = ConsoleColor.Green;
                string input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Yellow;

                if (input == "6" || input.ToUpper() == "Q")
                {
                    break;
                }

                ProcessChoice(input);
            } while (true);
        }

        private void ProcessChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    var displayOrders = new DisplayOrdersWorkflow();
                    displayOrders.Execute();
                    break;
                case "2":
                    var displayOrder = new DisplayOrderWorkflow();
                    displayOrder.Execute();
                    break;
                case "3":
                    var addOrder = new AddOrderWorkflow();
                    addOrder.Execute();
                    break;
                case "4":
                    var editOrder = new EditOrderWorkflow();
                    editOrder.Execute();
                    break;
                case "5":
                    var deleteOrder = new DeleteOrderWorkflow();
                    deleteOrder.Execute();
                    break;
            }
        }
    }
}
