using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab7.MazePathfinder.MazePathfinder.Model
{
    public class CoordinateWithDirection
    {
        public Coordinate _coordinate;
        public Direction _direction;

        public CoordinateWithDirection(int y, int x, Direction direction)
        {
            _coordinate = new Coordinate(y, x);
            _direction = direction;
        }
    }
}
