using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueenTakesKing.Models;

namespace QueenTakesKing
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                bool check = false;

                Console.Write("Enter a the king's postion (e.g. a1): ");
                var input = Console.ReadLine().ToLower();
                if (input == "quit")
                {
                    break;
                }
                var king = new Coordinate(input);

                Console.Write("Enter the queen's position: ");
                input = Console.ReadLine().ToLower();
                var queen = new Coordinate(input);

                if (queen.Abscissa == king.Abscissa || queen.Ordinate == king.Ordinate)
                {
                    check = true;
                }

                if ((Math.Abs(queen.Abscissa - king.Abscissa) == (Math.Abs(queen.Ordinate - king.Ordinate))))
                {
                    check = true;
                }


                Console.WriteLine(check ? "Y" : "N");

                Console.ReadKey();
            } while (true);
        }
    }
}
