using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace KillZombies.Models
{
    class Weapon
    {
        private List<Bullet> bullets = new List<Bullet>();
        
        private KeyboardState currentKS;

        private KeyboardState previousKS;

        private Texture2D bulletHorizontalTexture;

        private Texture2D bulletVerticalTexture;

        public Weapon(ContentManager Content)
        {
            bulletHorizontalTexture = Content.Load<Texture2D>("bulletHorizontal");
            bulletVerticalTexture = Content.Load<Texture2D>("bulletVertical");
        }

        public void Create(Player player)
        {
            currentKS = Keyboard.GetState();

            if (currentKS.IsKeyDown(Keys.Space) && previousKS.IsKeyUp(Keys.Space))
                bullets.Add(new Bullet(bulletHorizontalTexture, bulletVerticalTexture, new Rectangle((int)player.CurrentPosition.X + 100, (int)player.CurrentPosition.Y + 70, 25, 25), player.Direction));

            previousKS = currentKS;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var bullet in bullets)
                bullet.Draw(spriteBatch);
        }

        public void DeleteBullets(Map map)
        {
            foreach (Bullet bullet in bullets.Reverse<Bullet>())
            {
                if (bullet.IsOutOfScreen(map))
                    bullets.Remove(bullet);
            }
        }
    }
}
