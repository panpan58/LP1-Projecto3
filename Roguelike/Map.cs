using System;

namespace Roguelike
{
    public class Map
    {
        private int rows;
        private int columns;
        private int level;
        private int[,] map;

        public Map(int rows, int columns, int level)
        {
            this.rows = rows;
            this.columns = columns;
            this.level = level;
            map = MapCreation();
        }

        public int[,] MapCreation()
        {
            // Variables
            map = new int [rows, columns];

            Random rnd = new Random();

            int nObstacles = rnd.Next(Math.Min(rows,columns)-1);

            int nEnemy = rnd.Next(((rows + columns)/2)+level);
            if(((rows + columns)/2) - level <= 1)
            {
                int nPowerUPs = 1;
            }
            else
            {
                int nPowerUPs = rnd.Next(1,(((rows + columns)/2) - level));
            }
            
            
            map[rnd.Next(0,rows),0] = 1;

            map[rnd.Next(0,rows),columns-1] = 2;

            

            return map;
        }

        public int[,] GetMap()
        {
            return map;
        }

    }
}