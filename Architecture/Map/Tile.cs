using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KillZombie.Models
{
    class Tile
    {
        public Texture2D Texture;

        public Rectangle Position;

        public Tile(Texture2D texture, Rectangle rectangle)
        {
            Texture = texture;
            Position = rectangle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
