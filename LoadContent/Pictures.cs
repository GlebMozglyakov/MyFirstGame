using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace KillZombie.Architecture
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

        public static Texture2D VerticalBulletTexture;

        public static Texture2D HorizontalBulletTexture;

        public static Texture2D Zombie1Texture;

        public static Texture2D Zombie2Texture;

        public static Texture2D Zombie3Texture;

        public static void LoadPictures(ContentManager content)
        {
            PlayerTexture = content.Load<Texture2D>("chel");
            CoinTexture = content.Load<Texture2D>("coin");
            BrickCellTexture = content.Load<Texture2D>("brick");
            BoxCellTexture = content.Load<Texture2D>("box");
            Green1CellTexture = content.Load<Texture2D>("green1");
            Green2CellTexture = content.Load<Texture2D>("green2");
            GreyCellTexture = content.Load<Texture2D>("grey");
            RedCellTexture = content.Load<Texture2D>("red");
            VerticalBulletTexture = content.Load<Texture2D>("bulletVertical");
            HorizontalBulletTexture = content.Load<Texture2D>("bulletHorizontal");
            Zombie1Texture = content.Load<Texture2D>("zombie1");
            Zombie2Texture = content.Load<Texture2D>("zombie2");
            Zombie3Texture = content.Load<Texture2D>("zombie3");
        }
    }
}
