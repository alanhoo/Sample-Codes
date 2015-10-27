using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab4.BinaryIntegerConverter
{
    public class BinaryIntegerConverterPicker : ILabSelector
    {
        private BinaryIntegerConverterRun _binaryIntegerConverterRun;

        public void Execute()
        {
            _binaryIntegerConverterRun = new BinaryIntegerConverterRun();
            _binaryIntegerConverterRun.StartGame();
        }
    }
}
