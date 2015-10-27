using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.RPGInventory.Items.Portions
{
    public abstract class Portion : Item
    {
        protected int RecoveryValue { get; set; }
    }
}
