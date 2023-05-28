using KillZombie.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace KillZombie.Architecture
{
    abstract class LevelStructure
    {
        public Player Player { get; set; }

        public Vector2 StartPosition { get; set; }

        public bool IsPassed = false;

        public List<Entity> Entities;

        public HashSet<Entity> EntityAddList;

        public HashSet<Entity> EntityRemoveList;

        public Map LevelMap;

        public List<Zombie> Zombies;

        private List<Zombie> ZombiesRemoveList = new List<Zombie>();

        public virtual void RestartLevel(GameModel game)
        {

        }

        private void ZombiesUpdate(GameModel game)
        {
            foreach (var zombie in Zombies)
            {
                if (zombie.IsZombieAlive())
                    zombie.Update(game);
                else
                    ZombiesRemoveList.Add(zombie);
            }

            foreach (var zombie in ZombiesRemoveList)
                Zombies.Remove(zombie);
        }

        private void DrawTiels(SpriteBatch spriteBatch)
        {
            foreach (var tile in LevelMap.GetTielsList())
                tile.Draw(spriteBatch);
        }

        private void DrawEntites(SpriteBatch spriteBatch)
        {
            foreach (var entity in Entities)
                entity.Draw(spriteBatch);
        }

        private void DrawZombies(SpriteBatch spriteBatch)
        {
            foreach (var zombie in Zombies)
                zombie.Draw(spriteBatch);
        }

        public void Update(GameModel game)
        {
            if (!Player.IsAlive())
                game.CurrentLevel.RestartLevel(game);

            EntityAddList.Clear();

            foreach (var entity in Entities)
                entity.Update(game);

            foreach (var entity in EntityAddList)
                Entities.Add(entity);
            foreach (var entity in EntityRemoveList)
                Entities.Remove(entity);

            ZombiesUpdate(game);

            if (Zombies.Count == 0)
                game.CurrentLevel.IsPassed = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawTiels(spriteBatch);
            DrawEntites(spriteBatch);
            DrawZombies(spriteBatch);
        }
    }  
}
