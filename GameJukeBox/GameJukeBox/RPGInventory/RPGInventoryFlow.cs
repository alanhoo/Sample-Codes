using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJukeBox.RPGInventory.Player;
using GameJukeBox.RPGInventory.Items;
using GameJukeBox.RPGInventory.Shops;

namespace GameJukeBox.RPGInventory
{
    public class RPGInventoryFlow
    {
        public void Execute()
        {
            Console.WriteLine("Create two players in different classes.");

            Bum Bum = new Bum();
            Elite Elite = new Elite();

            Bum.ShowMoney();
            Elite.ShowMoney();

            Console.ReadLine();
            Console.WriteLine("Now both players go shopping.");
            Console.WriteLine("First they walk into the nice town shop.");

            TownShop TownShop = new TownShop();

            Console.WriteLine("Let's see what the town shop has to offer:");

            List<Item> StockList;

            TownShop.ShowInventoryMenu();
            StockList = TownShop.SendTheMenu();

            Console.WriteLine("");
            Console.WriteLine("Let's use the Bum try buy an item.");

            Item ItemToBeBought = StockList[0];
            Bum.ShowMoney();
            Bum.ShowBagType();
            if (Bum.BuyItem(ItemToBeBought, TownShop))
            {
                Console.WriteLine("{0} just bought {1} from {2}.", Bum.Name, ItemToBeBought.Name, TownShop.name);
            }
            else
            {
                Console.WriteLine("{0} has no money to buy {1} from {2}", Bum.Name, ItemToBeBought.Name, TownShop.name);
            }

            Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Let's use Elite buy an item.");

            Elite.ShowMoney();
            Elite.ShowBagType();
            ItemToBeBought = StockList[0];

            if (Elite.BuyItem(ItemToBeBought, TownShop))
            {
                Console.WriteLine("{0} just bought {1} from {2}.", Elite.Name, ItemToBeBought.Name, TownShop.name);
            }
            else
            {
                Console.WriteLine("{0} has no money to buy {1} from {2}", Elite.Name, ItemToBeBought.Name, TownShop.name);
            }

            Console.ReadLine();
            Elite.Bag.DisplayContents();
            Item ItemToSell = ItemToBeBought;

            Console.WriteLine("Now {0} is going to pawn his {1}.", Elite.Name, ItemToSell);

            PawnShop PawnShop = new PawnShop();

            Elite.SellItem(ItemToSell, PawnShop);

            Console.WriteLine("Let's check out {0}'s bag", Elite.Name);
            Elite.ListItemInBag();

            Console.ReadLine();
        }
    }
}
