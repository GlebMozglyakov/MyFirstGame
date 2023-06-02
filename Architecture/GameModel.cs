using KillZombie.LoadContent;
using KillZombie.Architecture.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using KillZombie.GUI;

namespace KillZombie.Architecture
{
    class GameModel
    {
        public List<Level> Levels = new List<Level>();

        public GameState State;

        private int _currentLevelNumber = 0;

        private SpriteFont mainFont;

        private Menu _menu;

        public Level CurrentLevel
        {
            get
            {
                return Levels[_currentLevelNumber];
            }
            set
            {
                Levels[_currentLevelNumber] = value;
            }
        }

        public GameModel()
        {
            Levels.Add(new Level(1, new Vector2(1000, 500), GetLevelsInfo.MapStructureForLevel1, GetLevelsInfo.SpawnZombiesPositionsForLevel1));
            Levels.Add(new Level(2 , new Vector2(1400, 150), GetLevelsInfo.MapStructureForLevel2, GetLevelsInfo.SpawnZombiesPositionsForLevel2));
            Levels.Add(new Level(3, new Vector2(1400, 150), GetLevelsInfo.MapStructureForLevel3, GetLevelsInfo.SpawnZombiesPositionsForLevel3));
            Levels.Add(new Level(4, new Vector2(960, 450), GetLevelsInfo.MapStructureForLevel4, GetLevelsInfo.SpawnZombiesPositionsForLevel4));
            Levels.Add(new Level(5, new Vector2(1400, 500), GetLevelsInfo.MapStructureForLevel5, new Point[] {new Point (100, 500)}));
            mainFont = Fonts.MainFont;
            _menu = new Menu(this);
        }

        public void Update()
        {
            switch (State)
            {
                case GameState.End:
                    FinalScreen.Update(this);
                    return;
                case GameState.Menu:
                    _menu.Update();
                    break;
                case GameState.Tutorial:
                    TutorialScreen.Update(this); 
                    break;
                case GameState.Game:
                    CurrentLevel.Update(this);
                    if (CurrentLevel.IsPassed)
                    {
                        _currentLevelNumber += 1;
                        if (_currentLevelNumber >= Levels.Count)
                        {
                            _currentLevelNumber = 0;
                            State = GameState.End;
                            return;
                        }
                    }
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (State)
            {
                case GameState.End:
                    FinalScreen.Draw(spriteBatch);
                    break;
                case GameState.Menu:
                    _menu.Draw(spriteBatch);
                    break;
                case GameState.Tutorial:
                    TutorialScreen.Draw(spriteBatch);
                    break;
                case GameState.Game:
                    if (_currentLevelNumber == Levels.Count)
                        return;

                    Levels[_currentLevelNumber].Draw(spriteBatch);

                    spriteBatch.DrawString(mainFont, $"Монеты: {CurrentLevel.Player.Coin.Score} | Пули: {CurrentLevel.Player.weapon.cage} | Здоровье: {CurrentLevel.Player.Health}", new Vector2(10, 7), Color.White);
                    break;
            }
        }
    }
}
