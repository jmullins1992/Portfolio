using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QueenTakesKing.Models
{
    public class Coordinate
    {
        public int Abscissa;
        public int Ordinate;

        private static readonly Dictionary<char, int> AbscissaValues = new Dictionary<char, int>
        {
            {'a', 1},
            {'b', 2},
            {'c', 3},
            {'d', 4},
            {'e', 5},
            {'f', 6},
            {'g', 7},
            {'h', 8}
        };

        public Coordinate(string str)
        {
            Abscissa = AbscissaValues[str[0]];
            Ordinate = Int32.Parse(""+str[1]);
        }
    }
}
