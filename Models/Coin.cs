using KillZombie.Architecture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KillZombie.Models
{
    class Coin
    {
        private Texture2D coinTexture { get; set; }

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

        private int score = 0;
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                if (value < 0)
                    score = 0;
                else
                    score = value;
            }
        }

        private bool IsWasCollected { get; set; } = false;

        public Coin()
        {
            coinTexture = Pictures.CoinTexture;
            Rectangle = new Rectangle(0, 0, 27, 27);
        }

        public Coin(GetPosition position)
        {
            coinTexture = Pictures.CoinTexture;
            Rectangle = new Rectangle(0, 0, 27, 27);
            X = position.X;
            Y = position.Y;
        }

        private void SetPosition(GetPosition position)
        {
            X = position.X;
            Y = position.Y;
        }

        public void Update(Rectangle playerRectangle, MapCell[,] mapCells)
        {
            if (IsWasCollected)
            {
                SetPosition(GetPosition.ComputePosition(mapCells));
                IsWasCollected = false;
            }

            if (playerRectangle.Intersects(Rectangle))
            {
                IsWasCollected = true;
                Score++;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(coinTexture, Rectangle, Color.White);
        }
    }
}
