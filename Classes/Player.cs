using System;
using System.Collections.Generic;
using System.Text;

namespace Dark_Chambers
{
    class Player
    {
        //used variables
        public string Name { get; set; }
        public int Level = 1;
        public int MaxHP = 20;
        public int HP = 20;
        public int MaxEXP = 10;
        public int EXP = 0;
        public Weapon WPN = new Weapon("Fist", 1, 50, null, 1);
        

        //unused variables
        public int Coins { get; set; }
        public Bag Bag { get; set; }
    }

    class Bag
    {

    }
}
