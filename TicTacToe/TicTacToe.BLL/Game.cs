using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.BLL
{
    public class Game
    {
        #region Properties
        public char[] board = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        public bool turnX = true;
        public bool gameOver = false;
        public string userChoice = "";
        private int position = 0;
        private int count = 0;
        #endregion

        public void ShowWelcome()
        {
            Console.WriteLine("\t\t\t-----!Welcome to Tic Tac Toe!-----");
            Console.Write("\t\t\t      Press any key to start.");
            Console.ReadKey();
        }

        public void ShowBoard()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t\t\t\tEnter Q to quit");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n");
            Console.WriteLine("\t\t\t\t{0} \t {1} \t {2}\n\n\n", board[1], board[2], board[3]);
            Console.WriteLine("\t\t\t\t{0} \t {1} \t {2}\n\n\n", board[4], board[5], board[6]);
            Console.WriteLine("\t\t\t\t{0} \t {1} \t {2}\n\n\n",   board[7], board[8], board[9]);
            //Console.WriteLine("\n");
        }

        public void GetInput()
        {
            bool validInput = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (turnX)
                {
                    Console.Write("\t\tEnter the number of the position to fill with an X: ");
                }
                else
                {
                    Console.Write("\t\tEnter the number of the position to fill with an O: ");
                }
                Console.ForegroundColor = ConsoleColor.Cyan;

                userChoice = Console.ReadLine();
                if (userChoice.ToUpper() == "Q")
                {
                    gameOver = true;
                    return;
                }

                validInput = (int.TryParse(userChoice, out position) && (position < 10 && position > 0) && Char.IsDigit(board[position]));

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\tThat is not a valid option.");

            } while (!validInput);

            if (turnX)
                board[position] = 'X';
            else
            {
                board[position] = 'O';
            }

            count++;
        }

        public int CheckGameOver()
        {
            //Refactor into a for loop that checks board[i] with board[i+1] etc
            if ((board[1] == board[2] && board[1] == board[3])  ||
                (board[4] == board[5] && board[4] == board[6])  ||
                (board[7] == board[8] && board[7] == board[9])  ||
                (board[1] == board[4] && board[1] == board[7])  ||
                (board[2] == board[5] && board[2] == board[8])  ||
                (board[3] == board[6] && board[3] == board[9])  ||
                (board[1] == board[5] && board[1] == board[9])  ||
                (board[3] == board[5] && board[3] == board[7]))           
            {
                gameOver = true;
                return 1;
            }
            
            if (count == 9)
            {
                gameOver = true;
                return 2;
            }

            turnX = !turnX;
            return 0;
        }

        public void ShowResults(int gameState)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            if (gameState == 1)
            {
                if (turnX)
                    Console.WriteLine("\t\t\t\tPlayer X wins!");
                else
                {
                    Console.WriteLine("\t\t\t\tPlayer O wins!");
                }
                
                try
                {
                    WriteToFile();
                }
                catch
                {
                    Console.WriteLine("I tried to write to the file but failed :( :( :( :( :(\n:( :( :( :( :( :( :( :( :( :( :( :( :( :(");
                }
            }
            else
            {
                Console.WriteLine("\t\t\t\tIt is a tie.");
            }

        }

        public void WriteToFile()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\Results.txt";

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("TicTacToe Results:");
                }
            }


            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(turnX ? "X won." : "O won.");
            }
        }

        public static int CheckWinTester(char[] values, int counter)
        {
            //Refactor into a for loop that checks board[i] with board[i+1] etc
            if ((values[1] == values[2] && values[1] == values[3]) ||
                (values[4] == values[5] && values[4] == values[6]) ||
                (values[7] == values[8] && values[7] == values[9]) ||
                (values[1] == values[4] && values[1] == values[7]) ||
                (values[2] == values[5] && values[2] == values[8]) ||
                (values[3] == values[6] && values[3] == values[9]) ||
                (values[1] == values[5] && values[1] == values[9]) ||
                (values[3] == values[5] && values[3] == values[7]))
            {
                return 1;
            }
            
            if (counter == 9)
            {
                return 2;
            }

            return 0;
        }
    }
}
