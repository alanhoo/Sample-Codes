using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJukeBox.RockPaperScissor.RockPaperScissor.Models;

namespace GameJukeBox.RockPaperScissor.RockPaperScissor.BLL
{
    public class TwoPlayersChoicePicker : IChoiceSelector
    {
        public Choice GetOpponentChoice()
        {
            Console.Clear();
            Console.Write("Player 2: Enter your choice (R)ock, (P)aper, (S)cissors: ");
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
