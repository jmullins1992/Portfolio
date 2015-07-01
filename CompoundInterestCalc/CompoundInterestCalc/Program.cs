using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompoundInterestCalc
{
    class Program
    {
        private static double principal;
        private static double rate;
        private static double termLength;
        private static string input;

        static void Main(string[] args)
        {

            // monthly payment = (monthly_interest * principal) * ((1+monthly_interest)^term_in_months) / ((1+monthly_interest)^term_in_months - 1)

            Console.WriteLine("Welcome to the Compound Interest calculator!");
            do
            {
                Console.Write("Please enter the principal amount in dollars: ");
                input = Console.ReadLine();
            } while (!double.TryParse(input, out principal));

            do
            {
                Console.Write("Please enter the monthly interest rate as a decimal (ex 5% would be .05): ");
                input = Console.ReadLine();
            } while (!double.TryParse(input, out rate));

            do
            {
                Console.Write("Please enter the term length in months: ");
                input = Console.ReadLine();
            } while (!double.TryParse(input, out termLength));

            Console.WriteLine("your monthly payments should be: {0}", 
                (rate * principal) * Math.Pow((1+rate), termLength) / (Math.Pow((1+rate), termLength) - 1));

            Console.ReadLine();
        }
    }
}
