using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Roguelike
{
    class HighScore
    {
        /// <summary>
        /// Verifies if the save folder exists, if not creates one
        /// </summary>
        /// <returns> A path for the .txt that will hold the High Scores List</returns>
        private static string GetHighScorePath()
        {
            string folder = System.IO.Directory.GetCurrentDirectory() + "\\save";
            if (Directory.Exists(folder) == false)
                Directory.CreateDirectory(folder);
            string path = folder + "\\HighScore.txt";
            return path;
        }

        //Method that fetches the list from the folder(?)

        //Method that adds the new highscore in case there are less then 10 
        //or verifies if it´s within the top 10

        //Method that saves the new higscore list(?)


    }
}
