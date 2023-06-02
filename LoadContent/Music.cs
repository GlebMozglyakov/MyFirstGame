using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace KillZombie.LoadContent
{
    class Music
    {
        public static Song GameMusic;

        public static Song MenuMusic;

        public static void LoadMusic(ContentManager content)
        {
            GameMusic = content.Load<Song>(Path.Combine("Music", "game"));
            MenuMusic = content.Load<Song>(Path.Combine("Music", "menu"));
        }
    }
}
