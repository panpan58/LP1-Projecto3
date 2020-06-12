using System;

namespace Roguelike
{
    /// <summary>
    /// Handles the creation and movement of 
    /// Each enemy
    /// </summary>
    public class Enemy
    {
        public int HP { get; set;}
        public int [] position { get; set;}

        /// <summary>
        /// Verifies if the new Enemy will be
        ///  Big or Small according to luck
        /// </summary>
        /// <param name="luck"> Random number generated for each new enemy</param>
        public Enemy(int luck)
        {
            position = new int [] { 0, 0};
            if(luck == 5)
            {
                HP = 10;
            }
            else
            {
                HP = 5;
            }
        }

        /// <summary>
        /// Handles the movement of each enemy on the board
        /// </summary>
        /// <returns> The enemy position </returns>
        public Enemy EnemiesMovement(Enemy[] enemies, Player player, Map map, 
        int rows,int columns, int i, int[] vector)
        {
            int enemy_number;

            vector[0] = player.position[0] - enemies[i].position[0];
            vector[1] = player.position[1] - enemies[i].position[1];

            if(Math.Abs(vector[0]) > Math.Abs(vector[1]))
            {
                if(vector[0] > 0)
                {
                    if(map.map [enemies[i].position[0] + 1,
                    enemies[i].position[1]] == 1)
                    {
                        player.HP -= enemies[i].HP;
                        Console.WriteLine($"You lost {enemies[i].HP} HP");
                    }
                    else if((map.map [enemies[i].position[0] + 1,
                    enemies[i].position[1]] == 0) || 
                    ((map.map [enemies[i].position[0] + 1,
                    enemies[i].position[1]] >= 6) && 
                    (map.map [enemies[i].position[0] + 1,
                    enemies[i].position[1]] < 9)))
                    {
                        enemy_number = map.map [enemies[i].position[0],
                        enemies[i].position[1]];

                        if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] > 9) && (enemies[i].HP == 5))
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] -= 4;
                            enemy_number = 4;
                        }
                        else if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] > 9) && (enemies[i].HP == 10))
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] -= 5;
                            enemy_number = 5;
                        }
                        else
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] = 0;
                        }

                        enemies[i].position[0] += 1;

                        if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] >= 6) && 
                        (map.map [enemies[i].position[0],
                        enemies[i].position[1]] < 10))
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] += enemy_number;
                        }
                        else
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] = enemy_number;
                        }
                        Console.WriteLine("An enemy moved down");
                    }
                    else
                    {
                    }
                }
                else
                {
                    if(map.map [enemies[i].position[0] - 1,
                    enemies[i].position[1]] == 1)
                    {
                        player.HP -= enemies[i].HP;
                        Console.WriteLine($"You lost {enemies[i].HP} HP");
                    }
                    else if((map.map [enemies[i].position[0] - 1,
                    enemies[i].position[1]] == 0) || 
                    ((map.map [enemies[i].position[0] - 1,
                    enemies[i].position[1]] >= 6) && 
                    (map.map [enemies[i].position[0] - 1,
                    enemies[i].position[1]] < 9)))
                    {
                        enemy_number = map.map [enemies[i].position[0],
                        enemies[i].position[1]];

                        if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] > 9) && (enemies[i].HP == 5))
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] -= 4;
                            enemy_number = 4;
                        }
                        else if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] > 9) && (enemies[i].HP == 10))
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] -= 5;
                            enemy_number = 5;
                        }
                        else
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] = 0;
                        }

                        enemies[i].position[0] -= 1;

                        if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] >= 6) && 
                        (map.map [enemies[i].position[0],
                        enemies[i].position[1]] < 9))
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] += enemy_number;
                        }
                        else
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] = enemy_number;
                        }
                        Console.WriteLine("An enemy moved up");
                    }
                    
                }
            }
            else
            {
                if(vector[1] > 0)
                {
                    if(map.map [enemies[i].position[0],
                    enemies[i].position[1] + 1] == 1)
                    {
                        player.HP -= enemies[i].HP;
                        Console.WriteLine($"You lost {enemies[i].HP} HP");
                    }
                    else if((map.map [enemies[i].position[0],
                    enemies[i].position[1] + 1] == 0) || 
                    ((map.map [enemies[i].position[0],
                    enemies[i].position[1] + 1] >= 6) && 
                    (map.map [enemies[i].position[0],
                    enemies[i].position[1] + 1] < 9)))
                    {
                        enemy_number = map.map [enemies[i].position[0],
                        enemies[i].position[1]];

                        if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] > 9) && (enemies[i].HP == 5))
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] -= 4;
                            enemy_number = 4;
                        }
                        else if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] > 9) && (enemies[i].HP == 10))
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] -= 5;
                            enemy_number = 5;
                        }
                        else
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] = 0;
                        }

                        enemies[i].position[1] += 1;

                        if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] >= 6) && 
                        (map.map [enemies[i].position[0],
                        enemies[i].position[1]] < 9))
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] += enemy_number;
                        }
                        else
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] = enemy_number;
                        }
                        Console.WriteLine("An enemy moved right");
                    }
                }
                else
                {
                    if(map.map [enemies[i].position[0],
                    enemies[i].position[1] - 1] == 1)
                    {
                        player.HP -= enemies[i].HP;
                        Console.WriteLine($"You lost {enemies[i].HP} HP");
                    }
                    else if((map.map [enemies[i].position[0],
                    enemies[i].position[1] - 1] == 0) || 
                    ((map.map [enemies[i].position[0],
                    enemies[i].position[1] - 1] >= 6) && 
                    (map.map [enemies[i].position[0],
                    enemies[i].position[1] - 1] < 9)))
                    {
                        enemy_number = map.map [enemies[i].position[0],
                        enemies[i].position[1]];

                        if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] > 9) && (enemies[i].HP == 5))
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] -= 4;
                            enemy_number = 4;
                        }
                        else if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] > 9) && (enemies[i].HP == 10))
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] -= 5;
                            enemy_number = 5;
                        }
                        else
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] = 0;
                        }

                        enemies[i].position[1] -= 1;

                        if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] >= 6) && 
                        (map.map [enemies[i].position[0],
                        enemies[i].position[1]] < 9))
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] += enemy_number;
                        }
                        else
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] = enemy_number;
                        }
                        Console.WriteLine("An enemy moved left");
                    }
                    
                }
            }
            return enemies[i];
        }
    }
}