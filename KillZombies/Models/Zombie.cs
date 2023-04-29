using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KillZombies.Models
{
    class Zombie
    {
        public Texture2D Texture { get; set; }

        public int Health { get; set; }

        private int speed = 20;

        private SpriteEffects effect;

        public Vector2 CurrentPosition { get; set; }

        public MoveDirection Direction { get; set; }


        private Rectangle rectangle;

        public Rectangle Rectangle
        {
            get
            {
                return rectangle;
            }
            set
            {
                rectangle = value;
            }
        }

        public int X
        {
            get
            {
                return rectangle.X;
            }
            set
            {
                rectangle.X = value;
            }
        }

        public int Y
        {
            get
            {
                return rectangle.Y;
            }
            set
            {
                rectangle.Y = value;
            }
        }

        public Zombie(Texture2D texture, Rectangle rectangle)
        {
            Texture = texture;
            this.rectangle = rectangle;
        }

        public void Move()
        {

        }
    }
}
