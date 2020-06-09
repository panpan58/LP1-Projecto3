using System;

namespace Roguelike
{
    public class Map
    {
        private int rows;
        private int columns;
        private int level;
        private int[,] enemies;
        public int[,] map { get; set;}

        public Map(int rows, int columns, int level, Player player, Ending end,
        Enemy[] enemies)
        {
            this.rows = rows;
            this.columns = columns;
            this.level = level;
            map = MapCreation(player, end, enemies);
        }

        public int[,] MapCreation(Player player, Ending end, Enemy[] enemies)
        {
            // Variables
            map = new int [rows, columns];

            Random rnd = new Random();

            int x;
            int y;
            int luck;

            int nObstacles = rnd.Next(Math.Min(rows,columns)-1);

            int nEnemy = rnd.Next(((rows + columns)/2) + level);

            if(nEnemy > ((rows * columns) / 2))
            {
                nEnemy = (rows * columns) / 2;
            }

            if(((rows + columns)/2) - level <= 1)
            {
                int nPowerUPs = 1;
            }

            else
            {
                int nPowerUPs = rnd.Next(1,(((rows + columns)/2) - level));
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

            return map;
        }

        public int[,] GetMap()
        {
            return map;
        }

    }
}