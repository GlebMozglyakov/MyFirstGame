using KillZombie.Architecture;
using KillZombie.LoadContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace KillZombie.GUI
{
    class Menu
    {
        private List<MenuItem> menuItems;

        private int _currentMenuItem;

        private KeyboardState _oldKeyboardState;

        private GameModel _game;

        public Menu(GameModel game)
        {
            InitializeMenu();
            _game = game;
        }

        private void InitializeMenu()
        {
            menuItems = new List<MenuItem>();
            var newGame = new MenuItem("Новая игра");
            var resumeGame = new MenuItem("Продолжить");
            var exitGame = new MenuItem("Выход");

            resumeGame.Active = false;

            newGame.Click += new EventHandler(newGame_Click);
            resumeGame.Click += new EventHandler(resumeGame_Click);
            exitGame.Click += new EventHandler(exitGame_Click);

            menuItems.Add(newGame);
            menuItems.Add(resumeGame);
            menuItems.Add(exitGame);
        }

        private void newGame_Click(object sender, EventArgs even)
        {
            menuItems[1].Active = true;
            _game.State = GameState.Tutorial;
        }

        private void resumeGame_Click(object sender, EventArgs even)
        {
            _game.State = GameState.Game;
        }

        private void exitGame_Click(object sender, EventArgs even)
        {
            _game.State = GameState.Exit;
        }

        private void MoveMenuSlider()
        {
            var currentKeyboardState = Keyboard.GetState();

            if (currentKeyboardState.IsKeyDown(Keys.Enter))
                menuItems[_currentMenuItem].OnClick();

            var delta = 0;
            if (currentKeyboardState.IsKeyDown(Keys.Up) && _oldKeyboardState.IsKeyUp(Keys.Up))
                delta = -1;
            if (currentKeyboardState.IsKeyDown(Keys.Down) && _oldKeyboardState.IsKeyUp(Keys.Down))
                delta = 1;

            _currentMenuItem += delta;
            var ok = false;
            while (!ok)
            {
                if (_currentMenuItem < 0)
                    _currentMenuItem = menuItems.Count - 1;
                else if (_currentMenuItem > menuItems.Count - 1)
                    _currentMenuItem = 0;
                else if (menuItems[_currentMenuItem].Active == false)
                    _currentMenuItem += delta;
                else ok = true;
            }

            _oldKeyboardState = currentKeyboardState;
        }

        public void Update()
        {
            MoveMenuSlider();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Pictures.BackgroundMenu, new Rectangle(0, 0, 1920, 1080), Color.White);
            var y = 380;
            foreach (var menuItem in menuItems)
            {
                var color = Color.White;
                if (!menuItem.Active)
                    color = Color.Gray;
                if (menuItem == menuItems[_currentMenuItem])
                    color = Color.Red;
                spriteBatch.DrawString(Fonts.MenuFont, menuItem.Name, new Vector2(800, y), color);
                y += 220;
            }
        }
    }
}
