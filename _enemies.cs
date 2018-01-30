using System;
using System.Collections.Generic;
using System.Text;

namespace Dark_Chambers
{
    class Enemy
    {
        //used variables
        public string Type { get; set; }
        public int LVL { get; set; }
        public int HP { get; set; }
        public int DMG { get; set; }

        //unused variables
        public int DEF { get; set; }
        public int Coins { get; set; }
    }

    class Rat : Enemy
    {
        public Rat(int l)
        {
            Type = "Rat";
            LVL = l;
            HP = (int)(2.3 * l);
            DMG = (int)(1.2 * l);

            //unused
            DEF = 1;
        }
    }

    class Spider : Enemy
    {
        public Spider(int l)
        {
            Type = "Spider";
            LVL = l;
            HP = (int)(1.3 * l);
            DMG = (int)(2.2 * l);

            //unused
            DEF = 1;
        }
    }
}
