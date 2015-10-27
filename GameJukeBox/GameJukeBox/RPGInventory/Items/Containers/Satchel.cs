using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.RPGInventory.Items.Containers
{
    public class Satchel : Container
    {
        public Satchel() : base(4)
        {
            Name = "A small cloth satchel";
            Description = "This can carry your knick-knacks.";
            Weight = 1;
            Value = 50;
        }

        public override void AddItem(Item item)
        {
            if (item.Weight > 2)
            {
                Console.WriteLine("That is way to big for the satchel!");
            }
            else
            {
                base.AddItem(item);
            }

        }
    }
}
