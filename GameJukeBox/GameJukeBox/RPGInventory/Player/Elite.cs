using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJukeBox.RPGInventory.Items.Containers;

namespace GameJukeBox.RPGInventory.Player
{
    public class Elite : Player
    {
        public Elite() : base(50000)
        {
            Name = "The Social Elite";
            Bag = new Suitcase();
        }
    }
}
