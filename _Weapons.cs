using System;
using System.Collections.Generic;
using System.Text;

namespace Dark_Chambers
{
    class Weapon
    {
        //used variables
        public string Type { get; set; }
        public int DMG { get; set; }
        public int CRIT { get; set; }

        //unused variables
        public State State { get; set; }
        public Enchant Enchant { get; set; }
    }

    class Fist : Weapon
    {
        public string Type = "Fist";
        public int DMG = 1;
        public int CRIT = 50;
    }

    class Sword : Weapon
    {

    }

    class Axe : Weapon
    {

    }

    class Dagger : Weapon
    {

    }

    //unused classes
    class Enchant
    {

    }

    class State
    {

    }
}
