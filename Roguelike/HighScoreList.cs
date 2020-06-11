using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
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
