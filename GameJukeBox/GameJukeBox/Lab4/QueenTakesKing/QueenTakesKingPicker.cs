using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab4.QueenTakesKing
{
    public class QueenTakesKingPicker : ILabSelector
    {
        private QueenTakesKingRun _queenTakesKingRun;

        public void Execute()
        {
            _queenTakesKingRun = new QueenTakesKingRun();
            _queenTakesKingRun.StartLab();
        }
    }
}
