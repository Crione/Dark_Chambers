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

        public Weapon Weapon = new Weapon("Fist", 1, 50, f.GetState("", 0, 0), 1);
        public Bag Bag = new Bag();
    }

    class Bag
    {
        public int Potions { get; set; }
        public int Keys { get; set; }
        public int Coins { get; set; }

        public Bag()
        {
            Coins = 0;
            Potions = 0;
            Keys = 1;
        }
    }
}
