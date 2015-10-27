using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.RPGInventory.Items.Reagents
{
    public class Mushroom : Item
    {
        public Mushroom()
        {
            Name = "A Brown Mushroom";
            Description = "This mushroom reeks of Mildew";
            Weight = 1;
            Value = 1;
        }
    }
}
