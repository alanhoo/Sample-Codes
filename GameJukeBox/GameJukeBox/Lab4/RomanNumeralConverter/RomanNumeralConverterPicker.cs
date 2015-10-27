using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab4.RomanNumeralConverter
{
    public class RomanNumeralConverterPicker : ILabSelector
    {
        private RomanNumeralConverterRun _romanNumeralConverterRun;

        public void Execute()
        {
            _romanNumeralConverterRun = new RomanNumeralConverterRun();
            _romanNumeralConverterRun.StartLab();
        }
    }
}
