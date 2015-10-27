using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJukeBox.RockPaperScissor.RockPaperScissor.Models;

namespace GameJukeBox.RockPaperScissor.RockPaperScissor.BLL
{
    public class EasyChoicePicker : IChoiceSelector
    {
        private static Random _rng = new Random();

        public Choice GetOpponentChoice()
        {
            int i = _rng.Next(1, 101);

            if (i <= 80)
                return Choice.Rock;

            if (i <= 90)
                return Choice.Paper;

            return Choice.Scissors;
        }
    }
}
