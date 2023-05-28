using KillZombie.Architecture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Reflection;

namespace KillZombie.Models
{
    class Zombie
    {
        private static Texture2D Zombie1Texture;

        private static Texture2D Zombie2Texture;

        private static Texture2D Zombie3Texture;

        private Texture2D[] Zombies;

        private Texture2D CurrentTexture;

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

        public Zombie(Point position,int zombiesIndex, int[,] map)
        {
            Zombie1Texture = Pictures.Zombie1Texture;
            Zombie2Texture = Pictures.Zombie2Texture;
            Zombie3Texture = Pictures.Zombie3Texture;
            Zombies = new Texture2D[3] { Zombie1Texture, Zombie2Texture, Zombie3Texture };
            CurrentTexture = Zombies[zombiesIndex];
            Health = 100;
            Rectangle = new Rectangle(position.X, position.Y, 60, 105);
        }

        public List<Pointt> GetPath(Player player, int[,] map)
        {
             return ShortestPath.FindPath(map, new Pointt(X / 32, Y / 32), new Pointt((int)player.Position.X / 32, (int)player.Position.Y / 32));
        }

        public void Move(Player player, int[,] map)
        {
            var zombiesSteps = GetSteps(player, map);
            var index = new Pointt(X / 32, Y / 32);
            var step = new Pointt();

            if (zombiesSteps.TryGetValue(index, out step))
            {
                X += step.X * 2;
                Y += step.Y * 2;
            }
        }

        private Dictionary<Pointt, Pointt> GetSteps(Player player, int[,] map)
        {
            var path = GetPath(player, map); 
            var dict = new Dictionary<Pointt, Pointt>();
            if (path == null)
                return dict;

            for (int i = 0; i < path.Count - 1; i++)
            {
                var fromPoint = path[i];
                var toPoint = path[i + 1];
                var dirX = 0;
                var dirY = 0;

                if (toPoint.X - fromPoint.X == 1)
                {
                    dirX = 1;
                    Direction = MoveDirection.Right;
                }
                else if (toPoint.X - fromPoint.X == -1)
                {
                    dirX = -1;
                    Direction = MoveDirection.Left;
                }
                if (toPoint.Y -  fromPoint.Y == 1)
                    dirY = 1;
                else if (toPoint.Y - fromPoint.Y == -1)
                    dirY = -1;
                dict[fromPoint] = new Pointt(dirX, dirY);
            }

            return dict;
        }

        public void EatPlayer(Player player)
        {
            if (this.rectangle.Intersects(player.Rectangle))
            {
                player.ZombieBite();
            }
        }

        public void OnHit()
        {
            Health -= 10;
        }

        public bool IsZombieAlive()
        {
            if (Health > 0)
                return true;
            return false;
        }

        public void Update(GameModel game)
        {
            Move(game.CurrentLevel.Player, game.CurrentLevel.LevelMap.MapStructure);
            EatPlayer(game.CurrentLevel.Player);
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

            spriteBatch.Draw(CurrentTexture, new Vector2(X, Y), null, Color.White, 0, Vector2.Zero, 0.12f, effect, 0);
        }
    }
}
