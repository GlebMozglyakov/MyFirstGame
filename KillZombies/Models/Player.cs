using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KillZombies.Models
{
    class Player
    {
        public Texture2D Texture { get; set; }

        public int Health { get; set; }

        public int Armor { get; set; }

        public Point CurrentPosition { get; }

        public MoveDirection Direction { get; set; }

        private Rectangle rectangle;

        public Rectangle Rectangle { 
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

        public Player()
        {

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, rectangle, Color.White);
        }


    }
}
