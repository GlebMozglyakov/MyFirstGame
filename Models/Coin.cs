using KillZombie.Architecture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KillZombie.Models
{
    class Coin
    {
        public Texture2D coinTexture { get; set; }

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

        public bool IsWasCollected { get; set; } = false;

        public Coin(Rectangle rectangle)
        {
            coinTexture = Pictures.CoinTexture;
            this.rectangle = rectangle;
        }

        public Coin(Rectangle rectangle, Position position)
        {
            coinTexture = Pictures.CoinTexture;
            this.rectangle = rectangle;
            X = position.X;
            Y = position.Y;
        }

        public void SetPosition(Position position)
        {
            X = position.X;
            Y = position.Y;
        }

        public void Update(Coin coin, Borders map, Player player, MapCell[,] world)
        {
            if (coin.IsWasCollected)
            {
                coin.SetPosition(Position.ComputePosition(map, world));
                coin.IsWasCollected = false;
            }

            if (player.Rectangle.Intersects(coin.Rectangle))
            {
                coin.IsWasCollected = true;
                Score++;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Coin coin)
        {
            spriteBatch.Draw(coin.coinTexture, coin.Rectangle, Color.White);
        }
    }
}
