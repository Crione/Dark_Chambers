using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Dark_Chambers
{
    class Function
    {
        static int Percentage;
        static Random r = new Random();

        public Weapon GetWeapon(string type, Player p, string state = null)
        {
            if (state == null)
            {
                Percentage = r.Next(1, 101);
                if(Percentage <= 15)
                {
                    state = "Broken";
                }
                else if(Percentage > 15 && Percentage <= 30)
                {
                    state = "Rusty";
                }
                else if(Percentage > 30 && Percentage <= 70)
                {
                    state = "Regular";
                }
                else if(Percentage > 70 && Percentage <= 85)
                {
                    state = "Sharpened";
                }
                else if(Percentage > 85 && Percentage <= 100)
                {
                    state = "Shiny";
                }
                else
                {
                    state = "Regular";
                }
            }
            state = state + " ";
            State s = GetState(state);

            Weapons weapons = new Weapons(p, s);
            Weapon w = weapons.list.Single(c => c.Type == type);
            return w;
        }

        public Enemy GetEnemy(string type, Player p)
        {
            Enemies enemies = new Enemies(p);
            Enemy w = enemies.list.Single(c => c.Type == type);
            return w;
        }

        public State GetState(string prefix)
        {
            States states = new States();
            State s = states.list.Single(c => c.Prefix == prefix);
            return s;
        }

        public Chest GetChest(string type, Player p)
        {
            Chests chests = new Chests(p);
            Chest s = chests.list.Single(c => c.Type == type);
            return s;
        }

        public Item GetItem(string type, int l)
        {
            Items items = new Items(l);
            Item i = items.list.Single(c => c.Type == type);
            return i;
        }
    }
}
