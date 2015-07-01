using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TicTacToe.BLL;

namespace TicTacToe.Tests
{
    public class TicTacTest
    {
        [TestCase(new Char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }, 0, 0)]
        [TestCase(new Char[] { '0', 'X', 'O', 'X', 'O', 'O', 'X', 'X', 'X', 'O' }, 9, 2)]
        [TestCase(new Char[] { '0', 'X', 'X', 'X', 'O', 'O', '6', '7', '8', '9' }, 5, 1)]

        public void WinTests(char[] arr, int counter, int expected)
        {
            Assert.AreEqual(expected, Game.CheckWinTester(arr, counter));
        }
    }
}
