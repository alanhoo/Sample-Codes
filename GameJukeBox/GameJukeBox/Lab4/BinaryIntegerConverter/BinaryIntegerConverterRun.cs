using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab4.BinaryIntegerConverter
{
    public class BinaryIntegerConverterRun
    {
        public void StartGame()
        {
            Console.WriteLine("Binary Integer Converter.");
            Console.WriteLine("Enter a number:");
            int number = int.Parse(Console.ReadLine());

            Stack<int> result = new Stack<int>();
            result = ConvertBinaryToInteger(number);

            Console.WriteLine("The binary conversion is:");
            foreach (var VARIABLE in result)
            {
                Console.Write("{0}", VARIABLE);
            }
            Console.ReadLine();
        }

        private Stack<int> ConvertBinaryToInteger(int number)
        {
            Stack<int> result = new Stack<int>();
            do
            {
                if (number % 2 == 1)
                {
                    result.Push(1);
                }
                else
                {
                    result.Push(0);
                }
                number /= 2;
            } while (number > 0);

            return result;
        }
    }
}
