using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJukeBox.TicTacToe;

namespace GameJukeBox
{
    public class TicTacToePicker : IGameSelector
    {
        private TicTacToeRun _ticTacToeRun;

        public void Execute()
        {
            _ticTacToeRun = new TicTacToeRun();
            _ticTacToeRun.startGame();
        }
    }
}
