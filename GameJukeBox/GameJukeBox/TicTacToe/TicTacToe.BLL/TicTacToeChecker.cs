using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJukeBox.TicTacToe.TicTacToe.BLL.Response;

namespace GameJukeBox.TicTacToe.TicTacToe.BLL
{
    public class TicTacToeChecker
    {
        private string player1Name { get; set; }
        private string player2Name { get; set; }
        private string[] gameBoard = new string[9];
        private bool whosTurn { get; set; }    // true - player 1, false - player 2
        private string player1Mark = "X";
        private string player2Mark = "O";
        private string baseLine = new string('-', 19);
        private int count;

        public void GetUser1Name(string name)
        {
            this.player1Name = name;
        }

        public void GetUser2Name(string name)
        {
            this.player2Name = name;
        }

        public void initializeGame()
        {
            count = 0;

            for (int i = 0; i < 9; i++)
            {
                this.gameBoard[i] = (i + 1).ToString();
            }
            this.whosTurn = true;
        }

        public void displayBoard()
        {
            for (int i = 1; i <= 11; i++)
            {
                // shows only line
                if (i == 1 || i == 3 || i == 5 || i == 7 || i == 9 || i == 11)
                {
                    Console.WriteLine("{0,6}{0,6}", "|");
                }
                else if (i == 2)
                {
                    Console.WriteLine("{1,3}{0,3}{2,3}{0,3}{3,3}", "|", this.gameBoard[0], this.gameBoard[1], this.gameBoard[2]);
                }
                else if (i == 6)
                {
                    Console.WriteLine("{1,3}{0,3}{2,3}{0,3}{3,3}", "|", this.gameBoard[3], this.gameBoard[4], this.gameBoard[5]);
                }
                else if (i == 10)
                {
                    Console.WriteLine("{1,3}{0,3}{2,3}{0,3}{3,3}", "|", this.gameBoard[6], this.gameBoard[7], this.gameBoard[8]);
                }
                else //if ( i == 4 || i == 8)
                {
                    Console.WriteLine(this.baseLine);
                }

            }
        }

        public void nextPlayerTurn()
        {
            whosTurn = (!whosTurn);
        }

        public string getPlayer1Name()
        {
            return player1Name;
        }

        public string getPlayer2Name()
        {
            return player2Name;
        }

        public MarkResponse.MarkPlacement getResult(int choice)
        {
            // return overlap or ok
            string mark = sendMark(whosTurn);

            int dummy;
            bool test = int.TryParse(gameBoard[choice - 1], out dummy);
            if (test)
            {
                gameBoard[choice - 1] = mark;
                count++;
                displayBoard();

                if (checkForVictory())
                {
                    return MarkResponse.MarkPlacement.Win;
                }
                else
                {
                    if (count == 9)
                    {
                        return MarkResponse.MarkPlacement.Full;
                    }
                    else
                    {
                        return MarkResponse.MarkPlacement.Ok;
                    }
                }
            }
            else
            {
                displayBoard();
                return MarkResponse.MarkPlacement.Overlap;
            }

        }

        public string sendMark(bool playerTurn)
        {
            if (playerTurn)
            {
                return player1Mark;
            }

            return player2Mark;

        }

        public int getPlayerID()
        {
            if (whosTurn)
            {
                return 1;
            }
            return 2;
        }

        public bool CountTo9()
        {
            count++;
            if (count >= 9)
            {
                Console.WriteLine("Draw game.");
                return true;
            }
            return false;
        }

        public bool checkForVictory()
        {
            string mark = sendMark(whosTurn);

            if ((gameBoard[0] == gameBoard[1] && gameBoard[1] == gameBoard[2]) ||
                (gameBoard[0] == gameBoard[4] && gameBoard[4] == gameBoard[8]) ||
                (gameBoard[3] == gameBoard[4] && gameBoard[4] == gameBoard[5]) ||
                (gameBoard[6] == gameBoard[7] && gameBoard[7] == gameBoard[8]) ||
                (gameBoard[0] == gameBoard[3] && gameBoard[3] == gameBoard[6]) ||
                (gameBoard[1] == gameBoard[4] && gameBoard[4] == gameBoard[7]) ||
                (gameBoard[2] == gameBoard[5] && gameBoard[5] == gameBoard[8]) ||
                (gameBoard[2] == gameBoard[4] && gameBoard[4] == gameBoard[6]))
            {
                Console.WriteLine("Player {0} wins. Game over.", getPlayerID());
                return true;
            }
            //nextPlayerTurn();
            return false;
        }

        public bool gameResult()
        {
            string mark = sendMark(whosTurn);

            if ((gameBoard[0] == gameBoard[1] && gameBoard[1] == gameBoard[2]) ||
                (gameBoard[0] == gameBoard[4] && gameBoard[4] == gameBoard[8]) ||
                (gameBoard[3] == gameBoard[4] && gameBoard[4] == gameBoard[5]) ||
                (gameBoard[6] == gameBoard[7] && gameBoard[7] == gameBoard[8]) ||
                (gameBoard[0] == gameBoard[3] && gameBoard[3] == gameBoard[6]) ||
                (gameBoard[1] == gameBoard[4] && gameBoard[4] == gameBoard[7]) ||
                (gameBoard[2] == gameBoard[5] && gameBoard[5] == gameBoard[8]) ||
                (gameBoard[2] == gameBoard[4] && gameBoard[4] == gameBoard[6]))
            {
                Console.WriteLine("Player {0} wins. Game over.", getPlayerID());
                return true;
            }
            nextPlayerTurn();
            return false;
        }

        // this method is created for unit test, not used for UI.
        public void ImportBoard(string[] import)
        {
            gameBoard = import;
            int dummy;
            int number = 0;
            for (int i = 0; i < import.Length; i++)
            {
                if (int.TryParse(import[i], out dummy))
                {
                    // find out how many places has not been marked
                    number++;
                }
            }
            count = 9 - number;
        }
    }
}
