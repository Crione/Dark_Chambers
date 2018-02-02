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

        public Weapon GetWeapon(string type, Player p)
        {
            //get weapon state
            States states = new States();
            string State = "Regular";

            Percentage = r.Next(0, 101);
            if (Percentage <= 15)
            {
                //Broken state (-10% Crit), 15%
                State = "Broken";
            }
            else if (Percentage > 15 && Percentage <= 30)
            {
                //Rusty state (-10% Damage), 15%
                State = "Rusty";
            }
            else if (Percentage > 30 && Percentage <= 70)
            {
                //Regular state, 40%
                State = "Regular";
            }
            else if (Percentage > 70 && Percentage <= 85)
            {
                //Sharpened state (+10% Damage), 15%
                State = "Sharpened";
            }
            else if (Percentage > 85 && Percentage <= 100)
            {
                //Shiny state (+10% Crit), 15%
                State = "Shiny";
            }
            State = State + " ";
            State s = states.list.Single(c => c.Prefix == State);

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

        public State GetState(string prefix, int damage, int crit)
        {
            State state = new State(prefix, damage, crit);
            return state;
        }
    }
}
