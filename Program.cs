using System;
using System.Collections.Generic;
using System.Linq;

namespace Dark_Chambers
{
    class Program
    {
        //Game variables
        static Enemy e { get; set; }
        static Player p = new Player();
        static Function f = new Function();
        static Random r = new Random();

        static bool Game = true;
        static bool Active { get; set; }
        static string Input { get; set; }
        static int Percentage { get; set; }

        //Function methods
        static void Write(string Invoer, ConsoleColor Color = ConsoleColor.White, bool Sleep = true ,bool WriteLine = true)
        {
            Console.ForegroundColor = Color;
            if (Sleep == true)
            {
                char[] text = Invoer.ToCharArray();
                int Lenght = text.Length;
                for (int i = 0; i <= (Lenght - 1); i++)
                {
                    Console.Write(text[i]);
                    System.Threading.Thread.Sleep(20);
                }
            }
            else
            {
                Console.Write(Invoer);
            }
            if(WriteLine == true)
            {
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Read(string Query = "")
        {
            if(Query != "")
            {
                Write(Query);
                bool Break = false;
                while (Break == false)
                {
                    Write("(Enter 'yes' or 'no')", ConsoleColor.DarkGray, false);
                    Input = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    switch (Input)
                    {
                        case "yes":
                        case "y":
                            Input = "yes";
                            Break = true;
                            break;
                        case "no":
                        case "n":
                            Input = "no";
                            Break = true;
                            break;
                        default:
                            Break = false;
                            break;
                    }
                }
            }
            else
            {
                Input = Console.ReadLine().ToLower();
                Console.WriteLine();
            }
        }

        static void Command(string Input)
        {
            while(Input != "")
            {
                switch (Input)
                {
                    case "stats":
                        WeaponStats(p.Weapon);
                        break;
                }
                Input = Console.ReadLine();
            }
        }

        static void WeaponStats(Weapon w)
        {
            string Weapon = w.State.Prefix + w.Type;
            int Length = (int)Math.Ceiling((double)(20 - Weapon.Length) / 2);

            Console.Write("0");
            for(int i = 0; i < Length; i++)
            {
                Console.Write("-");
            }
            Console.Write(Weapon);
            Length = 20 - (Length + Weapon.Length); 
            for (int i = 0; i < Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("0");

            Length = 20 - ("DMG" + w.Damage).Length;
            Console.Write("|DMG");
            for (int i = 0; i < Length; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(w.Damage + "|");

            Length = 20 - ("CRIT" + w.Crit).Length;
            Console.Write("|CRIT");
            for (int i = 0; i < Length; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(w.Crit + "|");

            Console.WriteLine("0--------------------0");
        }

        //Game
        static void Main(string[] args)
        {
            StartGame();
        }

        static void StartGame()
        {          
            while(Game == true)
            {
                Percentage = r.Next(0, 101);
                if (Percentage <= 80)
                {
                    string enemy = "Rat";
                    Percentage = r.Next(0, 101);
                    if (Percentage <= 50)
                    {
                        enemy = "Rat";
                    }
                    else if (Percentage > 50 && Percentage <= 100)
                    {
                        enemy = "Spider";
                    }
                    Battle(f.GetEnemy(enemy, p));
                }
                else if (Percentage > 80 && Percentage <= 100)
                {
                    Chest();
                }
            }
            Write("You died!");           
        }

        static void Battle(Enemy e)
        {
            Read("A " + e.Type + " attacks! Fight back?");
            switch (Input)
            {
                case "yes":
                    Active = true;
                    while(Active == true)
                    {
                        Write("What do you want to do?");
                        bool Break = false;
                        while (Break == false)
                        {
                            Write("(Enter 'attack' or 'flee')", ConsoleColor.DarkGray, false);
                            Input = Console.ReadLine();
                            Console.WriteLine();
                            switch (Input)
                            {
                                case "attack":
                                case "a":
                                    Attack(e);
                                    Break = true;
                                    break;
                                case "flee":
                                case "f":
                                    Flee();
                                    Active = false;
                                    Break = true;
                                    break;
                                default:
                                    Break = false;
                                    break;
                            }
                        }
                    }
                    break;
                case "no":
                    Flee();
                    break;
            }
        }

        static void Attack(Enemy e)
        {
            //player attacks
            Percentage = r.Next(0, 101);
            if(Percentage <= p.Weapon.Crit)
            {
                int Crit = (int)Math.Ceiling(p.Weapon.Damage * 1.5);
                Write("Critical hit!");
                Write("You attack the " + e.Type + " for " + Crit + " damage.");
                e.HP = e.HP - Crit;
            }
            else
            {
                Write("You attack the " + e.Type + " for " + p.Weapon.Damage + " damage.");
                e.HP = e.HP - p.Weapon.Damage;
            }

            Write(e.Type, ConsoleColor.White, false, false);
            Write("[" + e.HP + "/" + e.MaxHP + "]", ConsoleColor.DarkRed, false);
            Console.WriteLine();
            if(e.HP <= 0)
            {
                //the enemy died
                Write("The " + e.Type + " died!");

                p.EXP = p.EXP + e.EXP;
                Write("You gained " + e.EXP + " EXP points.");
                if(p.EXP >= p.MaxEXP)
                {
                    //the player levels up
                    LevelUp();
                }
                Write("[EXP " + p.EXP + "/" + p.MaxEXP + "]", ConsoleColor.DarkGray);
                Active = false;
                Console.WriteLine();
                return;
            }

            //enemy attacks
            Write("The " + e.Type + " attacks you for " + e.Damage + " damage.");
            p.HP = p.HP - e.Damage;
            CheckHP();
            Console.WriteLine();
        }
        
        static void Flee()
        {
            //player flees
            Percentage = r.Next(0, 101);
            if (Percentage <= 80)
            {
                Write("You run in another direction.");
            }
            else if (Percentage > 80 && Percentage <= 100)
            {
                int Damage = (int)Math.Ceiling(e.Damage * 0.5);
                p.HP = p.HP - Damage;
                Write("The " + e.Type + " attacks you for " + Damage + " damage.");
                CheckHP();
            }
            Console.WriteLine();
        }

        static void CheckHP()
        {
            Write("[HP " + p.HP + "/" + p.MaxHP + "]", ConsoleColor.DarkRed, false);
            if (p.HP <= 0)
            {
                Game = false;
                Active = false;
            }
        }

        static void LevelUp()
        {
            Console.WriteLine();
            Write("You leveled up!");
            p.Level = p.Level + 1;
            Write("[LVL " + p.Level + "]");

            Console.WriteLine();
            Write("HP increased by 4 points.");
            p.MaxHP = p.MaxHP + 4;
            p.HP = p.HP + 4;
            Write("[HP " + p.HP + "/" + p.MaxHP + "]", ConsoleColor.DarkRed, false);

            p.EXP = p.EXP - p.MaxEXP;
            p.MaxEXP = (int)Math.Ceiling(p.MaxEXP * 1.5);
        }

        static void Chest()
        {
            Read("You found a chest! Do you want to open it?");
            switch (Input)
            {
                case "yes":
                    Write("You open the chest...");
                    Percentage = r.Next(0, 101);
                    if(Percentage <= 80)
                    {                     
                        string[] Weapons = new string[] {"Sword", "Axe", "Dagger"};
                        Weapon w = f.GetWeapon(Weapons[(r.Next(0, Weapons.Length)) - 1], p);

                        Write("There is a " + w.State.Prefix + w.Type + " inside!");
                        Console.WriteLine();
                        WeaponStats(w);
                        Console.WriteLine();
                        Read("Do you want to take it with you?");
                        switch (Input)
                        {
                            case "yes":
                                Write("You take the " + w.State.Prefix + w.Type + ".");
                                p.Weapon = w;
                                break;
                            case "no":
                                Write("You leave the " + w.State.Prefix + w.Type + ".");
                                break;
                        }
                    }
                    else if(Percentage > 80 && Percentage <= 100)
                    {
                        Battle(f.GetEnemy("Mimic", p));
                    }
                    break;
                case "no":
                    Write("You continue your journey.");
                    break;
            }
        }
    }
}
