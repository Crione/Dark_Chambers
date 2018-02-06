using System;
using System.Collections.Generic;
using System.Text;

namespace Dark_Chambers
{
    class Item
    {
        static Random r = new Random();

        public string Type { get; set; }
        public int Amount { get; set; }

        public Item(string t, int a)
        {
            Type = t;
            Amount = a;
        }
    }

    class Items
    {
        static Random r = new Random();

        public List<Item> list = new List<Item>();

        public Items(int l)
        {
            /*      Weapon Generation:
             *      
             */
            list = new List<Item>()
            {
                new Item("Potion", r.Next(1, ((int)Math.Ceiling(l * 0.3) + 1))),
                new Item("Key", r.Next(1, ((int)Math.Ceiling(l * 0.2) + 1))),
                new Item("Coin", r.Next((int)Math.Ceiling(l * 0.8), (int)Math.Ceiling(l * 1.4) + 1)),
            };
        }
    }
}
