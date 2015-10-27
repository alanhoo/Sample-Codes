using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJukeBox.RockPaperScissor.RockPaperScissor.Models;

namespace GameJukeBox.RockPaperScissor.RockPaperScissor.BLL
{
    public class RandomChoicePicker : IChoiceSelector
    {
        private static Random _rng = new Random();

        public Choice GetOpponentChoice()
        {
            int i = _rng.Next(0, 3);

            switch (i)
            {
                case 0:
                    return Choice.Rock;
                case 1:
                    return Choice.Paper;
                default:
                    return Choice.Scissors;
            }
        }
    }
}
