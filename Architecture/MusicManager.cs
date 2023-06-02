using KillZombie.LoadContent;
using Microsoft.Xna.Framework.Media;

namespace KillZombie.Architecture
{
    class MusicManager
    {
        private GameModel _game;

        private GameState _lastGameState;

        public MusicManager(GameModel game)
        {
            _game = game;
            _lastGameState = game.State;
        }

        public void Update()
        {
            MediaPlayer.IsRepeating = true;

            if (_game.State == _lastGameState)
                return;

            switch (_game.State)
            {
                case GameState.Game:
                    MediaPlayer.Play(Music.GameMusic);
                    break;
                case GameState.Menu:
                    MediaPlayer.Play(Music.MenuMusic);
                    break;
            }

            _lastGameState = _game.State;
        }
    }
}
