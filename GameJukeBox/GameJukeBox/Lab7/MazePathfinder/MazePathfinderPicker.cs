using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab7.MazePathfinder
{
    public class MazePathfinderPicker : ILabSelector
    {
        private MazePathfinderRun _mazePathfinderRun;

        public void Execute()
        {
            _mazePathfinderRun = new MazePathfinderRun();
            _mazePathfinderRun.StartLab();
        }
    }
}
