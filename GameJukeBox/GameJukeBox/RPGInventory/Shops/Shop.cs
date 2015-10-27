using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJukeBox.RPGInventory.Items;
using GameJukeBox.RPGInventory.Items.Weapons;
using GameJukeBox.RPGInventory.Items.Reagents;
using GameJukeBox.RPGInventory.Items.Portions;

namespace GameJukeBox.RPGInventory.Shops
{
    public abstract class Shop
    {
        protected List<Item> _inventory;

        public string name;
        protected double towninflation;
        protected int shopcash;
        protected double profitmargin;

        public Shop(int investment)
        {
            _inventory = new List<Item>();
            shopcash = investment;

            BattleAxe BattleAxe = new BattleAxe();
            _inventory.Add(BattleAxe);

            WoodenSword WoodenSword = new WoodenSword();
            _inventory.Add(WoodenSword);

            Cloth Cloth = new Cloth();
            _inventory.Add(Cloth);

            Mushroom Mushroom = new Mushroom();
            _inventory.Add(Cloth);

            PortionSmall SmallPortion = new PortionSmall();
            _inventory.Add(SmallPortion);

            PortionMid MediumPortion = new PortionMid();
            _inventory.Add(MediumPortion);
        }

        public virtual void SetInflation(double _inflationrate)
        {
            towninflation = _inflationrate;
        }

        public virtual int BuyUsedfromPlayer(Item item)
        {
            int purchaseprice = (int)(item.Value * (1 - profitmargin));

            if (shopcash < purchaseprice)
            {
                Console.WriteLine("The shop has no enough money to purchase this {0}", item.Name);
                return 0;
            }

            shopcash -= purchaseprice;

            if (!_inventory.Contains(item))
            {
                _inventory.Add(item);
            }
            return purchaseprice;
        }

        public virtual void ShowInventoryMenu()
        {
            Console.WriteLine("This shop has these items:");
            foreach (Item item in _inventory)
            {
                Console.WriteLine("{0} {1}", item.Name, item.Value);
            }
        }

        public List<Item> SendTheMenu()
        {
            return _inventory;
        }

        public bool CheckInStock(Item inquiry)
        {
            foreach (Item item in _inventory)
            {
                if (inquiry.Name == item.Name)
                    return true;
            }
            return false;
        }

        public virtual bool SellItem(/*Player.Player player,*/ Item item)
        {
            if (!CheckInStock(item))
            {
                Console.WriteLine("Item not in stock.");
                return false;
            }

            shopcash += item.Value;
            return true;
           
        }
    }
}
