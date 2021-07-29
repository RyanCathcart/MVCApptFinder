using System;
using MVCApptFinderLib;

namespace MVCApptFinderConsoleApp
{
    class Program
    {
        public static bool exit = false;
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("New Jersey MVC Appointment Finder");
            Console.ForegroundColor = ConsoleColor.Gray;           

            while (!exit)
            {
                Console.Write("Enter a command. Type 'help' for command list.\n> "); 
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                string userInput = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.Gray;

                if (userInput.Equals("start"))
                {
                    Start();
                }
                else if (userInput.Equals("help"))
                {
                    Help();
                }
                else if (userInput.Equals("quit"))
                {
                    Quit();
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                }
            }
        }

        public static void Start()
        {
            string url = @"https://telegov.njportal.com/njmvc/AppointmentWizard/11";
            Toolkit.LoadData(url);
        }

        public static void Quit()
        {
            Console.WriteLine("Quit successfully.\n");
            exit = true;
        }

        public static void Help()
        {
            Console.WriteLine("Commands:    start    quit    help");
        }
    }
}