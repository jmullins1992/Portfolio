using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    class Program
    {
        private static string input;
        private static int userInput;

        static void Main(string[] args)
        {
            Console.WriteLine("Int to Roman Numeral Converter");
            Console.WriteLine("==================================");

            do
            {
                Console.Write("Enter the number you wish to convert: ");
                input = Console.ReadLine();


            } while (!Int32.TryParse(input, out userInput));

            Console.WriteLine("{0} converted to Roman Numerals is {1}", userInput,
                RomanNumeralConverter.IntToRoman(userInput));

            Console.ReadKey();
        }
    }
}
