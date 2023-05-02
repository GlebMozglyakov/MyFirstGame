using KillZombies.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KillZombies
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Player player;
        Borders map;
        Coin coin;
        SpriteFont mainFont;
        Weapon weapon;
        Map world;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferHeight = (int)(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height * 0.915);
            _graphics.PreferredBackBufferWidth = (int)(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width);

            map = new Borders(new Line(10, _graphics.PreferredBackBufferWidth - 10)
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

            // TODO: use this.Content to load your game content here
            player = new Player(Content.Load<Texture2D>("chel"), new Rectangle(0, 0, 70, 145));
            coin = new Coin(Content.Load<Texture2D>("coin"), new Rectangle(0, 0, 27, 27), Position.ComputePosition(map));
            mainFont = Content.Load<SpriteFont>("myfont");
            weapon = new Weapon(Content);
            world = new Map(Level1.CreateWorld(), Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Move(map, world);
            coin.Update(coin, map, player);
            weapon.Create(player, coin);
            weapon.DeleteBullets(map);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) 
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            foreach (var tile in world.CreateWorld())
                tile.Draw(_spriteBatch);

            _spriteBatch.DrawString(mainFont, $"Coins: {coin.Score} | Cage: {weapon.cage}", new Vector2(10, 7), Color.White);
            player.Draw(_spriteBatch);
            coin.Draw(_spriteBatch, coin);
            weapon.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}