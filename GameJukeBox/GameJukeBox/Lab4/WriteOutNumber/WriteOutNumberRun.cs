using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab4.WriteOutNumber
{
    public class WriteOutNumberRun
    {
        public void StartLab()
        {
            string choice;
            do
            {
                Console.WriteLine("Write Out Number.");
                Console.WriteLine("Enter a number between 1 to 10000:");
                int number = int.Parse(Console.ReadLine());

                WriteOutNumberLogic w = new WriteOutNumberLogic(number);
                Console.WriteLine(w.writeNumber());

                Console.WriteLine("\nDo you want to retry?");

                choice = Console.ReadLine().ToUpper();
            } while (choice == "Y");

            Console.ReadLine();

        }
    }
}
