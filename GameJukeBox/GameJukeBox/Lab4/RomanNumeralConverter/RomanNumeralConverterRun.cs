using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab4.RomanNumeralConverter
{
    public class RomanNumeralConverterRun
    {
        public void StartLab()
        {
            Console.WriteLine("Integer to Roman Numerals.");
            Console.WriteLine("Enter an integer from 1 to 1000:");
            int number = int.Parse(Console.ReadLine());

            string romanResult = convertToRomanNumeral(number);

            Console.WriteLine("The Romanic Numeral is: {0}", romanResult);
            Console.ReadLine();
        }

        private string convertToRomanNumeral(int number)
        {
            string romanResult = "";

            do
            {
                if (number == 1000)
                {
                    romanResult += "M";
                    number -= 1000;
                }
                else if (number >= 900)
                {
                    romanResult += "CM";
                    number -= 900;
                }
                else if (number >= 500)
                {
                    romanResult += "D";
                    number -= 500;
                }
                else if (number >= 400)
                {
                    romanResult += "CD";
                    number -= 400;
                }
                else if (number >= 100)
                {
                    romanResult += "C";
                    number -= 100;
                }
                else if (number >= 90)
                {
                    romanResult += "XC";
                    number -= 90;
                }
                else if (number >= 50)
                {
                    romanResult += "L";
                    number -= 50;
                }
                else if (number >= 40)
                {
                    romanResult += "XL";
                    number -= 40;
                }
                else if (number >= 10)
                {
                    romanResult += "X";
                    number -= 10;
                }
                else if (number >= 9)
                {
                    romanResult += "IX";
                    number -= 9;
                }
                else if (number >= 5)
                {
                    romanResult += "V";
                    number -= 5;
                }
                else if (number >= 4)
                {
                    romanResult += "IV";
                    number -= 4;
                }
                else if (number >= 1)
                {
                    romanResult += "I";
                    number -= 1;
                }
            } while (number > 0);

            return romanResult;
        }
    }
}
