using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJukeBox.RockPaperScissor.RockPaperScissor.Models;

namespace GameJukeBox.RockPaperScissor.RockPaperScissor.BLL
{
    public interface IChoiceSelector
    {
        Choice GetOpponentChoice();
    }
}
