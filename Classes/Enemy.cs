﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dark_Chambers
{ 
    class Enemy
    {
        static int Percentage { get; set; }
        static Random r = new Random();
        static Function f = new Function();

        //used variables
        public string Type { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int Damage { get; set; }
        public int EXP { get; set; }

        public Item Loot = null;

        //unused variables
        public int Defence { get; set; }

        public Enemy(string t, double h, double d, int l, Player p)
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

            Percentage = r.Next(1, 101);
            if(Percentage <= l)
            {
                string loot = "Potion";
                Percentage = r.Next(1, 101);
                if (Percentage <= 50)
                {
                    loot = "Coin";
                }
                else if (Percentage > 50 && Percentage <= 80)
                {
                    loot = "Potion";
                }
                else if (Percentage > 80 && Percentage <= 100)
                {
                    loot = "Key";
                }
                Loot = f.GetItem(loot, Level);
            }
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
                new Enemy("Rat", 1.7, 0.8, 10, p),          //2.5
                new Enemy("Spider", 0.8, 1.2, 10, p),       //2.5
                new Enemy("Mimic", 1.1, 1.9, 100, p),       //3.0
                new Enemy("Skeleton", 2.1, 1.4, 40, p),     //3.5
                new Enemy("Kobold", 0.9, 2.6, 40, p),       //3.5
                new Enemy("Orc", 1.9, 2.1, 50, p),          //4.0
            };
        }
    }
}
