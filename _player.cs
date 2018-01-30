using System;
using System.Collections.Generic;
using System.Text;

namespace Dark_Chambers
{
    class Player
    {
        //used variables
        public string Name { get; set; }
        public int LVL = 1;
        public int MaxHP = 20;
        public int HP = 20;
        public int MaxXP = 100;
        public int XP = 0;

        public Weapon WPN = new Fist();

        //unused variables
        public int Coins { get; set; }
        public Bag Bag { get; set; }
    }

    class Bag
    {

    }
}
