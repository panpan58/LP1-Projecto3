using System;
using System.Net.Mail;
using System.Text;
using System.Collections;
using System.Collections.Generic;  
using System.Threading;


namespace Roguelike
{
    /// <summary>
    /// Handles the game launch, the menu, game loop and prints the map
    /// </summary>
    class Program
    {
        /// <summary>
        /// Handles the game launch
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Variables
            int columns;
            int rows;
            Console.OutputEncoding = Encoding.UTF8;

            // Verifies if the player inputs enough arguments and
            // correctly states the rows and columns
            if ((args[0] == "-r") && (args[2] == "-c") && (args.Length == 4))
            {
                rows = Convert.ToInt32(args[1]);
                columns = Convert.ToInt32(args[3]);
            }
            else if ((args[0] == "-c") && (args[2] == "-r") && 
            (args.Length == 4))
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

        /// <summary>
        /// Prints the menu and it´s option, handles the player input regarding itself
        /// </summary>
        /// <param name="rows"> States the rows for the game generation</param>
        /// <param name="columns"> States the columns for the game  generation</param>
        static void Menu(int rows, int columns)
        {
            //Variables
            string answer;
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

                answer = Console.ReadLine();
                Console.WriteLine(wall);
                
                switch (answer)
                {
                    //Starts new game
                    case "1":
                        Game(rows, columns);
                        loop = false;
                        break;

                    //Shows the HighScore
                    case "2":
                        HighScore.PrintHighScoreList();
                        Console.WriteLine(wall);
                        Console.WriteLine("Press Enter to continue.");
                        while(Console.ReadKey().Key != ConsoleKey.Enter) { }
                        break;

                    //Print the intructions of the game
                    case "3":
                        Console.WriteLine(" - Use the keys WASD/arrows to move"
                        +" across the board.");
                        Console.WriteLine(" - Reach the objective to pass to"
                        +" the next level");
                        Console.WriteLine(" - You can't pass through enemies"
                        +" and walls");
                        Console.WriteLine(" - Enemies will drain your HP if by"
                        +" your side");
                        Console.WriteLine(" - Power ups will give you HP");
                        Console.WriteLine(" - For each move you do, you lose 1"
                        +" HP");
                        Console.WriteLine(" - You can use a random teleport"
                        +" to the first column by pressing the Q key");
                        Console.WriteLine(" - You can quit at any moment of"
                        + "the game by pressing the Escape key(esc).");
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
                        Console.WriteLine(
                        "Please type the number of the option");
                        break;
                }
            }
        }
        
        /// <summary>
        /// The game loop, verifies when the player HP drops to 0
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        static void Game(int rows, int columns)
        {
            //Variables
            int level = 0;
            int[] vector = new int[] {0,0};
            Map map;
            Player player;
            Ending end;
            Enemy[] enemies;
            PowerUp[] powerup;

            //This is the game loop
            while (true)
            {
                //Generate map depending of the level
                level += 1;
                player = new Player(rows, columns);
                end = new Ending();
                enemies = new Enemy[999];
                powerup = new PowerUp[999];
                map = new Map(rows, columns, level, player, end, enemies, 
                powerup);

                //This is the level loop
                while(true)
                {
                    //This for is the player round, 
                    //doing twice so the player moves/tp twice
                    for(int i = 0; i < 2; i++)
                    {
                        //Draw the map in the console
                        MapDraw(rows, columns, enemies, map, 
                        player.HP, level);
                        //Goes to the fonction that does the player movement
                        player = player.PlayerMovement(player, map, rows, 
                        columns);
                        Console.WriteLine("----------------------------------");
                        //Condition to see if the player died, quiting the for
                        //to finish the game
                        if(player.HP <= 0)
                        {
                            break;
                        }
                        //Condition to see if the player reached the end of
                        //the level, quiting the for to go to the next level
                        if((player.position[0] == end.position[0]) &&
                        (player.position[1] == end.position[1]))
                        {
                            Console.WriteLine(
                                $"Congrats, you passed to level {level+1}!");
                            break;
                        }
                    }
                    //Condition to see if the player died, quiting the while 
                    //to finish the game
                    if(player.HP <= 0)
                    {
                        break;
                    }
                    //Condition to see if the player reached the end of
                    //the level, quiting the while do go to the next level
                    if((player.position[0] == end.position[0]) &&
                    (player.position[1] == end.position[1]))
                    {
                        break;
                    }
                    //This for is for each enemy to move/attack
                    for(int i = 0; i < 1000; i++)
                    {
                        //By using try and catch, the for will stop if there's
                        //no more enemies to move/attack
                        try
                        {
                        //Call the function that does the enemy action
                        enemies[i] = enemies[i].EnemiesMovement(enemies, player,
                        map, rows, columns, i, vector);
                        //This give the player some time to read what 
                        //the enemies are doing
                        Thread.Sleep(500);
                        }
                        //Breaks the for if no more enemies
                        catch (NullReferenceException)
                        {
                            break;
                        }
                    }
                    Console.WriteLine("----------------");
                    //Condition to see if the player died, quiting the while 
                    //to finish the game
                    if(player.HP <= 0)
                    {
                        break;
                    }
                }
                //If the player died, this will show of their score and player 
                //goes back to the menu
                if(player.HP <= 0)
                {
                    Console.WriteLine("You dropped to 0 HP.");
                    Console.WriteLine("Game Over");
                    Console.WriteLine("Final Score: " + level);
                    //This will call the function do see if the player
                    //beats the highscore
                    HighScore.AddToHighScoreList(new HighScoreList("Pattern", 
                    level));
                    //Calls the menu
                    Menu(rows, columns);
                    break;
                }
            }
            
        }
        
