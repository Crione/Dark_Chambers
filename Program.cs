using System;
using System.Collections.Generic;
using System.Linq;

namespace Dark_Chambers
{
    class Program
    {
        //Game variables
        static Enemy e = new Enemy();
        static Player p = new Player();
        

        static Random r = new Random();
        static bool Game = true;

        static bool Active { get; set; }
        static string Invoer { get; set; }
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
                    Invoer = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    switch (Invoer)
                    {
                        case "yes":
                        case "y":
                            Invoer = "yes";
                            Break = true;
                            break;
                        case "no":
                        case "n":
                            Invoer = "no";
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
                Invoer = Console.ReadLine();
                Console.WriteLine();
            }
        }

        static void CheckHP()
        {
            Write("[HP " + p.HP + "/" + p.MaxHP + "]", ConsoleColor.DarkRed, false);
            if(p.HP <= 0)
            {
                Game = false;
                Active = false;
            }
        }

        //Game
        static void Main(string[] args)
        {
            StartGame();
        }

        static void StartGame()
        {          
            /*
            Write("Please enter your name:", ConsoleColor.White);
            Read();
            p.Name = Invoer;
            Read("Are you ready to enter the chambers?");
            */

            while(Game == true)
            {
                Event();
            }
            Write("You died!");           
        }

        static void Event()
        {
            Percentage = r.Next(0, 101);
            if(Percentage <= 80)
            {
                int eLVL = r.Next((p.LVL - 3), (p.LVL + 2));
                if(eLVL <= 0)
                {
                    eLVL = 1;
                }
                Percentage = r.Next(0, 101);
                if (Percentage <= 50)
                {
                    e = new Rat(eLVL);
                }else if(Percentage > 50 && Percentage <= 100)
                {
                    e = new Spider(eLVL);
                }
                Battle(e);
            }
            else if(Percentage > 80 && Percentage <= 100)
            {
                Console.WriteLine("Chest");
            }
            Console.ReadLine();
        }

        static void Battle(Enemy e)
        {
            Read("A " + e.Type + " attacks! Fight back?");
            switch (Invoer)
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
                            Invoer = Console.ReadLine();
                            Console.WriteLine();
                            switch (Invoer)
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
            if(Percentage <= p.WPN.CRIT)
            {
                int Crit = (int)Math.Ceiling(p.WPN.DMG * 1.5);
                Write("Critical hit!");
                Write("You attack the " + e.Type + " for " + Crit + " damage.");
                e.HP = e.HP - Crit;
            }
            else
            {
                Write("You attack the " + e.Type + " for " + p.WPN.DMG + " damage.");
                e.HP = e.HP - p.WPN.DMG;
            }

            Write(e.Type, ConsoleColor.White, false, false);
            Write("[" + e.HP + "/" + e.MaxHP + "]", ConsoleColor.DarkRed, false);
            Console.WriteLine();
            if(e.HP <= 0)
            {
                Write("The " + e.Type + " died!");

                p.XP = p.XP + e.XP;
                Write("You gained " + e.XP + " EXP points.");
                if(p.XP >= p.MaxXP)
                {
                    LevelUp();
                }
                Write("[EXP " + p.XP + "/" + p.MaxXP + "]", ConsoleColor.DarkGray);
                Active = false;
                return;
            }

            //enemy attacks
            Write("The " + e.Type + " attacks you for " + e.DMG + " damage.");
            p.HP = p.HP - e.DMG;
            CheckHP();
            Console.WriteLine();
        }
        
        static void Flee()
        {
            Percentage = r.Next(0, 101);
            if (Percentage <= 80)
            {
                Write("You run in another direction.");
            }
            else if (Percentage > 80 && Percentage <= 100)
            {
                int Damage = (int)Math.Ceiling(e.DMG * 0.5);
                p.HP = p.HP - Damage;
                Write("The " + e.Type + " attacks you for " + Damage + " damage.");
                CheckHP();
            }
        }

        static void LevelUp()
        {
            Console.WriteLine();
            Write("You leveled up!");
            p.LVL = p.LVL + 1;
            Write("[LVL " + p.LVL + "]");

            Console.WriteLine();
            Write("HP increased by 4 points.");
            p.MaxHP = p.MaxHP + 4;
            p.HP = p.HP + 4;
            Write("[HP " + p.HP + "/" + p.MaxHP + "]", ConsoleColor.DarkRed, false);

            p.XP = p.XP - p.MaxXP;
            p.MaxXP = (int)Math.Ceiling(p.MaxXP * 1.5);
        }

        static Weapon GetWeapon(string type, int l)
        {
            Weapons weapons = new Weapons(l);
            Weapon w = weapons.list.Single(c => c.Type == type);
            return w;
        }
    }
}
