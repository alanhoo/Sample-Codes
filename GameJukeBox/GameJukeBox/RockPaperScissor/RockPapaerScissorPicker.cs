using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJukeBox.RockPaperScissor;

namespace GameJukeBox
{
    public class RockPapaerScissorPicker : IGameSelector
    {
        private RockPaperScissorRun _rockPaperScissorRun;

        public void Execute()
        {
            _rockPaperScissorRun = new RockPaperScissorRun();
            _rockPaperScissorRun.startGame();
        }
    }
}
