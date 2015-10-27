using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab4.WriteOutNumber
{
    class WriteOutNumberLogic
    {
        private int thousands;
        private int hundreds;
        private int twoDigits;
        private int tens;
        private int single;

        public WriteOutNumberLogic(int number)
        {
            if (number <= 10)
            {
                twoDigits = number;
            }
            else
            {
                thousands = number/1000;
                hundreds = (number%1000)/100;
                twoDigits = (number%100);
                if (twoDigits > 20)
                {
                    tens = twoDigits/10;
                    single = twoDigits%10;
                }
            }
        }

        public string writeNumber()
        {
            string result = string.Empty;

            if (thousands != 0)
            {
                result += writeOnetoTen(thousands) + " Thousands ";
            }

            if (hundreds != 0)
            {
                result += writeOnetoTen(hundreds) + " Hundreds ";
            }

            if (twoDigits > 20)
            {
                return result + writeTens(tens) + " " + writeOnetoTen(single);
            }
            else if (twoDigits <= 10)
            {
                return result + writeOnetoTen(twoDigits);
            }
            else
            {
                return result + writeElevenToTwenty(twoDigits);
            }
        }

        private string writeOnetoTen(int number)
        {
            switch (number)
            {
                case 1:
                    return "One";
                    break;
                case 2:
                    return "Two";
                    break;
                case 3:
                    return "Three";
                    break;
                case 4:
                    return "Four";
                    break;
                case 5:
                    return "Five";
                    break;
                case 6:
                    return "Six";
                    break;
                case 7:
                    return "Seven";
                    break;
                case 8:
                    return "Eight";
                    break;
                case 9:
                    return "Nine";
                    break;
                case 10:
                    return "Ten";
                    break;
                default:
                    return "";
                    break;
            }
        }

        private string writeElevenToTwenty(int number)
        {
            switch (number)
            {
                case 11:
                    return "Eleven";
                    break;
                case 12:
                    return "Twelve";
                    break;
                case 13:
                    return "Thirteen";
                    break;
                case 14:
                    return "Fourteen";
                    break;
                case 15:
                    return "Fifteen";
                    break;
                case 16:
                    return "Sixteen";
                    break;
                case 17:
                    return "Seventeen";
                    break;
                case 18:
                    return "Eighteen";
                    break;
                case 19:
                    return "Nineteen";
                    break;
                case 20:
                    return "Twenty";
                    break;
                default:
                    return "";
                    break;
            }
        }

        private string writeTens(int tens)
        {
            switch (tens)
            {
                case 1:
                    return "Ten";
                    break;
                case 2:
                    return "Twenty";
                    break;
                case 3:
                    return "Thirty";
                    break;
                case 4:
                    return "Forty";
                    break;
                case 5:
                    return "Fifty";
                    break;
                case 6:
                    return "Sixty";
                    break;
                case 7:
                    return "Seventy";
                    break;
                case 8:
                    return "Eighty";
                    break;
                case 9:
                    return "Ninty";
                    break;
                default:
                    return "";
                    break;
            }
        }
    }
}
