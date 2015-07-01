using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Workflows;

namespace FlooringMastery
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new MainMenu();
            menu.Execute();
        }
    }
}
