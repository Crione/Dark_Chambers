﻿using System;
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
        /*      Write Method:
         *      
         */
        static void Write(string input, ConsoleColor color = ConsoleColor.White, bool sleep = true ,bool writeline = true)
        {
            Console.ForegroundColor = color;
            if (sleep == true)
            {
                char[] text = input.ToCharArray();
                int Lenght = text.Length;
                for (int i = 0; i <= (Lenght - 1); i++)
                {
                    Console.Write(text[i]);
                    System.Threading.Thread.Sleep(20);
                }
            }
            else
            {
                Console.Write(input);
            }
            if(writeline == true)
            {
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        /*      Read Method:
         *      
         */
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
            while (Input != "")
            {
                Console.WriteLine();
                switch (Input)
                {
                    case "stats":
                    case "s":
                        ViewStats(p);
                        break;
                    case "bag":
                    case "b":
                        ViewBag(p.Bag);
                        break;
                    case "potion":
                    case "p":
                        UsePotion();
                        break;
                    default:
                        Console.WriteLine("Unknown Command.");
                        break;
                }
                Console.WriteLine();
                Input = Console.ReadLine();
            }
        }

        static void UsePotion()
        {
            if (p.Bag.Potion.Amount != 0)
            {
                Write("You drink a potion.");
                Write("Your health has been increased by 4 points!");
                p.HP = p.HP + 4;
                CheckHP();
                p.Bag.Potion.Amount = p.Bag.Potion.Amount - 1;
            }
            else
            {
                Write("You don't have any potions!");
            }
        }

        static void ViewStats(Player p)
        {
            int Length;

            string Name = p.Name + "[" + p.Level + "]";
            Length = (int)Math.Floor((double)(20 - Name.Length) / 2);
            Console.Write("0");
            for (int i = 0; i < Length; i++)
            {
                Console.Write("-");
            }
            Console.Write(Name);
            Length = 20 - (Length + Name.Length);
            for (int i = 0; i < Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("0");

            Length = 20 - ("HP" + "[" + p.HP + "/" + p.MaxHP + "]").Length;
            Console.Write("|HP");
            for (int i = 0; i < Length; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("[" + p.HP + "/" + p.MaxHP + "]" + "|");

            Length = 20 - ("EXP" + "[" + p.EXP + "/" + p.MaxEXP + "]").Length;
            Console.Write("|EXP");
            for (int i = 0; i < Length; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("[" + p.EXP + "/" + p.MaxEXP + "]" + "|");

            Console.WriteLine("0--------------------0");
        }

        static void ViewBag(Bag b)
        {
            int Length;

            Console.WriteLine("0--------Bag---------0");

            Length = 20 - ("Coins" + b.Coin.Amount).Length;
            Console.Write("|Coins");
            for (int i = 0; i < Length; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(b.Coin.Amount + "|");

            Length = 20 - ("Potions" + b.Potion.Amount).Length;
            Console.Write("|Potions");
            for (int i = 0; i < Length; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(b.Potion.Amount + "|");

            Length = 20 - ("Keys" + b.Key.Amount).Length;
            Console.Write("|Keys");
            for (int i = 0; i < Length; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(b.Key.Amount + "|");
            WeaponStats(p.Weapon);
        }

        static void WeaponStats(Weapon w)
        {
            string Weapon = w.State.Prefix + w.Type;
            int Length = (int)Math.Floor((double)(20 - Weapon.Length) / 2);

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
            Write("Enter your name:");
            p.Name = Console.ReadLine();
            Console.WriteLine();
            while(Game == true)
            {
                Percentage = r.Next(0, 101);
                if(Percentage <= 70)
                {
                    Percentage = r.Next(0, 101);
                    if(Percentage <= 30)
                    {
                        Battle(f.GetEnemy("Rat", p));
                    }
                    else if(Percentage > 30 && Percentage <= 60)
                    {
                        Battle(f.GetEnemy("Spider", p));
                    }
                    else if(Percentage > 60 && Percentage <= 75)
                    {
                        Battle(f.GetEnemy("Skeleton", p));
                    }
                    else if(Percentage > 75 && Percentage <= 90)
                    {
                        Battle(f.GetEnemy("Kobold", p));
                    }
                    else if(Percentage > 90 && Percentage <= 100)
                    {
                        Battle(f.GetEnemy("Orc", p));
                    }
                }
                else if (Percentage > 70 && Percentage <= 100)
                {
                    Percentage = r.Next(1, 101);
                    if (Percentage <= 40)
                    {
                        Chest(f.GetChest("Regular Chest", p));
                    }
                    else if (Percentage > 40 && Percentage <= 70)
                    {
                        Chest(f.GetChest("Lootbag", p));
                    }
                    else if (Percentage > 70 && Percentage <= 90)
                    {
                        Chest(f.GetChest("Locked Chest", p));
                    }
                    else if(Percentage > 90 && Percentage <= 100)
                    {
                        Chest(f.GetChest("Regular Chest", p), true);
                    }

                }
                Console.WriteLine();
                Command(Console.ReadLine());
            }
            Write("You died!");
            Console.ReadLine();
        }

        static void Battle(Enemy e)
        {
            Read("A " + e.Type + "[" + e.Level + "] attacks! Fight back?");
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
                            Write("(Enter 'attack', 'potion' or 'flee')", ConsoleColor.DarkGray, false);
                            Read();
                            switch (Input)
                            {
                                case "attack":
                                case "a":
                                    Attack(e);
                                    Break = true;
                                    break;
                                case "potion":
                                case "p":
                                    UsePotion();
                                    Break = true;
                                    break;
                                case "flee":
                                case "f":
                                    Flee(e);
                                    Active = false;
                                    Break = true;
                                    return;
                                default:
                                    Break = false;
                                    break;
                            }
                        }
                        if(e.HP > 0)
                        {
                            EnemyTurn(e);
                        }
                    }
                    break;
                case "no":
                    Flee(e);
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

            Write("[" + e.HP + "/" + e.MaxHP + "]", ConsoleColor.DarkRed, false);
            Console.WriteLine();
            if(e.HP <= 0)
            {
                //the enemy died
                Write("The " + e.Type + " died!");

                //the enemy drops loot
                if(e.Loot != null)
                {
                    Console.WriteLine();
                    if (e.Loot.Amount == 1)
                    {
                        Write("It dropped a " + e.Loot.Type + "!");
                        Write("You put the " + e.Loot.Type + " in your bag.");
                    }
                    else
                    {
                        Write("It dropped " + e.Loot.Amount + " " + e.Loot.Type + "s!");
                        Write("You put the " + e.Loot.Type + "s in your bag.");
                    }

                    if (e.Loot.Type == "Potion")
                    {
                        p.Bag.Potion.Amount = p.Bag.Potion.Amount + e.Loot.Amount;
                        Write("Potion[" + p.Bag.Potion.Amount + "]", ConsoleColor.DarkMagenta, false);
                    }
                    else if (e.Loot.Type == "Key")
                    {
                        p.Bag.Key.Amount = p.Bag.Key.Amount + e.Loot.Amount;
                        Write("Key[" + p.Bag.Key.Amount + "]", ConsoleColor.DarkGray, false);
                    }
                    else if (e.Loot.Type == "Coin")
                    {
                        p.Bag.Coin.Amount = p.Bag.Coin.Amount + e.Loot.Amount;
                        Write("Coin[" + p.Bag.Coin.Amount + "]", ConsoleColor.DarkYellow, false);
                    }
                    Console.WriteLine();
                }

                p.EXP = p.EXP + e.EXP;
                Write("You gained " + e.EXP + " EXP points.");
                if(p.EXP >= p.MaxEXP)
                {
                    //the player levels up
                    LevelUp();
                }
                Write("EXP[" + p.EXP + "/" + p.MaxEXP + "]", ConsoleColor.DarkGray);
                Active = false;
            }
        }
        
        static void Flee(Enemy e)
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

        static void EnemyTurn(Enemy e)
        {
            Write("The " + e.Type + " attacks you for " + e.Damage + " damage.");
            p.HP = p.HP - e.Damage;
            CheckHP();
            Console.WriteLine();
        }

        static void CheckHP()
        {
            Write("HP[" + p.HP + "/" + p.MaxHP + "]", ConsoleColor.DarkRed, false);
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
            Write("HP[" + p.HP + "/" + p.MaxHP + "]", ConsoleColor.DarkRed, false);

            p.EXP = p.EXP - p.MaxEXP;
            p.MaxEXP = (int)Math.Ceiling(p.MaxEXP * 1.5);
        }

        static void Chest(Chest c, bool mimic = false)
        {
            Read("You found a chest! Do you want to open it?");
            switch (Input)
            {
                case "yes":
                    if (mimic)
                    {
                        Battle(f.GetEnemy("Mimic", p));
                    }
                    else
                    {
                        if (c.Locked)
                        {
                            Read("The chest is locked, do you want to use a key?");
                            switch (Input)
                            {
                                case "yes":
                                    if (p.Bag.Key.Amount != 0)
                                    {
                                        p.Bag.Key.Amount = p.Bag.Key.Amount - 1;
                                        Write("You use a key.");
                                        Write("Keys[" + p.Bag.Key.Amount + "]", ConsoleColor.DarkGray, false);
                                        Console.WriteLine();
                                        OpenChest(c);
                                    }
                                    else
                                    {
                                        Write("You don't have any keys!");
                                        Write("You walk further.");
                                    }
                                    break;
                                case "no":
                                    Write("You walk further.");
                                    break;
                            }
                        }
                        else
                        {
                            OpenChest(c);
                        }
                    }
                    break;
                case "no":
                    Write("You walk further.");
                    break;
            }
        }

        static void OpenChest(Chest c)
        {
            Write("You open the chest...");
            if (c.Loot != null)
            {
                if(c.Loot.Amount == 1)
                {
                    Write("There is a " + c.Loot.Type + " inside!");
                    Write("You put the " + c.Loot.Type + " in your bag.");
                }
                else
                {
                    Write("There are " + c.Loot.Amount + " " + c.Loot.Type + "s inside!");
                    Write("You put the " + c.Loot.Type + "s in your bag.");
                }
                
                if(c.Loot.Type == "Potion")
                {
                    p.Bag.Potion.Amount = p.Bag.Potion.Amount + c.Loot.Amount;
                    Write("Potion[" + p.Bag.Potion.Amount + "]", ConsoleColor.DarkMagenta, false);
                }
                else if(c.Loot.Type == "Key")
                {
                    p.Bag.Key.Amount = p.Bag.Key.Amount + c.Loot.Amount;
                    Write("Key[" + p.Bag.Potion.Amount + "]", ConsoleColor.DarkGray, false);
                }
                else if(c.Loot.Type == "Coin")
                {
                    p.Bag.Coin.Amount = p.Bag.Coin.Amount + c.Loot.Amount;
                    Write("Coin[" + p.Bag.Potion.Amount + "]", ConsoleColor.DarkYellow, false);
                }
            }
            else
            {
                Write("There is a " + c.Weapon.Name + " inside!");
                Console.WriteLine();
                WeaponStats(c.Weapon);
                Console.WriteLine();
                Read("Do you want to take it with you?");
                switch (Input)
                {
                    case "yes":
                        Write("You take the " + c.Weapon.Name + " with you.");
                        p.Weapon = c.Weapon;
                        break;
                    case "no":
                        Write("You leave the " + c.Weapon.Name + ".");
                        break;
                }
            }
        }
    }
}
