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
            int colums;
            int rows;

            if (args.Length < 2)
            {
                Console.WriteLine("Run a Program with -r and -c " +
                    "arguments followed by a the number you want\n " +
                    "(-r for Rows and -c for Colums");
                return;
            }
            else if (args [0] == "-r")
            {
                rows = Convert.ToInt32(args[1]);
                colums = Convert.ToInt32(args[3]);

            }
            else if (args [0] == "-c")
            {
                rows = Convert.ToInt32(args[3]);
                colums = Convert.ToInt32(args[1]);
            }
            Menu();
        }

        /// <summary>
        /// A method that handles the menu printing and user input. 
        /// Here the user can start the game, check the highscores, 
        /// read the instructions or the credits
        /// </summary>
        static void Menu()
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
                        loop = false;
                        break;

                    //Shows the HighScore
                    case "2":
                        //Highscore()?
                        break;

                    //Print the intructions of the game
                    case "3":
                        Console.Write("TBD");
                        break;

                    //Prints the names of the developers
                    case "4":
                        Console.WriteLine("This game was developed by:");
                        Console.WriteLine("António Branco (21906811)");
                        Console.WriteLine("João Gonçalves (21901696)");
                        Console.WriteLine("Vasco Avec (21905658)");
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
    }
}
