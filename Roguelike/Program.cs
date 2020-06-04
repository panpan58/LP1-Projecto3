using System;

/// <summary>
/// 
/// </summary>
namespace Roguelike
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Variables
            int columns;
            int rows;
            int level;
            Map map;

            if (args [0] == "-r")
            {
                rows = Convert.ToInt32(args[1]);
                columns = Convert.ToInt32(args[3]);
            }
            else if (args [0] == "-c")
            {
                rows = Convert.ToInt32(args[3]);
                columns = Convert.ToInt32(args[1]);
            }
            else
            {
                Console.Write(
                "Run a Program with -r and -c arguments followed");
                Console.Write(
                "by a the number you want\n (-r for Rows and -c for Columns");
                return;
            }

            level = 1;

            map = new Map(rows, columns, level);
        }
    }
}
