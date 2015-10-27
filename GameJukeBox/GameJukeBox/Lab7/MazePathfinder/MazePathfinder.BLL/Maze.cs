using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJukeBox.Lab7.MazePathfinder.MazePathfinder.Model;

namespace GameJukeBox.Lab7.MazePathfinder.MazePathfinder.BLL
{
    public class Maze
    {
        private List<int[]> _maze;
        private List<int[]> _mazeForDisplay;
        private Mouse _mouse;
        private List<Direction> _pathmemory;
        private int _yBorder;
        private int _xBorder;

        public Maze()
        {
            _maze = new List<int[]>();
            _mazeForDisplay = new List<int[]>();
            _mouse = new Mouse();
            _pathmemory = new List<Direction>();
        }

        // This constructor is never used but reserved for potential expansion. It copied the maze from another maze object.
        public Maze(Maze mazeToCopy)
        {
            _maze = new List<int[]>();
            _mazeForDisplay = new List<int[]>();
            _mouse = new Mouse();
            _pathmemory = new List<Direction>();

            for (int i = 0; i < mazeToCopy._maze.Count; i++)
            {
                int[] newRow = new int[mazeToCopy._maze[i].Length];

                for (int j = 0; j < mazeToCopy._maze[i].Length; j++)
                {
                    newRow[j] = mazeToCopy._maze[i][j];
                }
                AddRow(newRow);
            }
        }

        public void BeginsFindPath(StartPosition startPosition)
        {
            _yBorder = _maze.Count;
            _xBorder = _maze[0].Length;

            if (startPosition == StartPosition.TopRight)
            {
                StartPath(0, _xBorder - 1, Direction.LEFT);
            }
            else if (startPosition == StartPosition.BottomRight)
            {
                StartPath(_yBorder - 1, _xBorder - 1, Direction.LEFT);
            }
            else
            {
                StartPath(_yBorder - 1, 0, Direction.UP);
            }
        }

        private void StartPath(int y, int x, Direction direction)
        {
            Coordinate c = new Coordinate(y, x);

            _mouse._path.Add(c);
            if (FindNextPath(y, x, direction))
            {
                Console.WriteLine("We find the path.");
            }
            else
            {
                Console.WriteLine("Can't find a path.");
            }
            ShowPathMemory();
            ClearPathMemory();
        }

        private bool FindNextPath(int y, int x, Direction direction)
        {
            if (x == 0 && y == 0)
            {
                _pathmemory.Add(direction);
                return true;
            }

            if (_maze[y][x] == 0)
            {
                return false;
            }

            List<CoordinateWithDirection> nextCoordinates = new List<CoordinateWithDirection>();
            nextCoordinates = _mouse.FindCoordinatess(y, x, direction);
            int count = 0;

            for (int i = 0; i < nextCoordinates.Count; i++)
            {
                if (WithinTheMaze(nextCoordinates[i]._coordinate._yCoordinate, nextCoordinates[i]._coordinate._xCoordinate))
                {
                    _mouse._path.Add(new Coordinate(nextCoordinates[i]._coordinate._yCoordinate,
                        nextCoordinates[i]._coordinate._xCoordinate));

                    if (_maze[nextCoordinates[i]._coordinate._yCoordinate][nextCoordinates[i]._coordinate._xCoordinate] == 1)
                    {
                        count++;
                        if (FindNextPath(nextCoordinates[i]._coordinate._yCoordinate, nextCoordinates[i]._coordinate._xCoordinate, nextCoordinates[i]._direction))
                        {
                            _pathmemory.Add(direction);                      
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool WithinTheMaze(int y, int x)
        {
            return (y >= 0 && y <= _maze.Count - 1)
                   && (x >= 0 && x <= _maze[0].Length - 1);
        }

        private void ShowPathMemory()
        {
            Console.WriteLine("The direction list:");
            for (int i = 1; i < _pathmemory.Count; i++)
            {
                Console.Write(_pathmemory[_pathmemory.Count - 1 - i]);
                Console.Write(" ");
            }

            Console.WriteLine();
        }

        public void AddRow(int[] row)
        {
            int[] copyOfRow = new int[row.Length];
            for (int i = 0; i < row.Length; i++)
            {
                copyOfRow[i] = row[i];
            }
            _maze.Add(row);
            _mazeForDisplay.Add(row);
        }

        private void ClearPathMemory()
        {
            _pathmemory.Clear();
        }

        public void DisplayMaze()
        {
            Console.Clear();
            foreach (var row in _maze)
            {
                foreach (var letter in row)
                {
                    Console.Write(letter);
                }
                Console.Write("\n");
            }
        }
    }
}
