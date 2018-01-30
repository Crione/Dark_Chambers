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
        public int MaxHP { get; set; }
        public int DMG { get; set; }
        public int XP { get; set; }

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
            HP = (int)Math.Ceiling(1.8 * l);
            MaxHP = HP;
            DMG = (int)Math.Ceiling(0.7 * l);
            XP = (int)(2.29378 * l);

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
            HP = (int)Math.Ceiling(1.3 * l);
            MaxHP = HP;
            DMG = (int)Math.Ceiling(1.7 * l);
            XP = (int)(2.94734 * l);

            //unused
            DEF = 1;
        }
    }
}
