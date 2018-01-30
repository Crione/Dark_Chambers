using System;

namespace Dark_Chambers
{
    class Program
    {

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
            if(Query == "")
            {
                Write(Query);
                bool Break = false;
                while (Break == false)
                {
                    Write("(Enter 'yes' or 'no')", ConsoleColor.DarkGray, false);
                    Invoer = Console.ReadLine();
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
            Write("[HP " + p.HP + "/" + p.MaxHP + "]", ConsoleColor.DarkRed);
            if(p.HP <= 0)
            {
                Game = false;
            }
        }

        //Game variables

        static Enemy e = new Enemy();
        static Player p = new Player();
        static bool Game = true;

        static string Invoer = "";
        static int Percentage { get; set; }
        static Random r = new Random();


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
                                Break = true;
                                break;
                            default:
                                Break = false;
                                break;
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
                p.HP = p.HP - e.DMG;
                Write("The " + e.Type + " attacks you for " + e.DMG + " damage.");
                CheckHP();
            }
        }
    }
}
