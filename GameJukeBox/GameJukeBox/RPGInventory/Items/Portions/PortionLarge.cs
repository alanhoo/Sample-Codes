using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.RPGInventory.Items.Portions
{
    public class PortionLarge : Portion
    {
        public PortionLarge()
        {
            Name = "Portion Large";
            Description = "Large size portion, expensive but powerful";
            Value = 100;
            Weight = 4;
            RecoveryValue = 80;
        }
    }
}
