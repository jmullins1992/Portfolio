using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator
{
    class Program
    {
        private static string input;
        private static string company;
        private static string number;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to credit card validator!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

            do
            {
                Console.Write(
                    "Please enter the company that issued the credit card (Visa, MasterCard, American Express, Discover): ");
                input = Console.ReadLine();
            } while (!IsValidName(input));
            company = input;

            do
            {
                Console.Write("Please enter the card number: ");
                input = Console.ReadLine();
            } while (!IsValidNumber(input));
            number = input;

            if (IsValidCard(company, number))
            {
                Console.WriteLine("The card is valid.");
            }
            else
            {
                Console.WriteLine("The card is invalid.");
            }

            Console.ReadKey();
        }

        private static bool IsValidName(string s)
        {
            switch (s.ToUpper())
            {
                case "VISA":
                case "MASTERCARD":
                case "AMERICAN EXPRESS":
                case "DISCOVER":
                    return true;
            }

            return false;
        }

        private static bool IsValidNumber(string s)
        {
            switch (company.ToUpper())
            {
                case "VISA":
                    if (s[0] != '4' || s.Length < 13 || s.Length > 16)
                        return false;
                    break;
                case "MASTERCARD":
                    if (Int32.Parse(s.Substring(0, 2)) < 51 || Int32.Parse(s.Substring(0, 2)) > 55 || s.Length != 16)
                        return false;
                    break;
                case "AMERICAN EXPRESS":
                    if (!(s.Substring(0, 2) == "34" || s.Substring(0, 2) == "37") || s.Length != 15)
                        return false;
                    break;
                case "DISCOVER":
                    if (!(s.Substring(0, 4) == "6011"
                            || (Int32.Parse(s.Substring(0, 6)) > 622126 && Int32.Parse(s.Substring(0, 6)) < 622925)
                            || (Int32.Parse(s.Substring(0, 3)) > 644 && Int32.Parse(s.Substring(0, 3)) < 649)
                            ||  s.Substring(0, 2) == "65" 
                            || s.Length == 16))
                        return false;
                    break;
            }

            return true;
        }

        public static bool IsValidCard(string c, string n)
        {
            int checksum = 0;

            for (int i = 2; i <= n.Length; i++)
            {
                if (i%2 == 0)
                {
                    if (Int32.Parse("" + n[n.Length - i])*2 < 9)
                    {
                        checksum += Int32.Parse("" + n[n.Length - i])*2;
                    }
                    else
                    {
                        checksum += (Int32.Parse("" + n[n.Length - i]) * 2) % 10 + 1;
                    }
                }
                else
                {
                    checksum += Int32.Parse("" + n[n.Length-i]); 
                }
            }

            return 10 - checksum%10 == Int32.Parse("" +n[n.Length - 1]);
        }
    }
}
