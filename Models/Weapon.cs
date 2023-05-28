﻿using KillZombie.Architecture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace KillZombie.Models
{
    class Weapon
    {
        private List<Bullet> bullets;

        private HashSet<Bullet> bulletsAddList;

        private HashSet<Bullet> bulletsRemoveList;

        private KeyboardState currentKS;

        private KeyboardState previousKS;

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

        public Weapon()
        {
            bullets = new List<Bullet>();
            bulletsAddList = new HashSet<Bullet>();
            bulletsRemoveList = new HashSet<Bullet>();
        }

        public void CreateBullets(GameModel game)
        {
            currentKS = Keyboard.GetState();
            var playerPosition = game.CurrentLevel.Player.Position;
            var direction = game.CurrentLevel.Player.Direction;
            var coin = game.CurrentLevel.Player.Coin;

            if (currentKS.IsKeyDown(Keys.Space) && previousKS.IsKeyUp(Keys.Space) && CageIsEnable)
            {
                bullets.Add(new Bullet(playerPosition, direction));

                cage--;
            }

            if (currentKS.IsKeyDown(Keys.Tab) && previousKS.IsKeyUp(Keys.Tab) && coin.Score >= 5)
            {
                cage += 10;

                coin.Score -= 5;
            }

            previousKS = currentKS;
        }

        public void DeleteBullets(GameModel game)
        {
            var mapCells = game.CurrentLevel.LevelMap.MapCells;
            var zombies = game.CurrentLevel.Zombies;

            foreach (var bullet in bullets.Reverse<Bullet>())
            {
                foreach (var zombie in zombies)
                    if (bullet.Rectangle.Intersects(zombie.Rectangle))
                    {
                        bullets.Remove(bullet);
                        zombie.OnHit();
                    }
                if (mapCells[(int)bullet.Y / 32, (int)bullet.X / 32] != MapCell.Green1)
                    bullets.Remove(bullet);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var bullet in bullets)
                bullet.Draw(spriteBatch);
        }

        public void Update(GameModel game)
        {
            CreateBullets(game);
            DeleteBullets(game);
        }
    }
}