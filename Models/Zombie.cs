using KillZombie.Architecture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace KillZombie.Models
{
    class Zombie
    {
        private static Texture2D Zombie1Texture;

        private static Texture2D Zombie2Texture;

        private static Texture2D Zombie3Texture;

        private Texture2D[] ZombiesTextures;

        private Texture2D CurrentTexture;

        public int Health { get; set; }

        private int speed = 2;

        private SpriteEffects effect;

        private MoveDirection direction { get; set; }

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
            ZombiesTextures = new Texture2D[3] { Zombie1Texture, Zombie2Texture, Zombie3Texture };
            CurrentTexture = ZombiesTextures[zombiesIndex];
            Health = 100;
            Rectangle = new Rectangle(position.X, position.Y, 60, 105);
        }

        private List<Point> GetPath(Player player, GameModel game)
        {
            var map = game.CurrentLevel.LevelMap.MapStructure;
            var zombiePosition = new Point(X / 32, Y / 32);
            var playerPosition = new Point((int)player.Position.X / 32, (int)player.Position.Y / 32);
            return ShortestPath.FindPath(map, zombiePosition, playerPosition);
        }

        private void Move(GameModel game)
        {
            var zombiesDirections = GetSteps(game.CurrentLevel.Player, game);
            var index = new Point(X / 32, Y / 32);
            var step = new Point();

            if (zombiesDirections.TryGetValue(index, out step))
            {
                X += step.X * speed;
                Y += step.Y * speed;
            }
        }

        private Dictionary<Point, Point> GetSteps(Player player, GameModel game)
        {
            var path = GetPath(player, game); 
            var zombiesDirections = new Dictionary<Point, Point>();
            if (path == null) 
                return zombiesDirections;

            for (int i = 0; i < path.Count - 1; i++)
            {
                var fromPoint = path[i];
                var toPoint = path[i + 1];
                var directionX = 0;
                var directionY = 0;

                switch (toPoint.X - fromPoint.X)
                {
                    case 1:
                        directionX = 1;
                        direction = MoveDirection.Right;
                        break;
                    case -1:
                        directionX = -1;
                        direction = MoveDirection.Left;
                        break;
                }

                switch (toPoint.Y - fromPoint.Y)
                {
                    case 1:
                        directionY = 1;
                        direction = MoveDirection.Up;
                        break;
                    case -1:
                        directionY = -1;
                        direction = MoveDirection.Down;
                        break;
                }

                zombiesDirections[fromPoint] = new Point(directionX, directionY);
            }

            return zombiesDirections;
        }

        private bool AreOtherZombiesIntersects(Zombie[] zombies)
        {
            zombies = zombies.Where(z => z != this).ToArray();
            foreach (var zombie in zombies)
                if (this.Rectangle.Intersects(zombie.Rectangle))
                    return true;
            return false;
        }

        private void EatPlayer(Player player)
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
            Move(game);
            EatPlayer(game.CurrentLevel.Player);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (direction)
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
