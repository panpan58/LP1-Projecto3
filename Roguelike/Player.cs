namespace Roguelike
{
    public class Player
    {
        private int rows;
        private int columns;
        public int [] position { get; set;}
        private int HP { get; set;}

        public Player(int rows, int columns)
        {
            position = new int [] { 0, 0};
            HP = rows * columns / 4;
        }

        public Player PlayerMovement(Player player)
        {
            return player;
        }
    }
}