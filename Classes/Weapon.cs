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
            State = s;
            Name = s.Prefix + t;

            //Damage = (multiplier * player level) + state boost
            Damage = (int)Math.Ceiling((d * l) + ((d * l) / 100) * s.Damage);

            //Crit = crit chance + state boost
            Crit = (c) + s.Crit;
        }
    }

    class Weapons
    {
        static Random r = new Random();

        public List<Weapon> list = new List<Weapon>();

        public Weapons(Player p, State s)
        {
            /*      Weapon Generation:
             *      (t, d, c, s, l)
             *      t = type
             *      d = damage
             *      c = crit
             *      s = state
             *      l = player level
             */
            list = new List<Weapon>()
            {
                new Weapon("Sword", 1.1, r.Next(40, 61), s, p.Level),
                new Weapon("Axe", 1.4, r.Next(20, 41), s, p.Level),
                new Weapon("Dagger", 0.8, r.Next(60, 81), s, p.Level),
                new Weapon("Mace", 1.6, r.Next(30, 61), s, p.Level)
            };
        }
    }

    class State
    {
        public string Prefix { get; set; }
        public int Damage { get; set; }
        public int Crit { get; set; }

        public State(string p, int d, int c)
        {
            Prefix = p;
            Damage = d;
            Crit = c;
        }
    }

    class States
    {
            /*      State Generation:
             *      (p, d, c)
             *      p = prefix
             *      d = damage boost (%)
             *      c = crit boost (%)
             */
        public List<State> list = new List<State>() {
            new State("", 0, 0),
            new State("Broken ", 0, -10),
            new State("Rusty ", -20, 0),
            new State("Regular ", 0, 0),
            new State("Sharpened ", 20, 0),
            new State("Shiny ", 0, 10),
            new State("Starforged ", 40, 20)
        };   
    }


}
