using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    class RomanNumeralConverter
    {
        public static string[] Roman1000S = {"MMM", "MM", "M"};
        public static string[] Roman100S =  {"CM", "DCCC", "DCC", "DC", "D", "CD", "CCC", "CC", "C"};
        public static string[] Roman10S =   {"XC", "LXXX", "LXX", "LX", "L", "XL", "XXX", "XX", "X"};
        public static string[] Roman1S =    {"IX", "VIII", "VII", "VI", "V", "IV", "III", "II", "I"};

        public static string IntToRoman(int intToConvert)
        {
            var result = "";

            result += (intToConvert/1000 == 0) ? "" : Roman1000S[3 - intToConvert/1000];
            intToConvert %= 1000;

            result += (intToConvert/100 == 0) ? "" : Roman100S[9 - intToConvert/100];
            intToConvert %= 100;

            result += (intToConvert/10 == 0) ? "" : Roman10S[9 - intToConvert/10];
            intToConvert %= 10;

            result += (intToConvert == 0) ? "" : Roman1S[9 - intToConvert];

            return result;
        }
    }
}
