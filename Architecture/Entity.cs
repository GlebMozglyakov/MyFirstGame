using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KillZombie.Architecture
{
    abstract class Entity
    {
        protected Texture2D image;

        public Vector2 Position, Velocity;

        public float Orientation;

        public float Speed;

        public int Health;

        public Vector2 Size
        {
            get
            {
                return image == null ? Vector2.Zero : new Vector2(image.Width, image.Height);
            }
        }

        public Rectangle Rectangle
        {
            get => new Rectangle((int)Position.X, (int)Position.Y, (int)(Size.X * 0.12), (int)(Size.Y * 0.12));
        }

        public virtual bool IsAlive()
        {
            return Health > 0;
        }

        public virtual void OnExpire(GameModel game)
        {

        }

        public abstract void Update(GameModel game);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, Position, null, Color.White, Orientation, Size / 2f, 1f, 0, 0);
        }
    }
}
