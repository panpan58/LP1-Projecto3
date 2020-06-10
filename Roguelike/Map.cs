using System;

namespace Roguelike
{
    public class Map
    {
        private int rows;
        private int columns;
        private int level;

        public int[,] map { get; set;}

        public Map(int rows, int columns, int level, Player player, Ending end,
        Enemy[] enemies, PowerUp[] powerup)
        {
            this.rows = rows;
            this.columns = columns;
            this.level = level;

            map = MapCreation(player, end, enemies, powerup);
        }

        public int[,] MapCreation(Player player, Ending end, Enemy[] enemies, PowerUp[] powerup)
        {
            // Variables
            map = new int [rows, columns];

            Random rnd = new Random();

            int x;
            int y;
            int luck;

            int nObstacles = rnd.Next(Math.Min(rows,columns)-1);

            int nEnemy = rnd.Next(((rows + columns)/2) + level);

            if (nEnemy > ((rows * columns) / 2))
            {
                nEnemy = (rows * columns) / 2;
            }

            int nPowerUPs = rnd.Next(((rows + columns) / 2) + level);

            if (((rows + columns)/2) - level <= 1)
            {
                nPowerUPs = 1;
            }

            x = rnd.Next(0,rows);
            player.position[0] = x;
            map[player.position[0],0] = 1;

            x = rnd.Next(0,rows);
            end.position[0] = x;
            map[x,columns-1] = 2;

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

        public int[,] GetMap()
        {
            return map;
        }

    }
}