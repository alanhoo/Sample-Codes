using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.RockPaperScissor
{
    public class RockPaperScissorRun
    {

        public void startGame()
        {
            Console.WriteLine("You are now in Rock Scissor Paper game.");
            RockPaperScissorFlow gw = new RockPaperScissorFlow();
            gw.Execute();
        }
    }
}
