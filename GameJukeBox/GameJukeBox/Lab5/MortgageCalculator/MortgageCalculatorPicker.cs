using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab5.MortgageCalculator
{
    public class MortgageCalculatorPicker : ILabSelector
    {
        private MortgageCalculatorRun _mortgageCalculatorRun;

        public void Execute()
        {
            _mortgageCalculatorRun = new MortgageCalculatorRun();
            _mortgageCalculatorRun.StartLab();
        }
    }
}
