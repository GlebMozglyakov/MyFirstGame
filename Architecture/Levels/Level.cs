using KillZombie.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace KillZombie.Architecture
{
    class Level
    {
        public Player Player { get; set; }

        public bool IsPassed = false;

        public Map LevelMap;

        public List<Zombie> Zombies;

        private Vector2 startPosition { get; set; }

        private Point[] spawnZombiesPositions;

        private List<Entity> entities;

        private HashSet<Entity> entityAddList;

        private HashSet<Entity> entityRemoveList;

        private List<Zombie> zombiesRemoveList = new List<Zombie>();

        private int _levelNumber;

        private int[,] mapStructure;

        public Level(int levelNumber, Vector2 startPosition, int[,] mapStructure, Point[] spawnZombiesPositions)
        {
            _levelNumber = levelNumber;
            Player = new Player();
            this.startPosition = startPosition;
            Player.Position = startPosition;
            LevelMap = new Map(mapStructure);
            entities = new List<Entity>() { Player };
            entityAddList = new HashSet<Entity>();
            entityRemoveList = new HashSet<Entity>();
            Zombies = new List<Zombie>();
            this.spawnZombiesPositions = spawnZombiesPositions;
            this.mapStructure = mapStructure;
            InitializeZombies(mapStructure);
        }

        public void RestartLevel(GameModel game)
        {
            game.CurrentLevel = new Level(_levelNumber, startPosition, mapStructure, spawnZombiesPositions);
        }

        private void InitializeZombies(int[,] mapStructure)
        {
            var zombiesCount = spawnZombiesPositions.Length;

            for (int i = 0; i < zombiesCount; i++)
            {
                var position = spawnZombiesPositions[i];
                Zombies.Add(new Zombie(position, i % 3, mapStructure));
            }
        }

        private void ZombiesUpdate(GameModel game)
        {
            foreach (var zombie in Zombies)
            {
                if (zombie.IsZombieAlive())
                    zombie.Update(game);
                else
                    zombiesRemoveList.Add(zombie);
            }

            foreach (var zombie in zombiesRemoveList)
                Zombies.Remove(zombie);
        }

        private void EntitiesUpdate(GameModel game)
        {
            entityAddList.Clear();

            foreach (var entity in entities)
                entity.Update(game);

            foreach (var entity in entityAddList)
                entities.Add(entity);
            foreach (var entity in entityRemoveList)
                entities.Remove(entity);
        }

        private void DrawTiels(SpriteBatch spriteBatch)
        {
            foreach (var tile in LevelMap.Tiles)
                tile.Draw(spriteBatch);
        }

        private void DrawEntites(SpriteBatch spriteBatch)
        {
            foreach (var entity in entities)
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

            EntitiesUpdate(game);
            ZombiesUpdate(game);

            if (Zombies.Count == 0)
                game.CurrentLevel.IsPassed = true;

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                game.State = GameState.Menu;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawTiels(spriteBatch);
            DrawEntites(spriteBatch);
            DrawZombies(spriteBatch);
        }
    }
}
