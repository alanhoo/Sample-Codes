using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.TicTacToe.TicTacToe.BLL.Response
{
    public class MarkResponse
    {
        public enum MarkPlacement
        {
            Overlap,
            Full,
            Win,
            Ok
        }
    }
}
