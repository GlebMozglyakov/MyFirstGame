using KillZombie.Architecture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KillZombie.GUI
{
    static class TutorialScreen
    {
        public static void Update(GameModel game)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                game.CurrentLevel.RestartLevel(game);
                game.State = GameState.Game;
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Pictures.TutorialScreen, new Rectangle(0, 0, 1920, 1000), Color.White);
        }
    }
}
