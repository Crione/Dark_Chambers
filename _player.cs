using System;
using System.Collections.Generic;
using System.Text;

namespace Dark_Chambers
{
    class Player
    {
        //used variables
        public string name { get; set; }
        public int MaxHP = 5;
        public int HP = 5;
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
