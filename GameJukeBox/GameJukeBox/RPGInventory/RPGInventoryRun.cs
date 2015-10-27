using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.RPGInventory
{
    public class RPGInventoryRun
    {
        public void StartGame()
        {
            RPGInventoryFlow flow = new RPGInventoryFlow();
            flow.Execute();
        }
    }
}
