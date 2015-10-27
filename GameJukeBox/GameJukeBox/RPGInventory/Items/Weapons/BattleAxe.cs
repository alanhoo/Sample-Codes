using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.RPGInventory.Items.Weapons
{
    public class BattleAxe : Item
    {
        public BattleAxe()
        {
            Name = "Battle Axe";
            Description = "This pleases KRONG!";
            Weight = 10;
            Value = 2000;
        }
    }
}
