using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab5.MortgageCalculator
{
    public class MortgageCalculatorLogic
    {
        private List<double> _principleschedule;
        private List<double> _interestschedule;
        private List<double> _balanceschedule;

        private double _balance { get; set; }
        private double _annualrate { get; set; }
        private int _numberofterm { get; set; }
        private double _monthlypayment { get; set; }

        public MortgageCalculatorLogic()
        {
            _balance = 10000;
            _annualrate = 0.05;
            _numberofterm = 120;
            _principleschedule = new List<double>();
            _interestschedule = new List<double>();
            _balanceschedule = new List<double>();
        }

        private void createAmortizationSchedule()
        {
            double monthlyinterest;
            double monthlyprincipalrepayment;
            double balance = _balance;
            for (int i = 0; i < _numberofterm; i++)
            {
                monthlyinterest = CalculateMonthlyInterest(balance);
                _interestschedule.Add(monthlyinterest);

                monthlyprincipalrepayment = _monthlypayment - monthlyinterest;
                _principleschedule.Add(monthlyprincipalrepayment);

                balance -= monthlyprincipalrepayment;
                _balanceschedule.Add(balance);
            }
        }

        private void displayAmortizationSchedule()
        {
            Console.WriteLine(" Term       Interest       Principal    Balance");
            for (int i = 0; i < _numberofterm; i++)
            {
                Console.WriteLine("{0}         {1:0.00}          {2:0.00}          {3:0.00}",
                    i + 1, _interestschedule[i], _principleschedule[i], _balanceschedule[i]);
            }
            Console.ReadLine();
        }

        private double CalculateMonthlyInterest(double principal)
        {
            return principal * (_annualrate / 12);

        }

        private void calculateMonthlyPayment()
        {
            double monthlyrate = _annualrate / 12;
            // (1+i)^n
            double compoundfactor = Math.Pow((1 + monthlyrate), _numberofterm);

            _monthlypayment = _balance * monthlyrate * compoundfactor / (compoundfactor - 1);
        }

        private void DisplayPayment()
        {
            //Console.WriteLine("");
            //Console.WriteLine("Monthly Payment:{0:0.00}", _monthlypayment);
            //Console.WriteLine("Monthly Interest: {0:0.00}", firstmonthinterest);
            //Console.WriteLine("Principal repayment: {0:0.00}", _monthlypayment-firstmonthinterest);
            //Console.ReadLine();
        }

        public void CalculateMortgage()
        {
            Console.WriteLine("Enter the mortgage balance:");
            _balance = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the annual interest rate:");
            _annualrate = double.Parse(Console.ReadLine()) / 100.00;

            Console.WriteLine("Enter the term in year:");
            _numberofterm = int.Parse(Console.ReadLine()) * 12;

            calculateMonthlyPayment();
            createAmortizationSchedule();
            displayAmortizationSchedule();
        }

        public void DisplayDefault()
        {
            Console.WriteLine("For this demo, the balance is {0}. Interest rate is {1}%. Term is {2}.", _balance, _annualrate * 100, _numberofterm);
            calculateMonthlyPayment();
            createAmortizationSchedule();
            displayAmortizationSchedule();
        }
    }
}
