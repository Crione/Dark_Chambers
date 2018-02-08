using System;
using System.Collections.Generic;
using System.Text;

namespace Dark_Chambers
{
    class Chest
    {
        static int Percentage;
        static Random r = new Random();
        static Function f = new Function();
        
        public string Type { get; set; }
        public bool Locked { get; set; }

        public Item Loot = null;
        public Weapon Weapon = null;

        public Chest(string t, bool k, bool l, Player p)
        {
            Type = t;

            Locked = k;

            if (l)
            {
                string loot = "Potion";
                Percentage = r.Next(1, 101);
                if(Percentage <= 80)
                {
                    loot = "Potion";   
                }
                else if(Percentage > 80 && Percentage <= 100)
                {
                    loot = "Key";
                }
                Loot = f.GetItem(loot, p.Level);
            }
            else
            {
                string weapon = "Sword";
                Percentage = r.Next(1, 101);
                if (Percentage <= 30)
                {
                    weapon = "Sword";
                }
                else if (Percentage > 30 && Percentage <= 60)
                {
                    weapon = "Dagger";
                }
                else if (Percentage > 60 && Percentage <= 90)
                {
                    weapon = "Axe";
                }
                else if (Percentage > 90 && Percentage <= 100)
                {
                    weapon = "Mace";
                }

                if (k)
                {
                    string state = "Regular";
                    Percentage = r.Next(1, 101);
                    if (Percentage <= 45)
                    {
                        state = "Sharpened";
                    }
                    else if (Percentage > 45 && Percentage <= 90)
                    {
                        state = "Shiny";
                    }
                    else if (Percentage > 90 && Percentage <= 100)
                    {
                        state = "Starforged";
                    }
                    Weapon = f.GetWeapon(weapon, p, state);
                }
                else
                {
                    Weapon = f.GetWeapon(weapon, p);
                }
            }
        }
    }

    class Chests
    {
        public List<Chest> list = new List<Chest>();

        public Chests(Player p)
        {
            /*      Chest Generation:
             *      
             */
            list = new List<Chest>()
            {
                new Chest("Regular Chest", false, false, p),
                new Chest("Locked Chest", true, false, p),
                new Chest("Lootbag", false, true, p)
            };
        }

    }
}
