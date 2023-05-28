using KillZombie.Architecture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KillZombie.Models
{
    class Player : Entity
    {
        public Weapon weapon;

        public Coin Coin;

        private int frames;

        private SpriteEffects effect;

        public MoveDirection Direction { get; set; }

        public Player()
        {
            image = Pictures.PlayerTexture;
            Speed = 5;
            weapon = new Weapon();
            Health = 100;
            Position = new Vector2(1000, 100);
            Coin = new Coin(new GetPosition(840, 240));
        }

        public void ZombieBite()
        {
            if (frames < 33)
                return;
            Health -= 10;
            frames = 0;
        }

        public void Move(MapCell[,] mapCells, GameModel game)
        {
            var keyboardState = Keyboard.GetState();

            if (IsCanMoveLeft(keyboardState, mapCells))
            { 
                Direction = MoveDirection.Left;
                Position.X -= Speed;
            }
            if (IsCanMoveRight(keyboardState, mapCells))
            { 
                Direction = MoveDirection.Right;
                Position.X += Speed;
            }
            if (IsCanMoveUp(keyboardState, mapCells))
            {
                Direction = MoveDirection.Up;
                Position.Y -= Speed;
            }
            if (IsCanMoveDown(keyboardState, mapCells))
            {
                Direction = MoveDirection.Down;
                Position.Y += Speed;
            }
        }

        private void Shoot(GameModel game)
        {
            weapon.Update(game);
        }

        private bool IsCanMoveLeft(KeyboardState keyboardState, MapCell[,] mapCells)
        {
            if (keyboardState.IsKeyDown(Keys.Left)
                && mapCells[(int)(Position.Y / 32), (int)(Position.X - Speed) / 32] == MapCell.Green1
                && mapCells[(int)(Position.Y + 25) / 32, (int)(Position.X - Speed) / 32] == MapCell.Green1
                && mapCells[(int)(Position.Y + 45) / 32, (int)(Position.X - Speed) / 32] == MapCell.Green1
                && mapCells[(int)(Position.Y + 65) / 32, (int)(Position.X - Speed) / 32] == MapCell.Green1
                && mapCells[(int)(Position.Y + 90) / 32, (int)(Position.X - Speed) / 32] == MapCell.Green1)
                return true;
            return false;
        }

        private bool IsCanMoveRight(KeyboardState keyboardState, MapCell[,] mapCells)
        {
            if (keyboardState.IsKeyDown(Keys.Right)
                && mapCells[(int)Position.Y / 32, (int)(Position.X + 30 + Speed) / 32] == MapCell.Green1
                && mapCells[(int)(Position.Y + 25) / 32, (int)(Position.X + 60 + Speed) / 32] == MapCell.Green1
                && mapCells[(int)(Position.Y + 45) / 32, (int)(Position.X + 60 + Speed) / 32] == MapCell.Green1
                && mapCells[(int)(Position.Y + 65) / 32, (int)(Position.X + 30 + Speed) / 32] == MapCell.Green1
                && mapCells[(int)(Position.Y + 90) / 32, (int)(Position.X + 30 + Speed) / 32] == MapCell.Green1)
                return true;
            return false;
        }

        private bool IsCanMoveUp(KeyboardState keyboardState, MapCell[,] mapCells)
        {
            if (keyboardState.IsKeyDown(Keys.Up)
                && mapCells[(int)(int)(Position.Y - Speed) / 32, (int)Position.X / 32] == MapCell.Green1
                && mapCells[(int)(Position.Y - Speed) / 32, (int)(int)(Position.X + 30) / 32] == MapCell.Green1
                && mapCells[(int)(Position.Y - Speed) / 32, (int)(Position.X + 58) / 32] == MapCell.Green1)
                return true;
            return false;
        }

        private bool IsCanMoveDown(KeyboardState keyboardState, MapCell[,] mapCells)
        {
            if (keyboardState.IsKeyDown(Keys.Down)
                && mapCells[(int)(Position.Y + 90 + Speed) / 32, (int)Position.X / 32] == MapCell.Green1
                && mapCells[(int)(Position.Y + 90 + Speed) / 32, (int)(Position.X + 30) / 32] == MapCell.Green1
                && mapCells[(int)(Position.Y + 90 + Speed) / 32, (int)(Position.X + 58) / 32] == MapCell.Green1)
                return true;
            return false;
        }

        public override void Update(GameModel game)
        {
            if (this.IsAlive())
            {
                Move(game.CurrentLevel.LevelMap.MapCells, game);
                Shoot(game);
                Coin.Update(Rectangle, game.CurrentLevel.LevelMap.MapCells);
            }
            frames++;
        }

        public override void Draw(SpriteBatch spriteBatch)
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

            spriteBatch.Draw(image, Position, null, Color.White, 0, Vector2.Zero, 0.12f, effect, 0);
            weapon.Draw(spriteBatch);
            Coin.Draw(spriteBatch);
        }
    }
}
