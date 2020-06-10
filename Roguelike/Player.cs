using System;

namespace Roguelike
{
    public class Player
    {
        private int rows;
        private int columns;
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

                        else if(map.map [player.position[0],player.position[1]+1]
                        == 7)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[1] += 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP += 8;
                            break;
                        }

                        else if(map.map [player.position[0],player.position[1]+1]
                        == 8)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[1] += 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP += 16;
                            break;
                        }

                        else if(map.map [player.position[0],player.position[1]+1] 
                        != 3 && map.map 
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

                        else if(map.map [player.position[0],player.position[1]-1]
                        == 7)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[1] -= 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP += 8;
                            break;
                        }

                        else if(map.map [player.position[0],player.position[1]-1]
                        == 8)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[1] -= 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP += 16;
                            break;
                        }

                        else if(map.map [player.position[0],player.position[1]-1] 
                        != 3 && map.map 
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

                        else if(map.map [player.position[0]-1,player.position[1]]
                        == 7)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[0] -= 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP += 8;
                            break;
                        }

                        else if(map.map [player.position[0]-1,player.position[1]]
                        == 8)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[0] -= 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP += 16;
                            break;
                        }

                        else if(map.map [player.position[0]-1,player.position[1]] 
                        != 3 && map.map 
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

                        else if(map.map [player.position[0]+1,player.position[1]]
                        == 7)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[0] += 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP += 8;
                            break;
                        }

                        else if(map.map [player.position[0]+1,player.position[1]]
                        == 8)
                        {
                            map.map[player.position[0],player.position[1]] = 0;
                            player.position[0] += 1;
                            map.map[player.position[0],player.position[1]] = 1;
                            player.HP += 16;
                            break;
                        }

                        else if(map.map [player.position[0]+1,player.position[1]] 
                        != 3 && map.map 
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

                else
                {
                    Console.WriteLine(
                    "Invalid Input please type WASD to continue playing.");
                }
        
            } while(true);

            return player;
        }
    }
}