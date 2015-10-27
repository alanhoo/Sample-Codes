using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameJukeBox
{
    class Program
    {
        static void Main(string[] args)
        {
            JukeBoxWorkFlow flow = new JukeBoxWorkFlow();
            flow.Execute();
        }
    }
}
