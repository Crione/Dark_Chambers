using System;
using System.Collections.Generic;
using System.Text;

namespace Dark_Chambers
{ 
    class Enemy
    {
        static int Percentage { get; set; }
        static Random r = new Random();

        //used variables
        public string Type { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int Damage { get; set; }
        public int EXP { get; set; }

        //unused variables
        public int Defence { get; set; }
        public int Coins { get; set; }
        public Item Item { get; set; }

        public Enemy(string t, double h, double d, Player p)
        {
            Type = t;

            Level = r.Next((p.Level - 3), (p.Level + 2));
            if(Level < 1)
            {
                Level = 1;
            }

            //HP = multiplier * enemy level
            HP = (int)Math.Ceiling(h * Level);
            MaxHP = HP;

            //Damage = multiplier * enemy level
            Damage = (int)Math.Ceiling(d * Level);
            
            //EXP = multiplier * average of health and damage
            EXP = (int)Math.Ceiling(1.34 * ((MaxHP + Damage) / 2));
        }
    }

    class Enemies
    {
        static Random r = new Random();

        public List<Enemy> list { get; set; }

        public Enemies(Player p)
        {
            /*      Enemy Generation:
             *      (t, h, d, p)
             *      t = type
             *      h = hp
             *      d = damage
             *      p = player
             */
            list = new List<Enemy>()
            {
                new Enemy("Rat", 2.2, 1.3, p),
                new Enemy("Spider", 1.3, 1.7, p),
                new Enemy("Mimic", 1.6, 2.4, p)
            };
        }
    }
}
