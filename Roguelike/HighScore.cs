using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Roguelike
{
    /// <summary>
    /// Creates a list and creates a .txt file to hold the HighScores,
    /// Adds and removes HighScores according to their Values
    /// </summary>
    class HighScore
    {
        /// <summary>
        /// Verifies if the save folder exists, if not creates one
        /// </summary>
        /// <returns> A path for the .txt that will hold the 
        /// High Scores List</returns>
        private static string GetHighScorePath()
        {
            // Start of the path to later verification of the folder
            string folder = System.IO.Directory.GetCurrentDirectory() + 
            "\\save";
            // Verifies if the folder already exists if not, creates it
            if (Directory.Exists(folder) == false)
                Directory.CreateDirectory(folder);
            // Adress for the HighScores File
            string path = folder + "\\HighScore.txt";
            return path;
        }

        /// <summary>
        /// Orders the scores in the highs score Writes the list of 
        /// highscores in a .txt files
        /// </summary>
        /// <param name="list"> The list of High Scores </param>
        private static void SetHighScoreList(List<HighScoreList> list)
        {
            string path = GetHighScorePath();
            List<string> lines = new List<string>();

            // Orders the List and adds the Scores to a new equal list
            // but of strings
            foreach (HighScoreList index in 
            list.OrderByDescending(a => a.Score))
            {
                lines.Add(index.Name + "|" + index.Score); // Name|Score
            }
            // Saves all Highscores as single lines
            File.WriteAllLines(path, lines);
        }

        /// <summary>
        /// Creates a list with everything inside the HighScore.text file
        /// </summary>
        /// <returns> The list </returns>
        private static List<HighScoreList> GetHighScoreList()
        {
            string path = GetHighScorePath();
            List<HighScoreList> list = new List<HighScoreList>();

            // Ignores the code in case the HighScore.txt file does 
            // not exist
            if (File.Exists(path))
            {
                // Retrieves the List inside the .txt file
                foreach (string line in File.ReadAllLines(path))
                {
                    string[] lineSplit = line.Split('|');
                    list.Add(new HighScoreList(lineSplit[0], 
                    Convert.ToInt32(lineSplit[1])));
                }
            }
            return list;
        }

        /// <summary>
        /// Adds the new score in case: there are less then 10 
        /// or it´s in the top 10
        /// </summary>
        /// <param name="status">the new score</param>
        public static void AddToHighScoreList(HighScoreList status)
        {
            List<HighScoreList> list = GetHighScoreList();
            // If there are less then 10 Scores adds the new ones 
            if(list.Count < 10)
            {
                status.Name = GetPlayerName(status.Score);
                list.Add(status);
            }
            else
            {
                // Defines the last score from the top10
                HighScoreList minScore = list.Last();
                // Verifies if the last score is smaller than the new one
                if(minScore.Score < status.Score)
                {
                    // Removes the last score
                    list.Remove(minScore);
                    // Retrieves the player name
                    status.Name = GetPlayerName(status.Score);
                    // Adds the new Champion to the list
                    list.Add(status);
                }
            }
            SetHighScoreList(list);
        }

        /// <summary>
        /// Retrieves the name of the player that got in the top10
        /// </summary>
        /// <param name="score"></param>
        /// <returns> The name</returns>
        private static string GetPlayerName(int score)
        {
            Console.WriteLine("Your Score is within the top 10!");
            Console.WriteLine(
            "What name do you want to save with the HighScore?");
            string name = Console.ReadLine();
            Console.WriteLine("Congratulations on " + name + 
            " for getting a score of " + score + "!");
            return name;
        }

        /// <summary>
        /// Prints the List of HighScores
        /// </summary>
        public static void PrintHighScoreList()
        {
            List<HighScoreList> list = GetHighScoreList();
            foreach (HighScoreList index in list)
            {
                Console.WriteLine(index.Name + " | "+index.Score);
            }
        }
    }
}
