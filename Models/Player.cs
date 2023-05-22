using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KillZombies.Models
{
    class Player
    {
        public Texture2D Texture { get; set; }

        public int Health { get; set; }

        public int Armor { get; set; }

        private int speed = 5;

        private SpriteEffects effect;

        //public Vector2 CurrentPosition { get; set; }

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

        public Player(Texture2D texture, Rectangle rectangle)
        {
            Texture = texture;
            this.rectangle = rectangle;
            //CurrentPosition = new Vector2(X, Y);
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
        public void Move(Borders map, Map world)
        {
            var keyboardState = Keyboard.GetState();
            var worldMap = world.World;

            if (keyboardState.IsKeyDown(Keys.Left) && X > map.Width.X1 - 10 
                && world.World[(Y)/ 32, (X + 30 - speed) / 32] == MapCell.Green1 
                && world.World[(Y + 90) / 32, (X + 30 - speed) / 32] == MapCell.Green1)
            {
                //CurrentPosition = new Vector2(CurrentPosition.X - speed, CurrentPosition.Y);
                Direction = MoveDirection.Left;
                X -= speed;
            }
            if (keyboardState.IsKeyDown(Keys.Right) && X < map.Width.X2 - 80  
                && world.World[(Y)/ 32, (X + 30 + speed) / 32] == MapCell.Green1 
                && world.World[(Y + 90) / 32, (X + 30 + speed) / 32] == MapCell.Green1)
            {
                //CurrentPosition = new Vector2(CurrentPosition.X + speed, CurrentPosition.Y);
                Direction = MoveDirection.Right;
                X += speed;
            }
            if (keyboardState.IsKeyDown(Keys.Up) && Y > map.Height.X1 
                && world.World[(Y - speed) / 32, (X + 30)/ 32] == MapCell.Green1) 
                //&& world.World[(Y - speed) / 32, (X + 30 + 30) / 32] == MapCell.Green1)
            {
                //CurrentPosition = new Vector2(CurrentPosition.X, CurrentPosition.Y - speed);
                Direction = MoveDirection.Up;
                Y -= speed;
            }
            if (keyboardState.IsKeyDown(Keys.Down) && Y < map.Height.X2 - 120 
                && world.World[(Y + 90 + speed) / 32, (X + 30) / 32] == MapCell.Green1)
                //&& world.World[(Y + 90 + speed) / 32, (X + 58) / 32] == MapCell.Green1)
            {
                //CurrentPosition = new Vector2(CurrentPosition.X, CurrentPosition.Y + speed);
                Direction = MoveDirection.Down;
                Y += speed;
            }
        }
    }
}
