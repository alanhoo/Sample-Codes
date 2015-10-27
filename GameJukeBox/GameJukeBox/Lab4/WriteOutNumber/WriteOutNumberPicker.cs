using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab4.WriteOutNumber
{
    public class WriteOutNumberPicker : ILabSelector
    {
        private WriteOutNumberRun _writeOutNumberRun;

        public void Execute()
        {
            _writeOutNumberRun = new WriteOutNumberRun();
            _writeOutNumberRun.StartLab();
        }
    }
}
