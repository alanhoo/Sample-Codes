using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.RockPaperScissor.RockPaperScissor.Models
{
    public class MatchResults
    {
        public Choice UserChoice { get; set; }
        public Choice ComputerChoice { get; set; }
        public GameResults Result { get; set; }
    }
}
