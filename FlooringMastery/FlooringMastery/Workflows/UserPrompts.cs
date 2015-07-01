using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using Models;

namespace FlooringMastery.Workflows
{
    internal class UserPrompts
    {
        public static DateTime PromptUserForDate()
        {
            do
            {
                DateTime orderDate;

                Console.Write("Enter order date (YYYY-MM-DD): ");

                Console.ForegroundColor = ConsoleColor.Green;
                if (DateTime.TryParse(Console.ReadLine(), out orderDate))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    return orderDate;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
            } while (true);
        }

        public static int PromptUserForNumber()
        {
            do
            {
                var orderNumber = 0;

                Console.Write("Enter order number: ");

                Console.ForegroundColor = ConsoleColor.Green;
                if (Int32.TryParse(Console.ReadLine(), out orderNumber))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    return orderNumber;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
            } while (true);
        }

        public static void KeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static bool PromptForYesNo()
        {
            while (true)
            {
                Console.Write("Enter Y or N: ");

                Console.ForegroundColor = ConsoleColor.Green;
                var userInput = Console.ReadLine().ToUpper();
                Console.ForegroundColor = ConsoleColor.Yellow;

                if (userInput == "Y")
                {
                    return true;
                }

                if (userInput == "N")
                {
                    return false;
                }
            }
        }

        public static string PromptForCustomerName()
        {
            do
            {
                Console.Write("Enter Customer Name: ");

                Console.ForegroundColor = ConsoleColor.Green;
                string userInput = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Yellow;

                if (userInput.Contains('|') || userInput.Length == 0)
                {
                    continue;
                }
                else
                {
                    return userInput;
                }
            } while (true);

        }

        public static decimal PromptForArea()
        {
            do
            {
                Console.Write("Enter Area in Square Feet: ");

                Console.ForegroundColor = ConsoleColor.Green;
                string userInput = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Yellow;

                decimal newArea;

                var validArea = decimal.TryParse(userInput, out newArea);

                if (validArea && newArea > 0)
                {
                    return newArea;
                }
            } while (true);
        }

        public static string PromptForState()
        {
            var stateOps = OperatorFactory.CreateTaxOperations();

            do
            {
                Console.Write("Enter State Abbreviation (e.g. OH): ");

                Console.ForegroundColor = ConsoleColor.Green;
                string userInput = Console.ReadLine().ToUpper();
                Console.ForegroundColor = ConsoleColor.Yellow;

                if (userInput.Contains(','))
                {
                    Console.WriteLine("No commas");
                    continue;
                }

                if (stateOps.IsValidState(userInput).Data)
                {
                    return userInput;
                }

                Console.WriteLine("We do not operate in that state.");
            } while (true);
        }

        public static string PromptForProductType()
        {
            var prodOps = OperatorFactory.CreateProductOperations();

            do
            {
                Console.Write("Enter Product Type: ");

                Console.ForegroundColor = ConsoleColor.Green;
                string userInput = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.Yellow;

                if (userInput.Contains(','))
                {
                    Console.WriteLine("No commas");
                    continue;
                }
                if (userInput.Length < 2)
                {
                    continue;
                }
  
                userInput = userInput[0].ToString().ToUpper() + userInput.Substring(1);

                if (prodOps.IsValidProduct(userInput).Data)
                {
                    return userInput;
                }

                Console.WriteLine("We don't carry that product.");
            } while (true);
        }

        public static string PromptForCustomerName(Order order)
        {
            do
            {
                Console.Write("Enter customer name ({0}): ", order.CustomerName);

                Console.ForegroundColor = ConsoleColor.Green;
                string userInput = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Yellow;

                if (userInput == "")
                {
                    return order.CustomerName;
                }

                if (!(userInput.Contains('|') || userInput.Length == 0))
                {
                    return userInput;
                }               
            } while (true);

        }

        public static decimal PromptForArea(Order order)
        {
            do
            {
                Console.Write("Enter Area in Square Feet ({0}): ", order.Area);

                Console.ForegroundColor = ConsoleColor.Green;
                string userInput = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Yellow;

                decimal newArea;

                var validArea = decimal.TryParse(userInput, out newArea);

                if (userInput == "")
                {
                    return order.Area;
                }

                if (validArea && newArea > 0)
                {
                    return newArea;
                }
            } while (true);
        }
        
        public static string PromptForState(Order order)
        {
            var stateOps = OperatorFactory.CreateTaxOperations();

            do
            {
                Console.Write("Enter State Abbreviation ({0}): ", order.State);

                Console.ForegroundColor = ConsoleColor.Green;
                string userInput = Console.ReadLine().ToUpper();
                Console.ForegroundColor = ConsoleColor.Yellow;

                if (userInput == "")
                {
                    return order.State;
                }

                if (stateOps.IsValidState(userInput).Data)
                {
                    return userInput;
                }

                Console.WriteLine("We do not operate in that state.");
            } while (true);
        }

        public static string PromptForProductType(Order order)
        {
            var prodOps = OperatorFactory.CreateProductOperations();

            do
            {
                Console.Write("Enter product type ({0}): ", order.ProductType);

                Console.ForegroundColor = ConsoleColor.Green;
                string userInput = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.Yellow;

                if (userInput == "")
                {
                    return order.ProductType;
                }

                userInput = userInput[0].ToString().ToUpper() + userInput.Substring(1);

                if (prodOps.IsValidProduct(userInput).Data)
                {
                    return userInput;
                }

                Console.WriteLine("We don't carry that product.");
            } while (true);
        }
    }
}
