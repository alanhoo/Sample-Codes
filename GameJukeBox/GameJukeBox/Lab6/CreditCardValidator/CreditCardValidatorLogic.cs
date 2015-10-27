using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab6
{
    class CreditCardValidatorLogic
    {
        private List<string> _cardNumber;
        private CardType _cardtype;
        private List<int> _doubleEveryOtherDigit;
        private List<int> _sumDigit;

        public CreditCardValidatorLogic()
        {
            _cardNumber = new List<string>();
            _doubleEveryOtherDigit = new List<int>();
            _sumDigit = new List<int>();
        }

        public void ValidateNumber(string cardNumber)
        {
            if (CheckDigitAndType(cardNumber))
            {
                if (NumberIsValid(cardNumber))
                {
                    Console.WriteLine("It is a valid credit card number.");
                }
                else
                {
                    Console.WriteLine("It is not a valid card.");
                }
            };
            Console.WriteLine();
            Console.WriteLine("Card number {0} is a {1}", cardNumber, _cardtype);
            //Console.WriteLine();
            //PrintDigits();
        }

        private bool NumberIsValid(string cardNumber)
        {
            ReadNumberIntoLists(cardNumber);
            if (SumofDigits() % 10 == 0)
            {
                return true;
            }
            return false;
        }

        private int SumofDigits()
        {
            int sum = 0;

            foreach (var digit in _sumDigit)
            {
                sum += digit;
            }

            return sum;
        }

        private bool CheckDigitAndType(string cardNumber)
        {
            cardNumber = cardNumber.Replace(" ", String.Empty);
            switch (cardNumber.Length)
            {
                case 15:
                    if (cardNumber.Substring(0, 2) == "34" || cardNumber.Substring(0, 2) == "37")
                    {
                        _cardtype = CardType.AmericanExpress;
                    }
                    break;
                case 13:
                    if (cardNumber.Substring(0, 1) == "4")
                    {
                        _cardtype = CardType.Visa;
                    }
                    break;
                case 16:
                    if (cardNumber.Substring(0, 4) == "6011" ||
                        (int.Parse(cardNumber.Substring(0, 6)) >= 622126 &&
                         int.Parse(cardNumber.Substring(0, 6)) <= 622925) ||
                        (int.Parse(cardNumber.Substring(0, 6)) >= 644 &&
                        int.Parse(cardNumber.Substring(0, 6)) <= 649) ||
                        cardNumber.Substring(0, 2) == "65")
                    {
                        _cardtype = CardType.Discover;
                    }
                    else if ((int.Parse(cardNumber.Substring(0, 4)) >= 2221 &&
                              int.Parse(cardNumber.Substring(0, 4)) <= 2720) ||
                             (int.Parse(cardNumber.Substring(0, 2)) >= 51 &&
                              int.Parse(cardNumber.Substring(0, 2)) <= 55))
                    {
                        _cardtype = CardType.Mastercard;
                    }
                    else if (cardNumber.Substring(0, 1) == "4")
                    {
                        _cardtype = CardType.Visa;
                    }
                    break;
                default:
                    _cardtype = CardType.WrongEntry;
                    break;

            }

            if (_cardtype != CardType.WrongEntry)
            {
                return true;
            }

            return false;
        }

        private void ReadNumberIntoLists(string cardNumber)
        {
            for (int i = 0; i < cardNumber.Length; i++)
            {
                if (cardNumber.Substring(cardNumber.Length - 1 - i, 1) != " ")
                {
                    _cardNumber.Add(cardNumber.Substring(cardNumber.Length - 1 - i, 1));
                }
            }

            for (int i = 0; i < _cardNumber.Count; i++)
            {
                if (i % 2 == 1)
                {
                    _doubleEveryOtherDigit.Add(int.Parse(_cardNumber[i]) * 2);
                    _sumDigit.Add(CalculateSumDigit(_doubleEveryOtherDigit[i]));
                }
                else
                {
                    _doubleEveryOtherDigit.Add(int.Parse(_cardNumber[i]));
                    _sumDigit.Add(int.Parse(_cardNumber[i]));
                }

            }

        }

        private int CalculateSumDigit(int doubleDigit)
        {
            if (doubleDigit < 10)
            {
                return doubleDigit;
            }

            return (doubleDigit / 10) + (doubleDigit % 10);
        }

        private void PrintDigits()
        {
            Console.WriteLine();
            foreach (var VARIABLE in _cardNumber)
            {
                Console.Write(VARIABLE);
                Console.Write(" ");
            }
            Console.WriteLine();
            foreach (var VARIABLE in _doubleEveryOtherDigit)
            {
                Console.Write(VARIABLE);
                Console.Write(" ");
            }
            Console.WriteLine();
            foreach (var VARIABLE in _sumDigit)
            {
                Console.Write(VARIABLE);
                Console.Write(" ");
            }
            Console.WriteLine();
        }

    }
}
