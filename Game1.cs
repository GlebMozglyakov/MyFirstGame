using KillZombie.Architecture;
using KillZombie.LoadContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace KillZombie
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameModel _gameModel;
        private MusicManager _musicManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferHeight = (int)(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height * 0.915);
            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Pictures.LoadPictures(Content);
            Fonts.LoadFonts(Content);
            Music.LoadMusic(Content);
            MediaPlayer.Play(Music.MenuMusic);

            _gameModel = new GameModel();
            _musicManager = new MusicManager(_gameModel);
        }

        protected override void Update(GameTime gameTime)
        {
            _musicManager.Update();
            _gameModel.Update();

            if (_gameModel.State == GameState.Exit)
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) 
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _gameModel.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}