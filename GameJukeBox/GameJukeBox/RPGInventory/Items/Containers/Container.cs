using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJukeBox.RPGInventory.Items.Containers
{
    public abstract class Container : Item
    {
        protected int _capacity;
        protected int _currentIndex;
        protected Item[] _itemsInContainer;

        public Container(int capacity)
        {
            _capacity = capacity;
            _itemsInContainer = new Item[capacity];
            _currentIndex = 0;
        }

        public int ItemCount { get { return _currentIndex; } }

        public bool HasItem(Item item)
        {
            return _itemsInContainer.Contains(item);
        }

        public virtual void AddItem(Item item)
        {
            _itemsInContainer[_currentIndex] = item;
            _currentIndex++;
        }

        public virtual Item RemoveItem()
        {
            _currentIndex--;

            Item itemToReturn = _itemsInContainer[_currentIndex];

            _itemsInContainer[_currentIndex] = null;

            return itemToReturn;
        }

        public virtual void DisplayContents()
        {
            Console.WriteLine("Items in Bag:");
            foreach (Item item in _itemsInContainer)
            {
                if (item != null)
                {
                    Console.WriteLine("{0} - {1}", item.Name, item.Description);
                }
            }
        }
    }
}
