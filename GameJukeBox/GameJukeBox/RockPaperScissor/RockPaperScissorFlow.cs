using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJukeBox.RockPaperScissor.RockPaperScissor.Models;
using GameJukeBox.RockPaperScissor.RockPaperScissor.BLL;

namespace GameJukeBox.RockPaperScissor
{
    public class RockPaperScissorFlow
    {
        public void Execute()
        {
            string input = "A";
            Game game;


            Console.WriteLine("Select a Mode:  (E)asy, (N)ormal, or (2) Player");
            input = Console.ReadLine();

            if (input == "N")
            {
                game = new Game(new RandomChoicePicker());
            }
            else if (input == "2")
            {
                game = new Game(new TwoPlayersChoicePicker());
            }
            else
            {
                game = new Game(new EasyChoicePicker());
            }

            do
            {
                Choice userChoice = GetUserChoice();
                var result = game.PlayRound(userChoice);

                ProcessResult(result);

                Console.ReadLine();
            } while (input.ToUpper() != "Q");

        }

        private void ProcessResult(MatchResults result)
        {
            Console.WriteLine("You picked {0}, your opponent picked {1}", Enum.GetName(typeof(Choice), result.UserChoice),
                Enum.GetName(typeof(Choice), result.ComputerChoice));

            switch (result.Result)
            {
                case GameResults.Loss:
                    Console.WriteLine("You Lose!");
                    break;
                case GameResults.Tie:
                    Console.WriteLine("You Tied!");
                    break;
                default:
                    Console.WriteLine("You Won!");
                    break;
            }
        }

        private Choice GetUserChoice()
        {
            Console.Clear();
            Console.Write("Player 1: Enter your choice (R)ock, (P)aper, (S)cissors: ");
            string input = Console.ReadLine();

            switch (input.ToUpper())
            {
                case "P":
                    return Choice.Paper;
                case "R":
                    return Choice.Rock;
                default:
                    return Choice.Scissors;
            }
        }
    }
}
