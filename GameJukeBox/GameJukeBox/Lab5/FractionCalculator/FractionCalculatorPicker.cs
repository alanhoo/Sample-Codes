using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab5.FractionCalculator
{
    public class FractionCalculatorPicker : ILabSelector
    {
        private FractionCalculatorRun _fractionCalculatorRun;

        public void Execute()
        {
            _fractionCalculatorRun = new FractionCalculatorRun();
            _fractionCalculatorRun.StartLab();
        }
    }
}
