using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.RPGInventory.Items.Weapons
{
    public class WoodenSword : Item
    {
        public WoodenSword()
        {
            Name = "Wooden Sword";
            Description = "It's dangerous to go alone...";
            Weight = 2;
            Value = 50;
        }
    }
}
