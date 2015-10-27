using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab7.MazePathfinder.MazePathfinder.Model
{
    public class Coordinate
    {
        public int _xCoordinate { get; set; }
        public int _yCoordinate { get; set; }

        public Coordinate(int y, int x)
        {
            _xCoordinate = x;
            _yCoordinate = y;
        }
    }
}
