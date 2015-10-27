using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab4.QueenTakesKing
{
    public class QueenTakesKingFlow
    {
        private int[] queenCoordinates;
        private int[] kingCoordinates;

        public QueenTakesKingFlow(string QueenCoordinate, string KingCoordinate)
        {
            queenCoordinates = CoordinateConverter(QueenCoordinate);
            kingCoordinates = CoordinateConverter(KingCoordinate);
        }

        public bool isKingTaken()
        {
            return (CheckDiagonals() || CheckHorizon() || CheckVertical());
        }

        private int[] CoordinateConverter(string Coordinate)
        {
            string x = Coordinate.Substring(0, 1);
            int xCoordinate;
            switch (x.ToUpper())
            {
                case "A":
                    xCoordinate = 1;
                    break;
                case "B":
                    xCoordinate = 2;
                    break;
                case "C":
                    xCoordinate = 3;
                    break;
                case "D":
                    xCoordinate = 4;
                    break;
                case "E":
                    xCoordinate = 5;
                    break;
                case "F":
                    xCoordinate = 6;
                    break;
                case "G":
                    xCoordinate = 7;
                    break;
                case "H":
                    xCoordinate = 8;
                    break;
                default:
                    xCoordinate = 0;
                    break;
            }

            int[] coordinate = new int[2];
            coordinate[0] = xCoordinate;
            coordinate[1] = int.Parse(Coordinate.Substring(1));

            return coordinate;
        }

        private bool CheckVertical()
        {
            return (queenCoordinates[0] == kingCoordinates[0]);
        }

        private bool CheckHorizon()
        {
            return (queenCoordinates[1] == kingCoordinates[1]);
        }

        private bool CheckDiagonals()
        {
            return Math.Abs(queenCoordinates[0] - kingCoordinates[0]) == Math.Abs(queenCoordinates[1] - kingCoordinates[1]);
        }
    }
}
