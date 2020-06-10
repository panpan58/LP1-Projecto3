using System;
using System.Net.Mail;
using System.Text;
using System.Collections;
using System.Collections.Generic;  

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
            Console.OutputEncoding = Encoding.UTF8;

            if ((args[0] == "-r") && (args[2] == "-c") && (args.Length == 4))
            {
                rows = Convert.ToInt32(args[1]);
                columns = Convert.ToInt32(args[3]);
            }
            else if ((args[0] == "-c") && (args[2] == "-r") && (args.Length == 4))
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
            string wall = "----------------";


            while (loop)
            {
                //The Menu itself
                Console.WriteLine(wall);
                Console.WriteLine("1. New Game");
                Console.WriteLine("2. High Scores");
                Console.WriteLine("3. Instructions");
                Console.WriteLine("4. Credits");
                Console.WriteLine("5. Quit");
                Console.WriteLine(wall);

                awnser = Console.ReadLine();
                Console.WriteLine(wall);
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
                        Console.WriteLine("Press Enter to continue.");
                        while(Console.ReadKey().Key != ConsoleKey.Enter) { }
                        break;

                    //Print the intructions of the game
                    case "3":
                        Console.WriteLine("TBD");
                        Console.WriteLine(wall);
                        Console.WriteLine("Press Enter to continue.");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        break;

                    //Prints the names of the developers
                    case "4":
                        Console.WriteLine("This game was developed by:");
                        Console.WriteLine("Antonio Branco (21906811)");
                        Console.WriteLine("Joao Goncalves (21901696)");
                        Console.WriteLine("Vasco Duarte (21905658)");
                        Console.WriteLine(wall);
                        Console.WriteLine("Press Enter to continue.");
                        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
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
            Player player;
            Ending end;
            Enemy[] enemies;
            PowerUp[] powerup;

            while (true)
            {
                //map generation
                level += 1;
                player = new Player(rows, columns);
                end = new Ending();
                enemies = new Enemy[999];
                powerup = new PowerUp[999];
                map = new Map(rows, columns, level, player, end, enemies, 
                powerup);

                while(true)
                {
                    MapDraw(rows, columns, map);
                    player = player.PlayerMovement(player, map, rows, columns);
                    Console.WriteLine(player.HP);
                    //Console.ReadLine();
                    //break;
                }
            }
            
        }
        
        static void MapDraw(int rows, int columns, Map map)
        {
            //Variables
            int [,] map_renderer = map.GetMap();
            char objective = 'E';
            char empty = '_';
            char player = 'P';
            char wall = 'W';
            char enemy = 'B';
            char strong_enemy = 'S';
            char small_pup = 'Y';
            char medium_pup = 'O';
            char big_pup = 'G';
            
            for (int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    if(map_renderer [i,j] == 1)
                    {
                        Console.Write(player);
                    }
                    else if (map_renderer [i,j] == 2)
                    {
                        Console.Write(objective);
                    }
                    else if (map_renderer [i,j] == 3)
                    {
                        Console.Write(wall);
                    }
                    else if (map_renderer [i,j] == 4)
                    {
                        Console.Write(enemy);
                    }
                    else if (map_renderer [i,j] == 5)
                    {
                        Console.Write(strong_enemy);
                    }
                    else if (map_renderer [i,j] == 6)
                    {
                        Console.Write(small_pup);
                    }
                    else if (map_renderer[i, j] == 7)
                    {
                        Console.Write(medium_pup);
                    }
                    else if (map_renderer[i, j] == 8)
                    {
                        Console.Write(big_pup);
                    }
                    else
                    {
                        Console.Write(empty);
                    }  
                }
                Console.WriteLine("");
            }
        }
    }
}
