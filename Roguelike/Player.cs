using System;

namespace Roguelike
{
    /// <summary>
    /// Handles the player creation and movement
    /// </summary>
    public class Player
    {
        public int [] position { get; set;}
        public int HP { get; set;}

        /// <summary>
        /// Generate a player
        /// </summary>
        public Player(int rows, int columns)
        {
            position = new int [] { 0, 0};
            HP = rows * columns / 4;
        }

        /// <summary>
        /// Handles the movement of the player on the board
        /// </summary>
        /// <returns> The player position and HP </returns>
        public Player PlayerMovement(Player player, Map map, int rows,
        int columns)
        {
            //Variables
            ConsoleKeyInfo input;
            Random rnd = new Random();
            int rnd_pos;
            string wall = "----------------";

            //Do while the player does a correct movement
            do{
                //Takes the key input of the player
                input = Console.ReadKey(true);

                //Condition to see if the player pressed D or the right arrow
                if((input.Key.ToString() == "D") 
                || (input.Key == ConsoleKey.RightArrow))
                {
                    //Condition to see if the player don't go out of the map
                    if(player.position[1]+1 < columns)
                    {
                        //Checks if it's a small power-up
                        if(map.map [player.position[0],player.position[1]+1]
                        == 6)
                        {
                            //Changes and actualize the position of the player
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[1] += 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            //Augments the HP of the player
                            player.HP += 4;
                            Console.WriteLine(wall);
                            Console.WriteLine("You moved right!");
                            Console.WriteLine("You gained 4 HP");
                            break;
                        }

                        //Checks if it's a medium power-up
                        else if(map.map [player.position[0],
                        player.position[1]+1] == 7)
                        {
                            //Changes and actualize the position of the player
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[1] += 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            //Augments the HP of the player
                            player.HP += 8;
                            Console.WriteLine(wall);
                            Console.WriteLine("You moved right!");
                            Console.WriteLine("You gained 8 HP");
                            break;
                        }

                        //Checks if it's an big power-up
                        else if(map.map [player.position[0],
                        player.position[1]+1] == 8)
                        {
                            //Changes and actualize the position of the player
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[1] += 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            //Augments the HP of the player
                            player.HP += 16;
                            Console.WriteLine(wall);
                            Console.WriteLine("You moved right!");
                            Console.WriteLine("You gained 16 HP");
                            break;
                        }

                        //Checks if it's an possible movement
                        else if(map.map [player.position[0],
                        player.position[1]+1] != 3 && map.map 
                        [player.position[0],player.position[1]+1] != 4 && 
                        map.map [player.position[0],player.position[1]+1] != 5 
                        && map.map [player.position[0],player.position[1]+1] <9)
                        {
                            //Changes and actualize the position of the player
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[1] += 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            //Reduces the HP of the player
                            player.HP -= 1;
                            Console.WriteLine(wall);
                            Console.WriteLine("You moved right!");
                            Console.WriteLine("You lost 1 HP");
                            break;
                        }

                        //If it's none of the other conditions, nothing happens
                        else
                        {
                            Console.WriteLine(
                            "You can't go that way, try another path.");
                        }
                    }
                    //If the player goes out of the map, nothing happens
                    else
                    {
                        Console.WriteLine(
                        "You can't go that way, try another path.");
                    }
                }

                //Condition to see if the player pressed A or the left arrow
                else if((input.Key.ToString() == "A") 
                || (input.Key == ConsoleKey.LeftArrow))
                {
                    //Condition to see if the player don't go out of the map
                    if(player.position[1]-1 >= 0)
                    {
                        //Checks if it's a small power-up
                        if(map.map [player.position[0],player.position[1]-1]
                        == 6)
                        {
                            //Changes and actualize the position of the player
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[1] -= 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            //Augments the HP of the player
                            player.HP += 4;
                            Console.WriteLine(wall);
                            Console.WriteLine("You moved left!");
                            Console.WriteLine("You gained 4 HP");
                            break;
                        }

                        //Checks if it's a medium power-up
                        else if(map.map [player.position[0],
                        player.position[1]-1] == 7)
                        {
                            //Changes and actualize the position of the player
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[1] -= 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            //Augments the HP of the player
                            player.HP += 8;
                            Console.WriteLine(wall);
                            Console.WriteLine("You moved left!");
                            Console.WriteLine("You gained 8 HP");
                            break;
                        }

                        //Checks if it's an big power-up
                        else if(map.map [player.position[0],
                        player.position[1]-1] == 8)
                        {
                            //Changes and actualize the position of the player
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[1] -= 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            //Augments the HP of the player
                            player.HP += 16;
                            Console.WriteLine(wall);
                            Console.WriteLine("You moved left!");
                            Console.WriteLine("You gained 16 HP");
                            break;
                        }

                        //Checks if it's an possible movement
                        else if(map.map [player.position[0],
                        player.position[1]-1] != 3 && map.map 
                        [player.position[0],player.position[1]-1] != 4 && 
                        map.map [player.position[0],player.position[1]-1] != 5)
                        {
                            //Changes and actualize the position of the player
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[1] -= 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            //Reduces the HP of the player
                            player.HP -= 1;
                            Console.WriteLine(wall);
                            Console.WriteLine("You moved left!");
                            Console.WriteLine("You lost 1 HP");
                            break;
                        }

                        //If it's none of the other conditions, nothing happens
                        else
                        {
                            Console.WriteLine(
                            "You can't go that way, try another path.");
                        }
                    }
                    //If the player goes out of the map, nothing happens
                    else
                    {
                        Console.WriteLine(
                        "You can't go that way, try another path.");
                    }
                }

                //Condition to see if the player pressed W or the up arrow
                else if((input.Key.ToString() == "W") 
                || (input.Key == ConsoleKey.UpArrow))
                {
                    //Condition to see if the player don't go out of the map
                    if(player.position[0]-1 >= 0)
                    {
                        //Checks if it's a small power-up
                        if(map.map [player.position[0]-1,player.position[1]]
                        == 6)
                        {
                            //Changes and actualize the position of the player
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[0] -= 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            //Augments the HP of the player
                            player.HP += 4;
                            Console.WriteLine(wall);
                            Console.WriteLine("You moved up!");
                            Console.WriteLine("You gained 4 HP");
                            break;
                        }

                        //Checks if it's a medium power-up
                        else if(map.map [player.position[0]-1,
                        player.position[1]] == 7)
                        {
                            //Changes and actualize the position of the player
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[0] -= 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            //Augments the HP of the player
                            player.HP += 8;
                            Console.WriteLine(wall);
                            Console.WriteLine("You moved up!");
                            Console.WriteLine("You gained 8 HP");
                            break;
                        }

                        //Checks if it's an big power-up
                        else if(map.map [player.position[0]-1,
                        player.position[1]] == 8)
                        {
                            //Changes and actualize the position of the player
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[0] -= 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            //Augments the HP of the player
                            player.HP += 16;
                            Console.WriteLine(wall);
                            Console.WriteLine("You moved up!");
                            Console.WriteLine("You gained 16 HP");
                            break;
                        }

                        //Checks if it's an possible movement
                        else if(map.map [player.position[0]-1,
                        player.position[1]] != 3 && map.map 
                        [player.position[0]-1,player.position[1]] != 4 && 
                        map.map [player.position[0]-1,player.position[1]] != 5)
                        {
                            //Changes and actualize the position of the player
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[0] -= 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            //Reduces the HP of the player
                            player.HP -= 1;
                            Console.WriteLine(wall);
                            Console.WriteLine("You moved up!");
                            Console.WriteLine("You lost 1 HP");
                            break;
                        }

                        //If it's none of the other conditions, nothing happens
                        else
                        {
                            Console.WriteLine(
                            "You can't go that way, try another path.");
                        }
                    }
                    //If the player goes out of the map, nothing happens
                    else
                    {
                        Console.WriteLine(
                        "You can't go that way, try another path.");
                    }
                }

                //Condition to see if the player pressed S or the down arrow
                else if((input.Key.ToString() == "S") 
                || (input.Key == ConsoleKey.DownArrow))
                {
                    //Condition to see if the player don't go out of the map
                    if(player.position[0]+1 < rows)
                    {
                        //Checks if it's a small power-up
                        if(map.map [player.position[0]+1,player.position[1]]
                        == 6)
                        {
                            //Changes and actualize the position of the player
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[0] += 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            //Augments the HP of the player
                            player.HP += 4;
                            Console.WriteLine(wall);
                            Console.WriteLine("You moved down!");
                            Console.WriteLine("You gained 4 HP");
                            break;
                        }

                        //Checks if it's a medium power-up
                        else if(map.map [player.position[0]+1,
                        player.position[1]] == 7)
                        {
                            //Changes and actualize the position of the player
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[0] += 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            //Augments the HP of the player
                            player.HP += 8;
                            Console.WriteLine(wall);
                            Console.WriteLine("You moved down!");
                            Console.WriteLine("You gained 8 HP");
                            break;
                        }

                        //Checks if it's an big power-up
                        else if(map.map [player.position[0]+1,
                        player.position[1]] == 8)
                        {
                            //Changes and actualize the position of the player
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[0] += 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            //Augments the HP of the player
                            player.HP += 16;
                            Console.WriteLine(wall);
                            Console.WriteLine("You moved down!");
                            Console.WriteLine("You gained 16 HP");
                            break;
                        }

                        //Checks if it's an possible movement
                        else if(map.map [player.position[0]+1,
                        player.position[1]] != 3 && map.map 
                        [player.position[0]+1,player.position[1]] != 4 && 
                        map.map [player.position[0]+1,player.position[1]] != 5)
                        {
                            //Changes and actualize the position of the player
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[0] += 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            //Reduces the HP of the player
                            player.HP -= 1;
                            Console.WriteLine(wall);
                            Console.WriteLine("You moved down!");
                            Console.WriteLine("You lost 1 HP");
                            break;
                        }

                        //If it's none of the other conditions, nothing happens
                        else
                        {
                            Console.WriteLine(
                            "You can't go that way, try another path.");
                        }
                    }
                    //If the player goes out of the map, nothing happens
                    else
                    {
                        Console.WriteLine(
                        "You can't go that way, try another path.");
                    }
                }

                //Condition to see if the player pressed Q
                else if(input.Key.ToString() == "Q")
                {
                    //Remove the player from the actual position and reduces HP
                    map.map[player.position[0],
                    player.position[1]] = 0;
                    rnd_pos = rnd.Next(0, rows);
                    player.HP -= 5;
                    //Sees if the tp position in the first column is free
                    if(map.map[0, rnd_pos] == 0)
                    {
                        //If it's possible to tp, then the player will have
                        //a new position
                        player.position[0] = rnd_pos;
                        player.position[1] = 0;
                        Console.WriteLine("The tp was successful!");
                        Console.WriteLine("You lost 5 HP");
                    }
                    //If it's not, nothing happens
                    else
                    {
                        Console.WriteLine(
                        "Sorry, but the tp failed. Try again.");
                        Console.WriteLine("You lost 5 HP");
                    }
                    //Sees if you died while using the tp
                    if(player.HP <= 0)
                    {
                        Console.WriteLine("You died using the tp ...");
                    }
                    //Puts the player a position, depending if the tp was
                    //successful or not
                    map.map[player.position[0],
                    player.position[1]] = 1;
                    break;
                }

                //Condition to see if the player pressed Esc(Escape)
                else if(input.Key == ConsoleKey.Escape)
                {
                    //If he press it, the player dies, returning to the menu
                    player.HP = 0;
                    Console.WriteLine(
                    "You decided to put an end to your life ...");
                    break;
                }

                //Condition to see if the player pressed any other key
                else
                {
                    //This gives the possible inputs of the game
                    Console.Write(
                    "Invalid Input please type WASD/arrows to move");
                    Console.WriteLine(
                    "or Q to use super tp to continue playing.");
                    Console.WriteLine(
                    "You can also press Esc(Escape) to quit the actual game");
                }
        
            } while(true);

            return player;
        }
    }
}