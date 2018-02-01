using System;
using System.Collections.Generic;
using System.Text;

namespace Dark_Chambers
{
    class Weapon
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Damage { get; set; }
        public int Crit { get; set; }

        public State State { get; set; }

        public Weapon(string t, double d, int c, State s, int l)
        {
            Type = t;

            //Damage = multiplier * player level
            Damage = (int)Math.Ceiling(d * l);

            Crit = c;

            State = s;
        }
    }

    class Weapons
    {
        static Random r = new Random();

        public List<Weapon> list = new List<Weapon>();

        public Weapons(int l, State s)
        {
            list = new List<Weapon>()
            {
                new Weapon("Sword", 1.2, r.Next(40, 61), s, l),
                new Weapon("Axe", 1.8, r.Next(20, 41), s, l),
                new Weapon("Dagger", 0.6, r.Next(60, 81), s, l)
            };
        }
    }

    class State
    {
        public string Prefix { get; set; }
        public int DMG { get; set; }
        public int CRIT { get; set; }

        public State(string p, int d, int c)
        {
            Prefix = p;
            DMG = d;
            CRIT = c;
        }
    }

    class States
    {
        public List<State> list = new List<State>() {
            new State("Broken", 0, -10),
            new State("Rusty", -10, 0),
            new State("Regular", 0, 0),
            new State("Sharpened", 10, 0),
            new State("Shiny", 0, 10)
        };   
    }


}
