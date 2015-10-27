using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.RPGInventory.Items.Reagents
{
    public class Cloth : Item
    {
        public Cloth()
        {
            Name = "A piece of white cloth";
            Description = "Very plain and cotton";
            Value = 5;
            Weight = 1;
        }
    }
}
