using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KillZombies.Models
{
    class Bullet
    {
        private SpriteEffects effect;

        private int speed = 10;

        public MoveDirection Direction;

        private Texture2D textureVertical;

        private Texture2D textureHorizontal;

        private Rectangle rectangle;

        private KeyboardState currentKS;

        private KeyboardState previousKS;

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

        public bool Intersected { get; set; } = false;

        public Bullet(Texture2D textureHoriz, Texture2D textureVert, Rectangle rectangle, MoveDirection direction)
        {
            textureHorizontal = textureHoriz;
            textureVertical = textureVert;
            Rectangle = rectangle;
            Direction = direction;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = null;

            switch (Direction)
            {
                case MoveDirection.Left:
                    texture = textureHorizontal;
                    effect = SpriteEffects.FlipHorizontally;
                    X -= speed;
                    break;

                case MoveDirection.Up:
                    texture = textureVertical;
                    effect = SpriteEffects.None;
                    Y -= speed;
                    break;

                case MoveDirection.Right:
                    texture = textureHorizontal;
                    effect = SpriteEffects.None;
                    X += speed;
                    break;

                case MoveDirection.Down:
                    texture = textureVertical;
                    effect = SpriteEffects.FlipVertically;
                    Y += speed;
                    break;     
            }

            spriteBatch.Draw(texture, Rectangle, null, Color.White, 0f, new Vector2(texture.Width / 2, texture.Height / 2), effect, 0f);
        }

        public bool IsOutOfScreen(Borders map)
        {
            if (X > map.Width.X2 || X < map.Width.X1 || Y > map.Height.X2 || Y < map.Height.X1 || Intersected)
                return true;

            return false;
        }
    }
}
