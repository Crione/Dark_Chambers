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
                Input = Console.ReadLine();
                Console.WriteLine();
            }
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
                    Percentage = r.Next(0, 101);
                    if (Percentage <= 50)
                    {
                        e = GetEnemy("Rat", p.Level);
                    }
                    else if (Percentage > 50 && Percentage <= 100)
                    {
                        e = GetEnemy("Spider", p.Level);
                    }
                    Battle(e);
                }
                else if (Percentage > 80 && Percentage <= 100)
                {
                    Console.WriteLine("Chest");
                }
                Console.ReadLine();
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
            if(Percentage <= p.WPN.Crit)
            {
                int Crit = (int)Math.Ceiling(p.WPN.Damage * 1.5);
                Write("Critical hit!");
                Write("You attack the " + e.Type + " for " + Crit + " damage.");
                e.HP = e.HP - Crit;
            }
            else
            {
                Write("You attack the " + e.Type + " for " + p.WPN.Damage + " damage.");
                e.HP = e.HP - p.WPN.Damage;
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
        }

        static void CheckHP()
        {
            Write("[HP " + p.HP + "/" + p.MaxHP + "]", ConsoleColor.DarkRed, false);
            if (p.HP <= 0)
            {
                Game = false;
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

        static Weapon GetWeapon(string type, int l)
        {
            //get weapon state
            States states = new States();
            string State = "Regular";

            Percentage = r.Next(0, 101);
            if(Percentage <= 15)
            {
                //Broken state (-10% Crit), 15%
                State = "Broken";
            }
            else if(Percentage > 15 && Percentage <= 30)
            {
                //Rusty state (-10% Damage), 15%
                State = "Rusty";
            }
            else if(Percentage > 30 && Percentage <= 70)
            {
                //Regular state, 40%
                State = "Regular";
            }
            else if(Percentage > 70 && Percentage <= 85)
            {
                //Sharpened state (+10% Damage), 15%
                State = "Sharpened";
            }
            else if(Percentage > 85 && Percentage <= 100)
            {
                //Shiny state (+10% Crit), 15%
                State = "Shiny";
            }
            State s = states.list.Single(c => c.Prefix == State);

            Weapons weapons = new Weapons(l, s);
            Weapon w = weapons.list.Single(c => c.Type == type);
            return w;
        }

        static Enemy GetEnemy(string type, int l)
        {
            Enemies enemies = new Enemies(l);
            Enemy w = enemies.list.Single(c => c.Type == type);
            return w;
        }
    }
}
