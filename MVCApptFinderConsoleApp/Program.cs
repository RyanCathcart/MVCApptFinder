using System;
using MVCApptFinderLib;

namespace MVCApptFinderConsoleApp
{
    class Program
    {
        public static bool Exit = false;
        public static DateTime DateThreshold = DateTime.Today.AddDays(8); // Sets the default date threshold to one week from today.
        
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("New Jersey MVC Appointment Finder");
            Console.WriteLine($"Current date threshold: Finding appointments before {DateThreshold}");
            Console.ForegroundColor = ConsoleColor.Gray;           

            while (!Exit)
            {
                Console.Write("Enter a command. Type 'help' for command list.\n> "); 
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                string userInput = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.Gray;

                if (userInput.Equals("start"))
                {
                    Start();
                }
                else if (userInput.Equals("quit"))
                {
                    Quit();
                }
                else if (userInput.Equals("help"))
                {
                    Help();
                }
                else if (userInput.Equals("threshold"))
                {
                    Threshold();
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

        public static void Threshold()
        {
            Console.Write("Enter a new date limit to find appointments before, in the format mm/dd/yy. (An empty or invalid entry will not change the value)\n> "); 
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            string userInput = Console.ReadLine().ToLower();
            Console.ForegroundColor = ConsoleColor.Gray;

            try 
            {
                DateThreshold = new DateTime(2000 + Int32.Parse(userInput.Substring(6, 2)), Int32.Parse(userInput.Substring(0, 2)), Int32.Parse(userInput.Substring(3, 2)));
            }
            catch (Exception e)
            {
                Console.WriteLine("The date was not changed.");
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Current date threshold: Finding appointments before {DateThreshold}");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void Quit()
        {
            Console.WriteLine("Quit successfully.\n");
            Exit = true;
        }

        public static void Help()
        {
            Console.WriteLine("Commands:");
            Console.WriteLine("  start     - Begins the appointment searching process.");
            Console.WriteLine("  quit      - Quits this application.");
            Console.WriteLine("  threshold - Asks for a new date limit to find appointments before.");
            Console.WriteLine("  help      - Lists the commands and what they do.");
        }
    }
}