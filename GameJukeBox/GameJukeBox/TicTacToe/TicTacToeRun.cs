using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJukeBox.TicTacToe.TicTacToe;
using GameJukeBox.TicTacToe.TicTacToe.BLL;
using GameJukeBox.TicTacToe.TicTacToe.BLL.Response;
using GameJukeBox.TicTacToe;


namespace GameJukeBox.TicTacToe
{
    public class TicTacToeRun
    {
        public void startGame()
        {
            Console.WriteLine("Player 1, enter your name: ");

            TicTacToeChecker GameChecker = new TicTacToeChecker();
            string name1 = Console.ReadLine();
            GameChecker.GetUser1Name(name1);
            Console.WriteLine("\nPlayer 2, enter your name: ");
            string name2 = Console.ReadLine();
            GameChecker.GetUser2Name(name2);
            string ToRestart;
            MarkResponse.MarkPlacement result;

            do
            {
                Console.Clear();
                GameChecker.initializeGame();
                GameChecker.displayBoard();

                do
                {
                    // Enter choice
                    Console.WriteLine("\n{0}, enter your choice (1 to 9):", GameChecker.getPlayer1Name());
                    int userInput = int.Parse(Console.ReadLine());

                    while (!checkInput(userInput))
                    {
                        Console.WriteLine("Your input is out of range.");
                        Console.WriteLine("\n{0}, enter your choice (1 to 9):", GameChecker.getPlayer1Name());
                        userInput = int.Parse(Console.ReadLine());
                    }


                    Console.Clear();

                    result = GameChecker.getResult(userInput);
                    if (result == MarkResponse.MarkPlacement.Overlap)
                    {
                        //Console.WriteLine("Your input is already marked. Enter another choice.");
                        Console.WriteLine("{0} is is already marked. Enter another choice.", userInput);
                    }
                    else if (result == MarkResponse.MarkPlacement.Ok)
                    {
                        GameChecker.nextPlayerTurn();
                    }

                } while (result != MarkResponse.MarkPlacement.Win && result != MarkResponse.MarkPlacement.Full);
                //(!GameChecker.gameResult() && !GameChecker.CountTo9());
                EndMessage(result);

                Console.WriteLine("\nDo you want to restart the game(Y/N)?");
                ToRestart = Console.ReadLine();

            } while (ChoiceToRepeat(ToRestart));

            Console.WriteLine("\nBye bye.");
            Console.ReadLine();
        }


        private static void EndMessage(MarkResponse.MarkPlacement input)
        {
            if (input == MarkResponse.MarkPlacement.Win)
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.WriteLine("Draw game.");
            }
        }

        private static bool ChoiceToRepeat(string restart)
        {
            return (restart == "Y" || restart == "y");
        }

        private static bool checkInput(int input)
        {
            return (input > 0 && input < 10);
        }

    }
}

