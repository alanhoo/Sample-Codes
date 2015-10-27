using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJukeBox.Lab7.MazePathfinder.MazePathfinder.Model;
using GameJukeBox.Lab7.MazePathfinder.MazePathfinder.BLL;

namespace GameJukeBox.Lab7.MazePathfinder
{
    public class MazePathfinderFlow
    {
        private List<StartPosition> _startPositions;

        public MazePathfinderFlow()
        {
            _startPositions = new List<StartPosition>();
            _startPositions.Add(StartPosition.TopRight);
            _startPositions.Add(StartPosition.BottomRight);
            _startPositions.Add(StartPosition.BottomLeft);
        }

        public void Execute()
        {
            Console.WriteLine("Maze Pathfinder.");
            Console.WriteLine("Please read ReadMe file of instruction.");
            string toRestart;

            do
            {
                Console.WriteLine("Enter the size of the maze:");
                Console.WriteLine("Number of column is:");
                int X = int.Parse(Console.ReadLine());
                Console.WriteLine("Number of Row is:");
                int Y = int.Parse(Console.ReadLine());

                Maze maze = new Maze();

                Console.WriteLine("Enter the maze row by row (in 1 or 0):");
                for (int i = 0; i < Y; i++)
                {
                    maze.AddRow(ConvertInputToRow(Console.ReadLine()));
                    maze.DisplayMaze();
                }

                Console.WriteLine("\nMouse starts finding the path.");

                foreach (var startPosition in _startPositions)
                {
                    Console.WriteLine("\nStart at the {0}", startPosition);
                    maze.BeginsFindPath(startPosition);
                }

                Console.ReadLine();
                Console.WriteLine("Enter Y to retart, other keys to end.");
                toRestart = Console.ReadLine().ToUpper();

            } while (toRestart == "Y");
        }

        static private int[] ConvertInputToRow(string input)
        {
            char[] rowInChar;
            rowInChar = input.ToCharArray();

            int[] row = new int[rowInChar.Length];

            for (int i = 0; i < rowInChar.Length; i++)
            {
                row[i] = int.Parse(rowInChar[i].ToString());
            }
            return row;
        }
    }
}
