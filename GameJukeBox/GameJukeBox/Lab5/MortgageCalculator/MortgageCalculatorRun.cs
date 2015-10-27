using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab5.MortgageCalculator
{
    public class MortgageCalculatorRun
    {
        public void StartLab()
        {
            int Choice;
            do
            {
                Console.WriteLine("Mortgage Calcultor.");
                Console.WriteLine("Enter a number to choose the following options:");
                Console.WriteLine("1. See a demo.");
                Console.WriteLine("2. Calculate your mortgage payment.");
                Console.WriteLine("3. Quit.");

                Choice = int.Parse(Console.ReadLine());

                switch (Choice)
                {
                    case 1:
                        DisplayDefault();
                        break;
                    case 2:
                        CalculateMortgage();
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
                Console.Clear();

            } while (Choice == 1 || Choice == 2);
        }

        static public void DisplayDefault()
        {
            MortgageCalculatorLogic m = new MortgageCalculatorLogic();
            m.DisplayDefault();
        }

        static public void CalculateMortgage()
        {
            MortgageCalculatorLogic m = new MortgageCalculatorLogic();
            m.CalculateMortgage();
        }
    }
}
