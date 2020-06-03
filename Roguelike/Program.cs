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
            int colums;
            int rows;

            if (args.Length < 2)
            {
                Console.WriteLine("Run a Program with -r and -c arguments followed by a the number you want\n (-r for Rows and -c for Colums");
                return;
            }
            else if (args [0] == "-r")
            {
                rows = Convert.ToInt32(args[1]);
                colums = Convert.ToInt32(args[3]);
                Console.WriteLine(rows);
            }
            else if (args [0] == "-c")
            {
                rows = Convert.ToInt32(args[3]);
                colums = Convert.ToInt32(args[1]);
                Console.WriteLine(rows);
            }
        }
    }
}
