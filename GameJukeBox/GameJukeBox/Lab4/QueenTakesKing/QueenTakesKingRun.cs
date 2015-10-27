using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab4.QueenTakesKing
{
    public class QueenTakesKingRun
    {
        public void StartLab()
        {
            string choice;
            do
            {
                Console.WriteLine("Queens Take King.");
                Console.WriteLine("Enter Queen's Coordinate(e.g A1):");
                string QueenCoordinate = Console.ReadLine();
                Console.WriteLine("Enter King's Coordinate(e.g A1):");
                string KingCoordinate = Console.ReadLine();

                QueenTakesKingFlow flow = new QueenTakesKingFlow(QueenCoordinate, KingCoordinate);

                string result;
                if (flow.isKingTaken())
                {
                    result = "Y";
                }
                else
                {
                    result = "N";
                }

                Console.WriteLine(result);
                Console.WriteLine("Do you want to replay(Y/N):");
                choice = Console.ReadLine();
            } while (choice.ToUpper() == "Y");
        }
    }
}
