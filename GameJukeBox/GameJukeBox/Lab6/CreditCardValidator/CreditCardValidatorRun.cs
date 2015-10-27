using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab6
{
    public class CreditCardValidatorRun
    {
        public void StartLab()
        {
            string choice;
            do
            {
                Console.WriteLine("Credit Card Validator.");
                Console.WriteLine("Enter your credit card number: ");

                string CardNumber = Console.ReadLine();

                Validate(CardNumber);

                Console.WriteLine("\nDo you want to continue(Y/N)?");
                choice = Console.ReadLine();
                Console.Clear();
            } while (choice.ToUpper() == "Y");

            Console.WriteLine("Bye Bye.");
            Console.ReadLine();
        }

        static public void Validate(string cardNumber)
        {
            CreditCardValidatorLogic c = new CreditCardValidatorLogic();
            c.ValidateNumber(cardNumber);
        }
    }
    
}
