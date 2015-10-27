using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.RPGInventory.Items.Containers
{
    public class Suitcase : Container
    {
        public Suitcase() : base(20)
        {
            Name = "An aluminium suitcase with wheels";
            Description = string.Format("This is a {0} slot backpack", _capacity);
            Weight = 3;
            Value = 30000;
        }
    }
}
