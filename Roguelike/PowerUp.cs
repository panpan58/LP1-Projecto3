namespace Roguelike
{
    /// <summary>
    /// Handles the creation of PowerUps
    /// </summary>
    public class PowerUp
    {
        // Variables
        public int HP { get; set; }
        public int[] position { get; set; }

        public PowerUp(int luck)
        {
            position = new int[] { 0, 0 };

            // Verifies if the PowerUp will be small
            // medium or large according to the luck
            if (luck <= 5)
            {
                HP = 4;
            }
            else if (luck <= 8)
            {
                HP = 8;
            }
            else
            {
                HP = 16;
            }
        }
    }
}