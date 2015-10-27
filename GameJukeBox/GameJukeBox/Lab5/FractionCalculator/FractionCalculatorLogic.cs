using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab5.FractionCalculator
{
    public class FractionCalculatorLogic
    {
        private int[] numerators;
        private int[] denominators;
        private int commonDenominator;
        private int[] newNumerators;
        private int answerDenominator;
        private int answerNumerator;
        private string answer;

        public FractionCalculatorLogic(List<string> factions)
        {
            numerators = new int[factions.Count];
            numerators = listNumerators(factions);
            denominators = new int[factions.Count];
            denominators = listDenominators(factions);
            commonDenominator = findCommonDenominator();
            newNumerators = findNewNumerators();
            answerNumerator = 0;
            answerDenominator = 1;
        }

        private int[] listNumerators(List<string> factions)
        {
            int[] numerators = new int[factions.Count];
            for (int i = 0; i < factions.Count; i++)
            {
                numerators[i] = int.Parse(factions[i].Substring(0, factions[i].IndexOf("/")));
            }
            return numerators;
        }

        private int[] listDenominators(List<string> factions)
        {
            int[] denominators = new int[factions.Count];
            for (int i = 0; i < factions.Count; i++)
            {
                denominators[i] = int.Parse(factions[i].Substring(factions[i].IndexOf("/") + 1));
            }
            return denominators;
        }

        private int findCommonDenominator()
        {
            int commonDenominator = 1;

            for (int i = 0; i < denominators.Length; i++)
            {
                commonDenominator *= denominators[i];
            }

            return commonDenominator;
        }

        private int[] findNewNumerators()
        {
            int[] newNumerators = new int[numerators.Length];
            for (int i = 0; i < newNumerators.Length; i++)
            {
                newNumerators[i] = numerators[i] * (commonDenominator / denominators[i]);
            }
            return newNumerators;
        }

        private void displayAnswer()
        {
            if (answerNumerator % answerDenominator == 0)
            {
                int answer = answerNumerator / answerDenominator;
                Console.WriteLine("The answer is {0}.", answer);
            }
            else
            {
                Console.WriteLine("The answer is: {0} / {1}", answerNumerator, answerDenominator);
            }
        }

        private int CommonFactor()
        {
            int commonfactor = 1;

            for (int i = 2; i <= answerNumerator; i++)
            {
                if (answerNumerator % i == 0 && answerDenominator % i == 0)
                {
                    commonfactor = i;
                }
            }
            return commonfactor;
        }

        private void SimplifyAnswer(int commonfactor)
        {
            answerNumerator /= commonfactor;
            answerDenominator /= commonfactor;
        }

        public void AddFractions()
        {
            for (int i = 0; i < newNumerators.Length; i++)
            {
                answerNumerator += newNumerators[i];
            }

            answerDenominator = commonDenominator;
            SimplifyAnswer(CommonFactor());

            displayAnswer();
        }

        public void SubtractFractions()
        {
            answerNumerator = newNumerators[0];

            for (int i = 1; i < newNumerators.Length; i++)
            {
                answerNumerator -= newNumerators[i];
            }

            answerDenominator = commonDenominator;
            SimplifyAnswer(CommonFactor());

            displayAnswer();
        }

        public void MultiplyFractions()
        {
            answerNumerator = 1;
            foreach (var numerator in numerators)
            {
                answerNumerator *= numerator;
            }

            answerDenominator = 1;
            foreach (var denominator in denominators)
            {
                answerDenominator *= denominator;
            }

            SimplifyAnswer(CommonFactor());

            displayAnswer();
        }

        public void DivideFractions()
        {
            answerNumerator = numerators[0];
            answerDenominator = denominators[0];

            for (int i = 1; i < denominators.Length; i++)
            {
                answerNumerator *= denominators[i];
            }

            for (int i = 1; i < numerators.Length; i++)
            {
                answerDenominator *= numerators[i];
            }

            SimplifyAnswer(CommonFactor());

            displayAnswer();
        }
    }
}
