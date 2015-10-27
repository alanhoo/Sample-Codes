using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJukeBox.RPGInventory.Items.Containers;

namespace GameJukeBox.RPGInventory.Player
{
    public class Bum : Player
    {
        public Bum() : base(5)
        {
            Name = "A Bum";
            Bag = new Satchel();
        }
    }
}
