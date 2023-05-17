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

        public int cage = 10;
        bool CageIsEnable
        {
            get
            {
                if (cage > 0)
                    return true;
                return false;
            }
        }

        public Weapon(ContentManager Content)
        {
            bulletHorizontalTexture = Content.Load<Texture2D>("bulletHorizontal");
            bulletVerticalTexture = Content.Load<Texture2D>("bulletVertical");
        }

        public void Create(Player player, Coin coin)
        {
            currentKS = Keyboard.GetState();

            if (currentKS.IsKeyDown(Keys.Space) && previousKS.IsKeyUp(Keys.Space) && CageIsEnable)
            {
                bullets.Add(new Bullet(bulletHorizontalTexture, bulletVerticalTexture, new Rectangle(player.X + 75, player.Y + 55, 25, 25), player.Direction));

                cage--;
            }

            if (currentKS.IsKeyDown(Keys.Tab) && previousKS.IsKeyUp(Keys.Tab) && coin.Score >= 5)
            {
                cage += 10;

                coin.Score -= 5;
            }

            previousKS = currentKS;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var bullet in bullets)
                bullet.Draw(spriteBatch);
        }

        public void DeleteBullets(Borders map)
        {
            foreach (Bullet bullet in bullets.Reverse<Bullet>())
            {
                if (bullet.IsOutOfScreen(map))
                    bullets.Remove(bullet);
            }
        }
    }
}
