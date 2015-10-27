using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.RPGInventory.Items.Weapons
{
    public class Katana : Item
    {
        public Katana()
        {
            Name = "Katana";
            Description = "Legendary weapon. Can cut anything in half.";
            Weight = 10;
            Value = 50000;
        }
    }
}
