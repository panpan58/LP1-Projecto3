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
        /// Generate an enemy that will be
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
        /// <returns> The enemy actual position </returns>
        public Enemy EnemiesMovement(Enemy[] enemies, Player player, Map map, 
        int rows,int columns, int i, int[] vector)
        {
            //Variables
            int enemy_number;

            //Creates a vector between the player and the enemy, allowing the
            //enemy to see where the player is
            vector[0] = player.position[0] - enemies[i].position[0];
            vector[1] = player.position[1] - enemies[i].position[1];

            //This sees if the player is more farway in y
            if(Math.Abs(vector[0]) > Math.Abs(vector[1]))
            {
                //Sees if the player´s under him
                if(vector[0] > 0)
                {
                    //Sees if the enemy is next above to the player
                    if(map.map [enemies[i].position[0] + 1,
                    enemies[i].position[1]] == 1)
                    {
                        //The enemy attacks the player, reducing the player HP
                        player.HP -= enemies[i].HP;
                        Console.WriteLine($"You lost {enemies[i].HP} HP");
                    }

                    //Sees if there's no obstacles under the enemy
                    else if((map.map [enemies[i].position[0] + 1,
                    enemies[i].position[1]] == 0) || 
                    ((map.map [enemies[i].position[0] + 1,
                    enemies[i].position[1]] >= 6) && 
                    (map.map [enemies[i].position[0] + 1,
                    enemies[i].position[1]] < 9)))
                    {
                        //See at type of enemy it is
                        enemy_number = map.map [enemies[i].position[0],
                        enemies[i].position[1]];

                        //Those conditions remove the enemy from the actual case
                        //This one sees if the enemy is above an power-up and if
                        //it's a normal enemy
                        if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] > 9) && (enemies[i].HP == 5))
                        {
                            //Leave the old position with the right 
                            //power-up behind
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] -= 4;
                            enemy_number = 4;
                        }

                        //This one sees if the enemy is above an power-up and if
                        //it's a strong enemy
                        else if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] > 9) && (enemies[i].HP == 10))
                        {
                            //Leave the old position with the right 
                            //power-up behind
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] -= 5;
                            enemy_number = 5;
                        }

                        //This one sees if the enemy is in a empty case
                        else
                        {
                            //Leave the old position empty
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] = 0;
                        }

                        //Move the enemy under
                        enemies[i].position[0] += 1;

                        //Sees if the new position is occupied by power-ups 
                        if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] >= 6) && 
                        (map.map [enemies[i].position[0],
                        enemies[i].position[1]] < 9))
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] += enemy_number;
                        }

                        //If it's a normal case
                        else
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] = enemy_number;
                        }
                        Console.WriteLine("An enemy moved down");
                    }
                }

                //Sees if the player´s above him
                else
                {
                    //Sees if the enemy is next under to the player
                    if(map.map [enemies[i].position[0] - 1,
                    enemies[i].position[1]] == 1)
                    {
                        //The enemy attacks the player, reducing the player HP
                        player.HP -= enemies[i].HP;
                        Console.WriteLine($"You lost {enemies[i].HP} HP");
                    }

                    //Sees if there's no obstacles above the enemy
                    else if((map.map [enemies[i].position[0] - 1,
                    enemies[i].position[1]] == 0) || 
                    ((map.map [enemies[i].position[0] - 1,
                    enemies[i].position[1]] >= 6) && 
                    (map.map [enemies[i].position[0] - 1,
                    enemies[i].position[1]] < 9)))
                    {
                        //See at type of enemy it is
                        enemy_number = map.map [enemies[i].position[0],
                        enemies[i].position[1]];

                        //Those conditions remove the enemy from the actual case
                        //This one sees if the enemy is above an power-up and if
                        //it's a normal enemy
                        if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] > 9) && (enemies[i].HP == 5))
                        {
                            //Leave the old position with the right 
                            //power-up behind
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] -= 4;
                            enemy_number = 4;
                        }

                        //This one sees if the enemy is above an power-up and if
                        //it's a strong enemy
                        else if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] > 9) && (enemies[i].HP == 10))
                        {
                            //Leave the old position with the right 
                            //power-up behind
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] -= 5;
                            enemy_number = 5;
                        }

                        //This one sees if the enemy is in a empty case
                        else
                        {
                            //Leave the old position empty
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] = 0;
                        }

                        //Move the enemy above
                        enemies[i].position[0] -= 1;

                        //Sees if the new position is occupied by power-ups 
                        if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] >= 6) && 
                        (map.map [enemies[i].position[0],
                        enemies[i].position[1]] < 9))
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] += enemy_number;
                        }

                        //If it's a normal case
                        else
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] = enemy_number;
                        }
                        Console.WriteLine("An enemy moved up");
                    }
                    
                }
            }

            //This sees if the player is more farway in x
            else
            {
                //Sees if the player´s on his right
                if(vector[1] > 0)
                {
                    //Sees if the enemy is next left to the player
                    if(map.map [enemies[i].position[0],
                    enemies[i].position[1] + 1] == 1)
                    {
                        //The enemy attacks the player, reducing the player HP
                        player.HP -= enemies[i].HP;
                        Console.WriteLine($"You lost {enemies[i].HP} HP");
                    }

                    //Sees if there's no obstacles at the right of the enemy
                    else if((map.map [enemies[i].position[0],
                    enemies[i].position[1] + 1] == 0) || 
                    ((map.map [enemies[i].position[0],
                    enemies[i].position[1] + 1] >= 6) && 
                    (map.map [enemies[i].position[0],
                    enemies[i].position[1] + 1] < 9)))
                    {
                        //See at type of enemy it is
                        enemy_number = map.map [enemies[i].position[0],
                        enemies[i].position[1]];

                        //Those conditions remove the enemy from the actual case
                        //This one sees if the enemy is above an power-up and if
                        //it's a normal enemy
                        if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] > 9) && (enemies[i].HP == 5))
                        {
                            //Leave the old position with the right 
                            //power-up behind
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] -= 4;
                            enemy_number = 4;
                        }

                        //This one sees if the enemy is above an power-up and if
                        //it's a strong enemy
                        else if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] > 9) && (enemies[i].HP == 10))
                        {
                            //Leave the old position with the right 
                            //power-up behind
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] -= 5;
                            enemy_number = 5;
                        }

                        //This one sees if the enemy is in a empty case
                        else
                        {
                            //Leave the old position empty
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] = 0;
                        }

                        //Move the enemy to the right
                        enemies[i].position[1] += 1;

                        //Sees if the new position is occupied by power-ups 
                        if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] >= 6) && 
                        (map.map [enemies[i].position[0],
                        enemies[i].position[1]] < 9))
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] += enemy_number;
                        }

                        //If it's a normal case
                        else
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] = enemy_number;
                        }
                        Console.WriteLine("An enemy moved right");
                    }
                }

                //Sees if the player´s on his left
                else
                {
                    //Sees if the enemy is next left to the player
                    if(map.map [enemies[i].position[0],
                    enemies[i].position[1] - 1] == 1)
                    {
                        //The enemy attacks the player, reducing the player HP
                        player.HP -= enemies[i].HP;
                        Console.WriteLine($"You lost {enemies[i].HP} HP");
                    }

                    //Sees if there's no obstacles at the left of the enemy
                    else if((map.map [enemies[i].position[0],
                    enemies[i].position[1] - 1] == 0) || 
                    ((map.map [enemies[i].position[0],
                    enemies[i].position[1] - 1] >= 6) && 
                    (map.map [enemies[i].position[0],
                    enemies[i].position[1] - 1] < 9)))
                    {
                        //See at type of enemy it is
                        enemy_number = map.map [enemies[i].position[0],
                        enemies[i].position[1]];

                        //Those conditions remove the enemy from the actual case
                        //This one sees if the enemy is above an power-up and if
                        //it's a normal enemy
                        if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] > 9) && (enemies[i].HP == 5))
                        {
                            //Leave the old position with the right 
                            //power-up behind
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] -= 4;
                            enemy_number = 4;
                        }

                        //This one sees if the enemy is above an power-up and if
                        //it's a strong enemy
                        else if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] > 9) && (enemies[i].HP == 10))
                        {
                            //Leave the old position with the right 
                            //power-up behind
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] -= 5;
                            enemy_number = 5;
                        }

                        //This one sees if the enemy is in a empty case
                        else
                        {
                            //Leave the old position empty
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] = 0;
                        }

                        //Move the enemy to the left
                        enemies[i].position[1] -= 1;

                        if((map.map [enemies[i].position[0],
                        enemies[i].position[1]] >= 6) && 
                        (map.map [enemies[i].position[0],
                        enemies[i].position[1]] < 9))
                        {
                            map.map [enemies[i].position[0],
                            enemies[i].position[1]] += enemy_number;
                        }

                        //If it's normal case
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