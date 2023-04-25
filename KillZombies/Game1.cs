using KillZombies.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace KillZombies
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Player player;
        Map map;
        Coin coin;
        int score = 0;
        int Score
        {
            get
            {
                return score;
            }
            set
            {
                if (value < 0)
                    score = 0;
                else
                    score += value;
            }
        }

        List<Bullet> bullets = new List<Bullet>();
        Texture2D bulletVerticalTexture;
        Texture2D bulletHorizontalTexture;

        KeyboardState currentKS;
        KeyboardState previousKS;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferHeight = (int)(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height * 0.915);
            _graphics.PreferredBackBufferWidth = (int)(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width);

            map = new Map(new Line(10, _graphics.PreferredBackBufferWidth - 10)
                , new Line(10, _graphics.PreferredBackBufferHeight - 10));
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            player = new Player(Content.Load<Texture2D>("chel"), new Rectangle(0, 0, 50, 50));
            bulletHorizontalTexture = Content.Load<Texture2D>("bulletHorizontal");
            bulletVerticalTexture = Content.Load<Texture2D>("bulletVertical");
            coin = new Coin(Content.Load<Texture2D>("coin"), new Rectangle(0, 0, 27, 27), Position.ComputePosition(map));

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            currentKS = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Move(map);

            if (coin.IsWasCollected)
            {
                coin.SetPosition(Position.ComputePosition(map));
            }

            if (player.Rectangle.Intersects(coin.Rectangle))
            {
                coin.IsWasCollected = true;
                Score++;
            }

            if (currentKS.IsKeyDown(Keys.Space) && previousKS.IsKeyUp(Keys.Space))
                bullets.Add(new Bullet(bulletHorizontalTexture, bulletVerticalTexture, new Rectangle((int)player.CurrentPosition.X + 100, (int)player.CurrentPosition.Y + 70, 25, 25), player.Direction));

            foreach (Bullet bullet in bullets.Reverse<Bullet>())
            {
                if (bullet.IsOutOfScreen(map))
                    bullets.Remove(bullet);
            }

            previousKS = currentKS;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            player.Draw(gameTime, _spriteBatch);

            foreach (var bullet in bullets)
                bullet.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}