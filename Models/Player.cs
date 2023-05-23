using KillZombie.Architecture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KillZombie.Models
{
    class Player
    {
        public Texture2D Texture { get; set; }

        public int Health { get; set; }

        public int Armor { get; set; }

        private int speed = 10;

        private SpriteEffects effect;

        public MoveDirection Direction { get; set; }


        private Rectangle rectangle;

        public Rectangle Rectangle { 
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

        public Player(Rectangle rectangle)
        {
            Texture = Pictures.PlayerTexture;
            this.rectangle = rectangle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (Direction)
            {
                case MoveDirection.Left:
                    effect = SpriteEffects.FlipHorizontally;
                    break;

                case MoveDirection.Right:
                    effect = SpriteEffects.None;
                    break;
            }

            spriteBatch.Draw(Texture, new Vector2(X, Y), null, Color.White, 0, Vector2.Zero, 0.12f, effect, 0);
        }
        public void Move(Map world)
        {
            var keyboardState = Keyboard.GetState();
            var worldMap = world.World;

            if (IsCanMoveLeft(keyboardState, worldMap))
            { 
                Direction = MoveDirection.Left;
                X -= speed;
            }
            if (IsCanMoveRight(keyboardState, worldMap))
            { 
                Direction = MoveDirection.Right;
                X += speed;
            }
            if (IsCanMoveUp(keyboardState, worldMap))
            {
                Direction = MoveDirection.Up;
                Y -= speed;
            }
            if (IsCanMoveDown(keyboardState, worldMap))
            {
                Direction = MoveDirection.Down;
                Y += speed;
            }
        }

        private bool IsCanMoveLeft(KeyboardState keyboardState, MapCell[,] worldMap)
        {
            if (keyboardState.IsKeyDown(Keys.Left)
                && worldMap[Y / 32, (X - speed) / 32] == MapCell.Green1
                && worldMap[(Y + 25) / 32, (X - speed) / 32] == MapCell.Green1
                && worldMap[(Y + 45) / 32, (X - speed) / 32] == MapCell.Green1
                && worldMap[(Y + 65) / 32, (X - speed) / 32] == MapCell.Green1
                && worldMap[(Y + 90) / 32, (X - speed) / 32] == MapCell.Green1)
                return true;
            return false;
        }

        private bool IsCanMoveRight(KeyboardState keyboardState, MapCell[,] worldMap)
        {
            if (keyboardState.IsKeyDown(Keys.Right)
                && worldMap[Y / 32, (X + 30 + speed) / 32] == MapCell.Green1
                && worldMap[(Y + 25) / 32, (X + 60 + speed) / 32] == MapCell.Green1
                && worldMap[(Y + 45) / 32, (X + 60 + speed) / 32] == MapCell.Green1
                && worldMap[(Y + 65) / 32, (X + 30 + speed) / 32] == MapCell.Green1
                && worldMap[(Y + 90) / 32, (X + 30 + speed) / 32] == MapCell.Green1)
                return true;
            return false;
        }

        private bool IsCanMoveUp(KeyboardState keyboardState, MapCell[,] worldMap)
        {
            if (keyboardState.IsKeyDown(Keys.Up)
                && worldMap[(Y - speed) / 32, X / 32] == MapCell.Green1
                && worldMap[(Y - speed) / 32, (X + 30) / 32] == MapCell.Green1
                && worldMap[(Y - speed) / 32, (X + 58) / 32] == MapCell.Green1)
                return true;
            return false;
        }

        private bool IsCanMoveDown(KeyboardState keyboardState, MapCell[,] worldMap)
        {
            if (keyboardState.IsKeyDown(Keys.Down)
                && worldMap[(Y + 90 + speed) / 32, X / 32] == MapCell.Green1
                && worldMap[(Y + 90 + speed) / 32, (X + 30) / 32] == MapCell.Green1
                && worldMap[(Y + 90 + speed) / 32, (X + 58) / 32] == MapCell.Green1)
                return true;
            return false;
        }
    }
}
