using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace KillZombies.Architecture
{
    class Pictures
    {
        public static Texture2D PlayerTexture;

        public static Texture2D CoinTexture;

        public static Texture2D BrickCellTexture;

        public static Texture2D BoxCellTexture;

        public static Texture2D Green1CellTexture;

        public static Texture2D Green2CellTexture;

        public static Texture2D GreyCellTexture;

        public static Texture2D RedCellTexture;

        public static SpriteFont Font;

        public static void Load(ContentManager content)
        {
            PlayerTexture = content.Load<Texture2D>("chel");
            CoinTexture = content.Load<Texture2D>("coin");
            BrickCellTexture = content.Load<Texture2D>("brick");
            BoxCellTexture = content.Load<Texture2D>("box");
            Green1CellTexture = content.Load<Texture2D>("green1");
            Green2CellTexture = content.Load<Texture2D>("green2");
            GreyCellTexture = content.Load<Texture2D>("grey");
            RedCellTexture = content.Load<Texture2D>("red");

            Font = content.Load<SpriteFont>("myfont");
        }
    }
}
