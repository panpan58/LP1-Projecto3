using System;
using System.Collections.Generic;
using System.IO;

namespace Roguelike
{
    /// <summary>
    /// Contains important methods Regarding the saving and loading of the game
    /// </summary>
    class SaveGame
    {
        /// <summary>
        /// Verifies if the save folder exists, if not creates one
        /// </summary>
        /// <returns> A path for the .txt that will hold the High Scores List </returns>
        private static string GetSavedGamePath()
        {
            string folder = System.IO.Directory.GetCurrentDirectory() + "\\save";
            if (Directory.Exists(folder) == false)
                Directory.CreateDirectory(folder);
            string path = folder + "\\SavedGames.txt";
            return path;
        }

        /// <summary>
        /// Creates a list with every saved game inside the savedgames.txt
        /// </summary>
        /// <returns> The list </returns>
        private static List<SavedGamesList> GetSavedGames()
        {
            string path = GetSavedGamePath();
            List<SavedGamesList> savelist = new List<SavedGamesList>();
            if (File.Exists(path))
            {
                foreach (string line in File.ReadAllLines(path))
                {
                    string[] lineSplit = line.Split('|');
                    savelist.Add(new SavedGamesList(lineSplit[0], Convert.ToInt32(lineSplit[1]), Convert.ToInt32(lineSplit[2]), Convert.ToInt32(lineSplit[3])));
                }
            }
            return savelist;
        }

        /// <summary>
        /// Veryfies if the saved game exists
        /// </summary>
        /// <param name="name"> Game to be loaded </param>
        /// <returns> The item from the list with the saved game or null in case it doesnt exist </returns>
        public static SavedGamesList LoadGame(string name)
        {
            List<SavedGamesList> savelist = GetSavedGames();
            foreach (SavedGamesList j in savelist)
            {
                if (j.SaveName == name)
                {
                    return j;
                }
            }
            Console.WriteLine("Please choose a valid save.");
            return null;
        }

        /// <summary>
        /// Writes the list of saved Games in a text file
        /// </summary>
        /// <param name="savelist"> List containing the saves </param>
        private static void SetSavedGamesList(List<SavedGamesList> savelist)
        {
            string path = GetSavedGamePath();
            List<string> lines = new List<string>();
            foreach (SavedGamesList i in savelist)
            {
                lines.Add(i.SaveName + "|" + i.SaveScore + "|" + i.SaveRows + "|" + i.SaveColumns);
            }
            File.WriteAllLines(path, lines);
        }

        /// <summary>
        /// Saves a new gaem by adding it to the list
        /// </summary>
        public static void NewSaveGame(int score, int rows, int columns)
        {
            List<SavedGamesList> list = GetSavedGames();
            
            string name = GetName();
            list.Add(new SavedGamesList(name, score, rows, columns));
            SetSavedGamesList(list);
        }
        /// <summary>
        /// Asks for the name of the save
        /// </summary>
        /// <returns> save name </returns>
        private static string GetName()
        {
            Console.WriteLine("What name do you wish to save under?");
            return Console.ReadLine();
        }
    }
}