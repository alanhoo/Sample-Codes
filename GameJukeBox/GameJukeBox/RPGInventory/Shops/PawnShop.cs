using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.RPGInventory.Shops
{
    public class PawnShop : Shop
    {
        public PawnShop() : base(9999)
        {
            name = "Pawn Shop";

            profitmargin = 0.50;
        }
    }
}
