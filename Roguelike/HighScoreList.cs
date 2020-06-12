using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    /// <summary>
    /// The list of HighScores and it´s Variables
    /// </summary>
    class HighScoreList
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public HighScoreList(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }
}
