using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab6
{
    public class CreditCardValidatorPicker : ILabSelector
    {
        private CreditCardValidatorRun _creditCardValidatorRun;

        public void Execute()
        {
            _creditCardValidatorRun = new CreditCardValidatorRun();
            _creditCardValidatorRun.StartLab();
        }
    }
}
