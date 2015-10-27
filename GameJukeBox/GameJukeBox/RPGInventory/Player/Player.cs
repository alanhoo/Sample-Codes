using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJukeBox.RPGInventory.Items;
using GameJukeBox.RPGInventory.Shops;

namespace GameJukeBox.RPGInventory.Player
{
    public abstract class Player
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public Items.Containers.Container Bag;

        public Player(int lifeSaving)
        {
            Money = lifeSaving;
        }

        public void ShowBagType()
        {
            Console.WriteLine("{0} is using {1} to contain items.", Name, Bag.Name);
        }

        public void ShowMoney()
        {
            Console.WriteLine("{0} has {1} dollars to spend.", Name, Money);
        }

        public void ListItemInBag()
        {
            if (Bag.ItemCount == 0)
            {
                Console.WriteLine("There is no item in his bag");
            }
            else
            {
                Bag.DisplayContents();
            }
        }

        public bool BuyItem(Item item, Shop shop)
        {
            if (item.Value > Money)
            {
                Console.WriteLine("You don't have enough money.");
                return false;
            }

            if (shop.SellItem(item))
            {
                Money -= item.Value;
                Bag.AddItem(item);
            }
            return true;
        }

        public bool SellItem(Item item, Shop shop)
        {
            if (!Bag.HasItem(item))
            {
                Console.WriteLine("{0} doesn't have {1} in his bag.", Name, item.Name);
                return false;
            }

            int moneyfromSale = shop.BuyUsedfromPlayer(item);

            if (moneyfromSale != 0)
            {
                Bag.RemoveItem();
                Money += moneyfromSale;
            }
            Console.WriteLine("{0} sells his {1} to get {2} dollars", Name, item.Name, moneyfromSale);
            return true;
        }
    }
}
