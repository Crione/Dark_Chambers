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
        public ConsoleColor Color { get; set; }


        public Item(string t, int a, ConsoleColor c = ConsoleColor.White)
        {
            Type = t;
            Amount = a;
            Color = c;
        }
    }

    class Potion : Item
    {
        public int Heal { get; set; }

        public Potion(string t, int a, int h, ConsoleColor c = ConsoleColor.White) : base(t, a, c)
        {
            Heal = h;
        }
    }

    class Items
    {
        static Random r = new Random();

        public List<Item> list = new List<Item>();

        public Items(int l)
        {
            /*      Item Generation:
             *      (t, a)
             *      t = type
             *      a = amount dropped
             */
            list = new List<Item>()
            {
                new Item("Key", r.Next(1, ((int)Math.Ceiling(l * 0.2) + 1)), ConsoleColor.DarkGray),
                new Potion("Potion", r.Next(1, ((int) Math.Ceiling(l* 0.3) + 1)), 4, ConsoleColor.DarkMagenta),
            };
        }
    }
}
