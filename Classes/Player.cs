using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Dark_Chambers
{
    class Player
    {
        static Items items = new Items(1);
        static Function f = new Function();

        //used variables
        public string Name { get; set; }
        public int Level = 1;

        public int MaxHP = 20;
        public int HP = 20;
        public int MaxEXP = 10;
        public int EXP = 0;

        public Weapon Weapon = new Weapon("Fist", 1, 50, f.GetState(""), 1);
        public List<Item> Bag = new List<Item>()
        {
                items.list.Single(i => i.Type == "Key"),
                items.list.Single(i => i.Type == "Potion"),
        };
    }
}
