namespace Roguelike
{
    /// <summary>
    /// List of the saved games and their Variables
    /// </summary>
    class SavedGamesList
    {
        public string SaveName { get; set; }
        public int SaveScore { get; set; }
        public int SaveRows { get; set; }
        public int SaveColumns { get; set; }
        public SavedGamesList(string name, int score, int rows, int columns)
        {
            SaveName = name;
            SaveScore = score;
            SaveRows = rows;
            SaveColumns = columns;
        }
    }
}
