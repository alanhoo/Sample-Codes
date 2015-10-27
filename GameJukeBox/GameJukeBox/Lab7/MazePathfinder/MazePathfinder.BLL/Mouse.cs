using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJukeBox.Lab7.MazePathfinder.MazePathfinder.Model;

namespace GameJukeBox.Lab7.MazePathfinder.MazePathfinder.BLL
{
    public class Mouse
    {
        public List<Coordinate> _path;
        public List<Direction> _directions;

        public Mouse()
        {
            _path = new List<Coordinate>();
            _directions = new List<Direction>();
        }

        // returns a list of next possible coordinates to the maze class for searching a path.
        public List<CoordinateWithDirection> FindCoordinatess(int y, int x, Direction direction)
        {
            List<CoordinateWithDirection> results = new List<CoordinateWithDirection>();
            if (_path.Count == 1)
            {
                // mouse starts from one of the three corners
                if (_path[0]._yCoordinate == 0)  // top right
                {
                    results.Add(new CoordinateWithDirection(y + 1, x, Direction.DOWN)); // down
                    results.Add(new CoordinateWithDirection(y, x - 1, Direction.LEFT)); //left
                }
                else if (_path[0]._xCoordinate == 0)  //bottom left
                {
                    results.Add(new CoordinateWithDirection(y - 1, x, Direction.UP)); //up
                    results.Add(new CoordinateWithDirection(y, x + 1, Direction.RIGHT)); //right
                }
                else    // bottom right
                {
                    results.Add(new CoordinateWithDirection(y - 1, x, Direction.UP)); //up
                    results.Add(new CoordinateWithDirection(y, x - 1, Direction.LEFT)); //left
                }
            }
            else
            {
                // mouse is already on the path
                if (direction == Direction.UP)
                {
                    results.Add(new CoordinateWithDirection(y - 1, x, Direction.UP));
                    results.Add(new CoordinateWithDirection(y, x - 1, Direction.LEFT));
                    results.Add(new CoordinateWithDirection(y, x + 1, Direction.RIGHT));
                }
                else if (direction == Direction.DOWN)
                {
                    results.Add(new CoordinateWithDirection(y + 1, x, Direction.DOWN));
                    results.Add(new CoordinateWithDirection(y, x - 1, Direction.LEFT));
                    results.Add(new CoordinateWithDirection(y, x + 1, Direction.RIGHT));
                }
                else if (direction == Direction.RIGHT)
                {
                    results.Add(new CoordinateWithDirection(y, x + 1, Direction.RIGHT));
                    results.Add(new CoordinateWithDirection(y - 1, x, Direction.UP));
                    results.Add(new CoordinateWithDirection(y + 1, x, Direction.DOWN));
                }
                else
                {
                    results.Add(new CoordinateWithDirection(y, x - 1, Direction.LEFT));
                    results.Add(new CoordinateWithDirection(y - 1, x, Direction.UP));
                    results.Add(new CoordinateWithDirection(y + 1, x, Direction.DOWN));
                }
            }
            return results;
        }

        public void ShowPathList()
        {
            foreach (var coordinate in _path)
            {
                Console.WriteLine("{0} {1}", coordinate._yCoordinate, coordinate._xCoordinate);
            }
        }
    }
}
