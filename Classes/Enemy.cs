using System;
using System.Collections.Generic;
using System.Text;

namespace Dark_Chambers
{ 
    class Enemy
    {
        protected Random r = new Random();

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
            //values
            double _HP = 2.2;      
            double _DMG = 1.3;

            Type = "Rat";
            LVL = l;
            HP = (int)Math.Ceiling(_HP * l);
            MaxHP = HP;
            DMG = (int)Math.Ceiling(_DMG * l);
            XP = (int)(2.29378 * l);
        }
    }

    class Spider : Enemy
    {
        public Spider(int l)
        {
            //values
            double _HP = 1.3;
            double _DMG = 1.7;

            Type = "Spider";
            LVL = l;
            HP = (int)Math.Ceiling(_HP * l);
            MaxHP = HP;
            DMG = (int)Math.Ceiling(_DMG * l);
            XP = (int)(2.94734 * l);
        }
    }
}
