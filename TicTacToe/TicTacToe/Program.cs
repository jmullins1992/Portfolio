using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.BLL;

namespace TicTacToe
{
    class Program
    {

        static void Main(string[] args)
        {
            
            Game myGame = new Game();

            Console.ForegroundColor = ConsoleColor.Yellow;
            myGame.ShowWelcome();
            myGame.ShowBoard();
            
            do
            {
                int gameState = 0;
                myGame.GetInput();
                if (myGame.userChoice.ToUpper() == "Q")
                    break;

                myGame.ShowBoard();

                gameState = myGame.CheckGameOver();
                if (gameState > 0)
                    myGame.ShowResults(gameState);
            } while (!myGame.gameOver);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\t\t\tPress any key to exit the program.");
            Console.ReadKey();

        }
    }
}
