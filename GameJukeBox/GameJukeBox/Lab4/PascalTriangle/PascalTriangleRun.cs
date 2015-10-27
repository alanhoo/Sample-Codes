using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab4.PascalTriangle
{
    public class PascalTriangleRun
    {
        public void StartLab()
        {
            Console.WriteLine("Pascal Triangle");
            Console.WriteLine("Enter a number to show the row in triangle:");
            int input = int.Parse(Console.ReadLine());

            printTriangle(input);         

            Console.ReadLine();
        }

        private void printTriangle(int input)
        {
            List<int>[] PascalTriangle = new List<int>[input];

            for (int i = 0; i < input; i++)
            {
                List<int> row = new List<int>();
                PascalTriangle[i] = row;

                if (i == 0)
                {
                    row.Add(1);
                }
                else if (input >= 2 && i == 1)
                {
                    row.Add(1);
                    row.Add(1);
                }
                else
                {
                    for (int j = 0; j <= i; j++)
                    {
                        if (j == 0 || j == i)
                        {
                            row.Add(1);
                        }
                        else
                        {
                            row.Add(PascalTriangle[i - 1][j - 1] + PascalTriangle[i - 1][j]);
                        }
                    }
                }
            }

            for (int i = 0; i < PascalTriangle.Length; i++)
            {
                string PrintString = "";
                foreach (int VARIABLE in PascalTriangle[i])
                {
                    PrintString += VARIABLE.ToString();
                    PrintString += " ";
                }
                Console.Write(new string(' ', (Console.WindowWidth - PrintString.Length) / 2));
                Console.WriteLine(PrintString);
            }
        }

    }
}
