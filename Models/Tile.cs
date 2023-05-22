using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KillZombies.Models
{
    class Tile
    {
        Texture2D Texture;
        Rectangle Position;

        public Tile(Texture2D texture, Rectangle rect)
        {
            this.Texture = texture;
            this.Position = rect;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
