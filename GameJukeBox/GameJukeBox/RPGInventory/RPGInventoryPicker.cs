using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJukeBox.RPGInventory;

namespace GameJukeBox.RPGInventory
{
    public class RPGInventoryPicker : IGameSelector
    {
        private RPGInventoryRun _rpgInventoryRun;

        public void Execute()
        {
            _rpgInventoryRun = new RPGInventoryRun();
            _rpgInventoryRun.StartGame();
        }
    }
}
