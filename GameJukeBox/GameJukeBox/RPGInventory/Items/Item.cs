using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.RPGInventory.Items
{
    public abstract class Item
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public int Weight { get; set; }
        public int Value { get; set; }
    }
}
