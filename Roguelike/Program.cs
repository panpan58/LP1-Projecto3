using System;
using System.Net.Mail;

/// <summary>
/// 
/// </summary>
namespace Roguelike
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Variables
            int columns;
            int rows;

            if ((args[0] == "-r") && (args.Length == 4))
            {
                rows = Convert.ToInt32(args[1]);
                columns = Convert.ToInt32(args[3]);
            }
            else if ((args[0] == "-c") && (args.Length == 4))
            {
                rows = Convert.ToInt32(args[3]);
                columns = Convert.ToInt32(args[1]);
            }
            else
            {
                Console.Write(
                "Run a Program with -r and -c arguments followed");
                Console.Write(
                "by a the number you want\n (-r for Rows and -c for Columns");
                return;
            }
            Menu(rows, columns);
        }

        
        static void Menu(int rows, int columns)
        {
            //Variables
            string awnser;
            bool loop = true;
            

            while (loop)
            {
                //The Menu itself
                Console.WriteLine("----------------");
                Console.WriteLine("1. New Game");
                Console.WriteLine("2. High Scores");
                Console.WriteLine("3. Instructions");
                Console.WriteLine("4. Credits");
                Console.WriteLine("5. Quit");
                Console.WriteLine("----------------");

                awnser = Console.ReadLine();
                switch (awnser)
                {
                    //Starts new game
                    case "1":
                        Game(rows, columns);
                        loop = false;
                        break;

                    //Shows the HighScore
                    case "2":
                        //Highscore()?
                        Console.WriteLine("Press ENTER to continue");
                        Console.ReadLine();
                        break;

                    //Print the intructions of the game
                    case "3":
                        Console.WriteLine("TBD");
                        Console.WriteLine("Press ENTER to continue");
                        Console.ReadLine();
                        break;

                    //Prints the names of the developers
                    case "4":
                        Console.WriteLine("This game was developed by:");
                        Console.WriteLine("Antonio Branco (21906811)");
                        Console.WriteLine("Joao Goncalves (21901696)");
                        Console.WriteLine("Vasco Duarte (21905658)");
                        Console.WriteLine("Press ENTER to continue");
                        Console.ReadLine();
                        break;

                    //Leaves the game
                    case "5":
                        return;

                    //An option when the awnser is not valid
                    default:
                        Console.WriteLine("That's not a valid option");
                        Console.WriteLine("Please type the number of the option");
                        break;
                }
            }
        }
        
        static void Game(int rows, int columns)
        {
            //Variables
            int level = 0;
            Map map;
            
            while(true)
            {
                //map generation
                level += 1;
                map = new Map(rows, columns, level);
                while(true)
                {

                }
            }
            
        }
    }
}
