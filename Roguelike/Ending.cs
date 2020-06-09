namespace Roguelike
{
    public class Ending
    {
        private int rows;
        private int columns;
        public int [] position { get; set;}

        public Ending()
        {
            position = new int [] { 0, 0};
        }
    }
}