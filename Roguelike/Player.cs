using System;

namespace Roguelike
{
    public class Player
    {
        public int [] position { get; set;}
        public int HP { get; set;}

        public Player(int rows, int columns)
        {
            position = new int [] { 0, 0};
            HP = rows * columns / 4;
        }

        public Player PlayerMovement(Player player, Map map, int rows,
        int columns)
        {
            ConsoleKeyInfo input;
            Random rnd = new Random();
            int rnd_pos;

            do{
                input = Console.ReadKey(true);

                if(input.Key.ToString() == "D")
                {
                    if(player.position[1]+1 < columns)
                    {
                        if(map.map [player.position[0],player.position[1]+1]
                        == 6)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[1] += 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP += 4;
                            break;
                        }

                        else if(map.map [player.position[0],
                        player.position[1]+1] == 7)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[1] += 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP += 8;
                            break;
                        }

                        else if(map.map [player.position[0],
                        player.position[1]+1] == 8)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[1] += 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP += 16;
                            break;
                        }

                        else if(map.map [player.position[0],
                        player.position[1]+1] != 3 && map.map 
                        [player.position[0],player.position[1]+1] != 4 && 
                        map.map [player.position[0],player.position[1]+1] != 5)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[1] += 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP -= 1;
                            break;
                        }
                        else
                        {
                            Console.WriteLine(
                            "You can't go that way, try another path.");
                        }
                    }
                    else
                    {
                        Console.WriteLine(
                        "You can't go that way, try another path.");
                    }
                }

                else if(input.Key.ToString() == "A")
                {
                    if(player.position[1]-1 >= 0)
                    {
                        if(map.map [player.position[0],player.position[1]-1]
                        == 6)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[1] -= 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP += 4;
                            break;
                        }

                        else if(map.map [player.position[0],
                        player.position[1]-1] == 7)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[1] -= 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP += 8;
                            break;
                        }

                        else if(map.map [player.position[0],
                        player.position[1]-1] == 8)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[1] -= 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP += 16;
                            break;
                        }

                        else if(map.map [player.position[0],
                        player.position[1]-1] != 3 && map.map 
                        [player.position[0],player.position[1]-1] != 4 && 
                        map.map [player.position[0],player.position[1]-1] != 5)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[1] -= 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP -= 1; 
                            break;
                        }
                        else
                        {
                            Console.WriteLine(
                            "You can't go that way, try another path.");
                        }
                    }
                    else
                    {
                        Console.WriteLine(
                        "You can't go that way, try another path.");
                    }
                }

                else if(input.Key.ToString() == "W")
                {
                    if(player.position[0]-1 >= 0)
                    {
                        if(map.map [player.position[0]-1,player.position[1]]
                        == 6)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[0] -= 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP += 4;
                            break;
                        }

                        else if(map.map [player.position[0]-1,
                        player.position[1]] == 7)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[0] -= 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP += 8;
                            break;
                        }

                        else if(map.map [player.position[0]-1,
                        player.position[1]] == 8)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[0] -= 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP += 16;
                            break;
                        }

                        else if(map.map [player.position[0]-1,
                        player.position[1]] != 3 && map.map 
                        [player.position[0]-1,player.position[1]] != 4 && 
                        map.map [player.position[0]-1,player.position[1]] != 5)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[0] -= 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP -= 1;
                            break;
                        }
                        else
                        {
                            Console.WriteLine(
                            "You can't go that way, try another path.");
                        }
                    }
                    else
                    {
                        Console.WriteLine(
                        "You can't go that way, try another path.");
                    }
                }
                else if(input.Key.ToString() == "S")
                {
                    if(player.position[0]+1 < rows)
                    {
                        if(map.map [player.position[0]+1,player.position[1]]
                        == 6)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[0] += 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP += 4;
                            break;
                        }

                        else if(map.map [player.position[0]+1,
                        player.position[1]] == 7)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[0] += 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP += 8;
                            break;
                        }

                        else if(map.map [player.position[0]+1,
                        player.position[1]] == 8)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[0] += 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP += 16;
                            break;
                        }

                        else if(map.map [player.position[0]+1,
                        player.position[1]] != 3 && map.map 
                        [player.position[0]+1,player.position[1]] != 4 && 
                        map.map [player.position[0]+1,player.position[1]] != 5)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[0] += 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP -= 1;
                            break;
                        }
                        else
                        {
                            Console.WriteLine(
                            "You can't go that way, try another path.");
                        }
                    }
                    else
                    {
                        Console.WriteLine(
                        "You can't go that way, try another path.");
                    }
                }

                else if(input.Key.ToString() == "Q")
                {
                    map.map[player.position[0],
                    player.position[1]] = 0;
                    rnd_pos = rnd.Next(0, rows);
                    player.HP -= 5;
                    if(map.map[0, rnd_pos] == 0)
                    {
                        player.position[0] = rnd_pos;
                        player.position[1] = 0;
                        Console.WriteLine("The tp was successful!");
                    }
                    else
                    {
                        Console.WriteLine(
                        "Sorry, but the tp failed. Try again.");
                    }
                    if(player.HP <= 0)
                    {
                        Console.WriteLine("You died using the tp ...");
                    }
                    map.map[player.position[0],
                    player.position[1]] = 1;
                    break;
                }

                else
                {
                    Console.Write("Invalid Input please type WASD to move");
                    Console.WriteLine(
                    "or Q to use super tp to continue playing.");
                }
        
            } while(true);

            return player;
        }
    }
}