        /// <summary>
        /// Draws the map
        /// </summary>
        static void MapDraw(int rows, int columns, 
        Enemy[] enemies, Map map, int HP, int level)
        {
            //Variables
            int [,] map_renderer = map.map;
            char objective = 'O';
            char empty = '_';
            char player = 'P';
            char wall = 'W';
            char enemy = 'e';
            char strong_enemy = 'E';
            char small_pup = 'S';
            char medium_pup = 'M';
            char big_pup = 'B';
            
            //Shows the HP of the player and the level of the map
            Console.WriteLine("HP:"+ HP + " Lvl:" + level);
            
            //This for analyses the rows of the board
            for (int i = 0; i < rows; i++)
            {
                //This for analyses the columns of the board
                for(int j = 0; j < columns; j++)
                {
                    //If there's the player in that position, print P
                    if(map_renderer [i,j] == 1)
                    {
                        Console.Write(player);
                    }
                    //If there's the end of the level in that position, print O
                    else if (map_renderer [i,j] == 2)
                    {
                        Console.Write(objective);
                    }
                    //If there's a wall in that position, print W
                    else if (map_renderer [i,j] == 3)
                    {
                        Console.Write(wall);
                    }
                    //If there's an enemy in that position, print e
                    else if (map_renderer [i,j] == 4)
                    {
                        Console.Write(enemy);
                    }
                    //If there's an strong enemy in that position, print E
                    else if (map_renderer [i,j] == 5)
                    {
                        Console.Write(strong_enemy);
                    }
                    //If there's an small power-up in that position, print S
                    else if (map_renderer [i,j] == 6)
                    {
                        Console.Write(small_pup);
                    }
                    //If there's an medium power-up in that position, print M
                    else if (map_renderer[i, j] == 7)
                    {
                        Console.Write(medium_pup);
                    }
                    //If there's an small power-up in that position, print B
                    else if (map_renderer[i, j] == 8)
                    {
                        Console.Write(big_pup);
                    }
                    //This will help to conserv the power-ups under the enemies
                    else if(map_renderer[i, j] > 8)
                    {
                        //This analyse every enemy
                        for(int e = 0; e < 1000; e++)
                        {
                            //By using try and catch, the for will stop if
                            //it analyses all positions of the enemies
                            try
                            {
                                //Condition to see if there's an enemy position
                                //in the same spot of the map
                                if((enemies[e].position[0] == i) && 
                                (enemies[e].position[1] == j))
                                {
                                    //Both conditions see if it's a strong or 
                                    //a normal enemy
                                    if(enemies[e].HP == 5)
                                    {
                                        Console.Write(enemy);
                                        break;
                                    }
                                    else
                                    {
                                        Console.Write(strong_enemy);
                                        break;
                                    }
                                }
                            }
                            //Breaks the for if no more enemies
                            catch (NullReferenceException)
                            {
                                break;
                            }
                        }
                    }
                    //If there's nothing, print _
                    else
                    {
                        Console.Write(empty);
                    } 
                }
                Console.WriteLine("");
            }
            //Print the description for the board
            Console.WriteLine("P - Player   O - Objective      W - Wall");
            Console.WriteLine("e - Enemy    E - Strong enemy   S - Small" 
            +" power up");
            Console.WriteLine("M - Medium power up   B - Big power up");
        }
    }
}
