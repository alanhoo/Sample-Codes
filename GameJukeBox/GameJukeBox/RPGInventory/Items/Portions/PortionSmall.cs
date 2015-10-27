using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.RPGInventory.Items.Portions
{
    public class PortionSmall : Portion
    {
        public PortionSmall()
        {
            Name = "Portion Small";
            Description = "Small size portion.";
            Value = 20;
            Weight = 1;
            RecoveryValue = 20;
        }
    }
}
