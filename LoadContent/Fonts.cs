using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace KillZombie.LoadContent
{
    class Fonts
    {
        public static SpriteFont MainFont;

        public static void LoadFonts(ContentManager content)
        {
            MainFont = content.Load<SpriteFont>(Path.Combine("Fonts", "mainfont"));
        }
    }
}
