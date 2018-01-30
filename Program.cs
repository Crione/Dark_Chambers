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
            Console.ForegroundColor = ConsoleColor.White;
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
                p.name = Console.ReadLine();
                Console.WriteLine();
            }
        }

        static void InvoerCheck()
        {
           
        }


        //Game variables
        static string Invoer = "";
        static Player p = new Player();
        static bool Game = true;


        //Game
        static void Main(string[] args)
        {
            StartGame();
        }

        static void StartGame()
        {
            Write("Please enter your name:", ConsoleColor.White);
            Read();
            Read("Are you ready to enter the chambers?");
            while(Game == true)
            {
                Event();
            }
        }

        static void Event()
        {

        }
    }
}
