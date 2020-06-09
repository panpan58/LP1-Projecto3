using System;

namespace Roguelike
{
    public class Enemy
    {
        private int luck;
        public int HP { get; set;}
        public int [] position { get; set;}

        public Enemy(int luck)
        {
            position = new int [] { 0, 0};
            if(luck == 5)
            {
                HP = 10;
            }
            else
            {
                HP = 5;
            }
        }
    }
}