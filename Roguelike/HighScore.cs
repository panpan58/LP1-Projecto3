using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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

        /// <summary>
        /// Orders the scores in the highs score Writes the list of highscores in a .txt files
        /// </summary>
        /// <param name="list"> The list of High Scores </param>
        private static void SetHighScoreList(List<HighScoreList> list)
        {
            string path = GetHighScorePath();
            List<string> lines = new List<string>();
            foreach (HighScoreList index in list.OrderByDescending(a => a.Score))
            {
                lines.Add(index.Name + "|" + index.Score);
            }
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
            if (File.Exists(path))
            {
                foreach (string line in File.ReadAllLines(path))
                {
                    string[] lineSplit = line.Split('|');
                    list.Add(new HighScoreList(lineSplit[0], Convert.ToInt32(lineSplit[1])));
                }
            }
            return list;
        }

        /// <summary>
        /// Adds the new score in case: there are less then 10 or it´s in the top 10
        /// </summary>
        /// <param name="status">the new score</param>
        public static void AddToHighScoreList(HighScoreList status)
        {
            List<HighScoreList> list = GetHighScoreList();
            if(list.Count < 10)
            {
                status.Name = GetPlayerName(status.Score);
                list.Add(status);
            }
            else
            {
                HighScoreList minScore = list.Last();
                if(minScore.Score < status.Score)
                {
                    list.Remove(minScore);
                    status.Name = GetPlayerName(status.Score);
                    list.Add(status);
                }
            }
            SetHighScoreList(list);
        }

        private static string GetPlayerName(int score)
        {
            Console.WriteLine("Your Score is within the top 10!");
            Console.WriteLine("What name do you want to save with the HighScore?");
            string name = Console.ReadLine();
            Console.WriteLine("Congratulations on " + name + " for getting a score of " + score + "!");
            return name;
        }

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
