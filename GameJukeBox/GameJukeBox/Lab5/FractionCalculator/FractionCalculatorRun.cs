using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab5.FractionCalculator
{
    public class FractionCalculatorRun
    {
        public void StartLab()
        {
            string Restart;
            do
            {
                Console.WriteLine("Factions.");
                Console.WriteLine("Enter an operation of your choice:");
                Console.WriteLine("1: Add.");
                Console.WriteLine("2. Subtract.");
                Console.WriteLine("3. Multiply.");
                Console.WriteLine("4. Divide.");

                int userChoice = int.Parse(Console.ReadLine());
                string fraction;
                List<string> fractions = new List<string>();
                do
                {
                    Console.WriteLine("Enter your factions, press N to finish.");
                    fraction = Console.ReadLine();
                    if (fraction.ToUpper() != "N")
                    {
                        fractions.Add(fraction);
                    }

                } while (fraction.ToUpper() != "N");

                FractionCalculatorLogic logic = new FractionCalculatorLogic(fractions);
                switch (userChoice)
                {
                    case 1:
                        logic.AddFractions();
                        break;
                    case 2:
                        logic.SubtractFractions();
                        break;
                    case 3:
                        logic.MultiplyFractions();
                        break;
                    case 4:
                        logic.DivideFractions();
                        break;
                    default:
                        break;
                }

                Console.ReadLine();
                Console.WriteLine("Want to try again(Y/N)?");

                Restart = Console.ReadLine().ToUpper();

                Console.Clear();

            } while (Restart == "Y");
        }
    
    }
}
