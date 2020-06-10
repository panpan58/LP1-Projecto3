using System;
namespace Roguelike
{
    public class Player
    {
        private int rows;
        private int columns;
        public int [] position { get; set;}
        private int HP { get; set;}

        public Player(int rows, int columns)
        {
            position = new int [] { 0, 0};
            HP = rows * columns / 4;
        }

        public Player PlayerMovement(Player player, Map map)
        {
            string input = Console.ReadLine();

            switch(input)
            {
                case "d":
                
                    if(map.map [player.position[0],player.position[1]+1] 
                    != 3 && map.map 
                    [player.position[0],player.position[1]+1] != 4 && 
                    map.map [player.position[0],player.position[1]+1] != 5)
                    {
                        map.map[player.position[0],player.position[1]] = 0;
                        player.position[1] += 1;
                        map.map[player.position[0],player.position[1]] = 1;
                        player.HP -= 1;
                        
                    }
                    break;

                case "a":
                
                    if(map.map [player.position[0],player.position[1]-1] 
                    != 3 && map.map 
                    [player.position[0],player.position[1]-1] != 4 && 
                    map.map [player.position[0],player.position[1]-1] != 5)
                    {
                        map.map[player.position[0],player.position[1]] = 0;
                        player.position[1] -= 1;
                        map.map[player.position[0],player.position[1]] = 1;
                        HP -= 1;
                        
                    }
                    break;

                case "w":
                
                    if(map.map [player.position[0]-1,player.position[1]] 
                    != 3 && map.map 
                    [player.position[0]-1,player.position[1]] != 4 && 
                    map.map [player.position[0]-1,player.position[1]] != 5)
                    {
                        map.map[player.position[0],player.position[1]] = 0;
                        player.position[0] -= 1;
                        map.map[player.position[0],player.position[1]] = 1;
                        HP -= 1;
                        
                    }
                    break;
                
                case "s":

                    if(map.map [player.position[0]+1,player.position[1]] 
                    != 3 && map.map 
                    [player.position[0]+1,player.position[1]] != 4 && 
                    map.map [player.position[0]+1,player.position[1]] != 5)
                    {
                        map.map[player.position[0],player.position[1]] = 0;
                        player.position[0] += 1;
                        map.map[player.position[0],player.position[1]] = 1;
                        HP -= 1;
                    }
                    break;

                default:
                    break;
            }
            return player;
        }
    }
}