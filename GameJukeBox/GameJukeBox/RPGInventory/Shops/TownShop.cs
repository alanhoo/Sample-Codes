using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJukeBox.RPGInventory.Items.Portions;
using GameJukeBox.RPGInventory.Items.Weapons;

namespace GameJukeBox.RPGInventory.Shops
{
    public class TownShop : Shop
    {
        public TownShop() : base(99999)
        {
            name = "Town Shop";

            profitmargin = 0.15;

            PortionLarge largePortion = new PortionLarge();
            _inventory.Add(largePortion);

            Katana katana = new Katana();
            _inventory.Add(katana);
        }

        public override void SetInflation(double _inflationrate)
        {
            base.SetInflation(_inflationrate);
        }
    }
}
