using System;

namespace Roguelike
{
    /// <summary>
    /// Handles the map generation and its properties
    /// </summary>
    public class Map
    {
        private int rows;
        private int columns;
        private int level;

        public int[,] map { get; set;}

        /// <summary>
        /// Generate a map
        /// </summary>
        public Map(int rows, int columns, int level, Player player, Ending end,
        Enemy[] enemies, PowerUp[] powerup)
        {
            this.rows = rows;
            this.columns = columns;
            this.level = level;

            map = MapCreation(player, end, enemies, powerup);
        }

        /// <summary>
        /// Handles the map generation
        /// </summary>
        /// <returns> The map </returns>
        public int[,] MapCreation(Player player, Ending end, Enemy[] enemies, 
        PowerUp[] powerup)
        {
            // Variables
            map = new int [rows, columns];

            Random rnd = new Random();

            int x;
            int y;
            int luck;
            int nObstacles;
            int nEnemy;
            int nPowerUPs;

            //Generates a random number of obstacles depending of the map size
            nObstacles = rnd.Next(Math.Min(rows,columns)-1);

            //Generates a random number of enemies depending of the map 
            //size and level
            nEnemy = rnd.Next(((rows + columns)/2) + level);

            //Conditions to not have more than half of the board with enemies
            if (nEnemy > ((rows * columns) / 2))
            {
                nEnemy = (rows * columns) / 2;
            }

            //Generates a random number of power-ups depending of the map 
            //size and level
            nPowerUPs = rnd.Next(((rows + columns) / 2) + level);

            //Condition to have a minimum of 1 power-up
            if (((rows + columns)/2) - level <= 1)
            {
                nPowerUPs = 1;
            }

            //Create the spawns of the player in the first column
            x = rnd.Next(0,rows);
            player.position[0] = x;
            map[player.position[0],0] = 1;

            //Create the spawns of the end in the last column
            x = rnd.Next(0,rows);
            end.position[0] = x;
            end.position[1] = columns-1;
            map[x,columns-1] = 2;

            //Puts the obstacles randomly in the map
            for(int i = 0; i < nObstacles;i++)
            {
                x = rnd.Next(0,rows);
                y = rnd.Next(0,columns);

                if(map[x, y] == 0)
                {
                    map[x, y] = 3;
                }
                else
                {
                    i--;
                }
            }

            //Puts the enemies randomly in the map
            for(int i = 0; i < nEnemy;i++)
            {
                x = rnd.Next(0,rows);
                y = rnd.Next(0,columns);

                if(map[x, y] == 0)
                {
                    luck = rnd.Next(0,6);
                    enemies[i] = new Enemy(luck);
                    enemies[i].position[0] = x;
                    enemies[i].position[1] = y;

                    //Conditions to see if the enemy is normal or strong
                    if(enemies[i].HP == 5)
                    {
                        map[x, y] = 4;
                    }
                    else
                    {
                        map[x, y] = 5;
                    }
                }
                else
                {
                    i--;
                }
            }

            //Puts the power-ups randomly in the map
            for(int i = 0; i < nPowerUPs; i++)
            {
                x = rnd.Next(0, rows);
                y = rnd.Next(0, columns);

                if(map[x, y] == 0)
                {
                    luck = rnd.Next(0, 9);
                    powerup[i] = new PowerUp(luck);
                    powerup[i].position[0] = x;
                    powerup[i].position[1] = y;

                    //Conditions to see if the power-up is small, medium or big
                    if(powerup[i].HP == 4)
                    {
                        map[x, y] = 6;
                    }
                    else if(powerup[i].HP == 8)
                    {
                        map[x, y] = 7;
                    }
                    else
                    {
                        map[x, y] = 8;
                    }
                }
                
            }

            return map;
        }
    }
}