using System;
using System.Collections.Generic;
using System.Text;

namespace Dark_Chambers
{
    class Enemy
    {
        //used variables
        public int LVL { get; set; }
        public int HP { get; set; }
        public int DMG { get; set; }

        //unused variables
        public int DEF { get; set; }
        public int Coins { get; set; }
    }

    class Rat : Enemy
    {
        public int HP = 2;
        public int DMG = 1;

        //unused
        public int DEF = 1;
    }

    class Spider : Enemy
    {
        public int HP = 1;
        public int DMG = 2;

        //unused
        public int DEF = 1;
    }
}
