namespace Roguelike
{
    /// <summary>
    /// Handles the End position
    /// </summary>
    public class Ending
    {
        public int [] position { get; set;}

        /// <summary>
        /// Generate a ending
        /// </summary>
        public Ending()
        {
            position = new int [] { 0, 0};
        }
    }
}