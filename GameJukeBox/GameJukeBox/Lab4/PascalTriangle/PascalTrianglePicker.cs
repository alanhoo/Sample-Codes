using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.Lab4.PascalTriangle
{
    public class PascalTrianglePicker : ILabSelector
    {
        private PascalTriangleRun _pascalTriangleRun;

        public void Execute()
        {
            _pascalTriangleRun = new PascalTriangleRun();
            _pascalTriangleRun.StartLab();
        }
    }
}
