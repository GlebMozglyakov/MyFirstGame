using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace KillZombies.Models
{
    class Zombie
    {
        private static Texture2D Zombie1Texture;

        private static Texture2D Zombie2Texture;

        private static Texture2D Zombie3Texture;

        private Texture2D[] Zombies;

        private Texture2D CurrentTexture;

        public List<Point> ZombiesPath;

        public int Health { get; set; }

        private int speed = 3;

        private SpriteEffects effect;

        public MoveDirection Direction { get; set; }


        private Rectangle rectangle;

        public Rectangle Rectangle
        {
            get
            {
                return rectangle;
            }
            set
            {
                rectangle = value;
            }
        }

        public int X
        {
            get
            {
                return rectangle.X;
            }
            set
            {
                rectangle.X = value;
            }
        }

        public int Y
        {
            get
            {
                return rectangle.Y;
            }
            set
            {
                rectangle.Y = value;
            }
        }

        public Zombie(ContentManager Content, Rectangle rectangle, int zombiesIndex, int[,] map, Player player)
        {
            Zombie1Texture = Content.Load<Texture2D>("zombie1");
            Zombie2Texture = Content.Load<Texture2D>("zombie2");
            Zombie3Texture = Content.Load<Texture2D>("zombie3");
            Zombies = new Texture2D[3] { Zombie1Texture, Zombie2Texture, Zombie3Texture };
            CurrentTexture = Zombies[zombiesIndex];
            //ZombiesPath = ShortestPath.FindPath(map, new Point(X / 32, Y / 32), new Point(player.X/ 32, player.Y / 32));
            this.rectangle = rectangle;
        }

        public List<Point> GetPath(Player player, int[,] map)
        {
             return ShortestPath.FindPath(map, new Point(X / 32, Y / 32), new Point(player.X / 32, player.Y / 32));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (Direction)
            {
                case MoveDirection.Left:
                    effect = SpriteEffects.None;
                    break;

                case MoveDirection.Right:
                    effect = SpriteEffects.FlipHorizontally;
                    break;
            }

            spriteBatch.Draw(CurrentTexture, new Vector2(X, Y), null, Color.White, 0, Vector2.Zero, 0.15f, effect, 0);
        }
    }
}
