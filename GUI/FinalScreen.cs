using KillZombie.Architecture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KillZombie.GUI
{
    static class FinalScreen
    {
        public static void Update(GameModel game)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                game.State = GameState.Menu;
                game.CurrentLevel.RestartLevel(game);
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Pictures.FinalBackground, new Rectangle(0, 0, 1920, 1000), Color.White);
        }
    }
}
