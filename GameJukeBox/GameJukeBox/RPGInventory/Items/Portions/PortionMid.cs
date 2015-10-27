using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.RPGInventory.Items.Portions
{
    public class PortionMid : Portion
    {
        public PortionMid()
        {
            Name = "Portion Medium";
            Description = "Medium size portion, slightly bigger than small portion";
            Value = 40;
            Weight = 2;
            RecoveryValue = 40;
        }
    }
}
