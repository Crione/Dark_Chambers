using System;

namespace Dark_Chambers
{
    class Program
    {

        //Function methods
        static void Write(string Invoer, ConsoleColor Color = ConsoleColor.Gray, bool Sleep = true ,bool WriteLine = true)
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
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void Read(string Query = "", string Fallback = "")
        {
            if(Query != "")
            {
                bool c = false;
                Write(Query, ConsoleColor.White);
                while (c == false)
                {
                    Write("(Enter 'yes' or 'no')", ConsoleColor.DarkGray, false);
                    Invoer = Console.ReadLine();
                    Console.WriteLine();
                    switch (Invoer)
                    {
                        case "yes":
                        case "y":
                            c = true;
                            break;
                        case "no":
                        case "n":
                            if (Fallback == "")
                            {
                                Write(Query, ConsoleColor.White);
                            }
                            else
                            {
                                Write(Fallback, ConsoleColor.White);
                            }
                            c = false;
                            break;
                        default:
                            c = false;
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
        }

        static void Event()
        {
            Percentage = r.Next(0, 101);
            Console.WriteLine(Percentage);
            if(Percentage <= 80)
            {
                Percentage = r.Next(0, 101);
                Console.WriteLine(Percentage);
                if(Percentage <= 50)
                {
                    e = new Rat(r.Next((p.LVL - 3),(p.LVL + 2)));
                }else if(Percentage > 50 && Percentage <= 100)
                {
                    e = new Spider(r.Next((p.LVL - 3), (p.LVL + 2)));
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
            Write("A " + e.Type + " attacks!");
        }
    }
}
