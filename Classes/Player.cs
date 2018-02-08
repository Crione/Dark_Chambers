using System;
using System.Collections.Generic;
using System.Text;

namespace Dark_Chambers
{
    class Player
    {
        static Function f = new Function();

        //used variables
        public string Name { get; set; }
        public int Level = 1;

        public int MaxHP = 20;
        public int HP = 20;
        public int MaxEXP = 10;
        public int EXP = 0;

        public Weapon Weapon = new Weapon("Fist", 1, 50, f.GetState(""), 1);
        public Bag Bag = new Bag();
    }

    class Bag
    {
        public Item Potion { get; set; }
        public Item Key { get; set; }

        public Bag()
        {
            Potion = new Item("Potion", 2);
            Key = new Item("Key", 1);
        }
    }
}
