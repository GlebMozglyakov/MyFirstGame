using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KillZombies.Models
{
    class Coin
    {
        public Texture2D Texture { get; set; }

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

        public Coin(Texture2D texture, Rectangle rectangle)
        {
            Texture = texture;
            this.rectangle = rectangle;
        }

        public Coin(Texture2D texture, Rectangle rectangle, Position position)
        {
            Texture = texture;
            this.rectangle = rectangle;
            X = position.X;
            Y = position.Y;
        }

        public void SetPosition(Position position)
        {
            X = position.X;
            Y = position.Y;
        }

        public void Update(Coin coin, Map map, Player player)
        {
            if (coin.IsWasCollected)
            {
                coin.SetPosition(Position.ComputePosition(map));
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
            spriteBatch.Draw(coin.Texture, coin.Rectangle, Color.White);
        }
    }
}
