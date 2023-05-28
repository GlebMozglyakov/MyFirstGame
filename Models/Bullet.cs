using KillZombie.Architecture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KillZombie.Models
{
    class Bullet
    {
        private SpriteEffects effect;

        public MoveDirection Direction;

        private Texture2D textureVertical;

        private Texture2D textureHorizontal;

        private int speed = 10;

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

        public Bullet(Vector2 playerPosition, MoveDirection direction)
        {
            textureHorizontal = Pictures.HorizontalBulletTexture;
            textureVertical = Pictures.VerticalBulletTexture;
            Direction = direction;
            Rectangle = new Rectangle((int)playerPosition.X + 60, (int)playerPosition.Y + 40, 25, 25);
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

        public bool IsOutOfScreen()
        {
            if (X > 10 || X < 1900 || Y > 0 || Y < 1050 || Intersected)
                return true;

            return false;
        }
    }
}
