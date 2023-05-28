using KillZombie.LoadContent;
using KillZombie.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace KillZombie.Architecture
{
    class GameModel
    {
        public List<LevelStructure> Levels = new List<LevelStructure>();

        private int _currentLevel = 0;

        private SpriteFont mainFont;

        public LevelStructure CurrentLevel
        {
            get
            {
                return Levels[_currentLevel];
            }
            set
            {
                Levels[_currentLevel] = value;
            }
        }

        public GameModel()
        {
            Levels.Add(new Level1());
            Levels.Add(new Level2());
            mainFont = Fonts.MainFont;
        }

        public void Update()
        {
            if (_currentLevel == Levels.Count)
                return;

            CurrentLevel.Update(this);
            if (CurrentLevel.IsPassed)
                _currentLevel += 1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_currentLevel == Levels.Count)
                return;

            Levels[_currentLevel].Draw(spriteBatch);

            spriteBatch.DrawString(mainFont, $"Монеты: {CurrentLevel.Player.Coin.Score} | Пули: {CurrentLevel.Player.weapon.cage} | Здоровье: {CurrentLevel.Player.Health}", new Vector2(10, 7), Color.White);
        }
    }
}
