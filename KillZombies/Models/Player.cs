using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KillZombies.Models
{
    class Player
    {
        public Texture2D Texture { get; set; }

        public int Health { get; set; }

        public int Armor { get; set; }

        private int speed = 20;

        private SpriteEffects effect;

        public Vector2 CurrentPosition { get; set; }

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
            CurrentPosition = new Vector2(130, 130);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
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

            //spriteBatch.Draw(Texture, CurrentPosition, Color.White);
            spriteBatch.Draw(Texture, CurrentPosition, null, Color.White, 0, Vector2.Zero, 0.2f, effect, 0);
        }
        public void Move(Map map)
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Left) && CurrentPosition.X > map.Width.X1 - 10)
            {
                CurrentPosition = new Vector2(CurrentPosition.X - speed, CurrentPosition.Y);
                Direction = MoveDirection.Left;
            }
            if (keyboardState.IsKeyDown(Keys.Right) && CurrentPosition.X < map.Width.X2 - 80)
            {
                CurrentPosition = new Vector2(CurrentPosition.X + speed, CurrentPosition.Y);
                Direction = MoveDirection.Right;
            }
            if (keyboardState.IsKeyDown(Keys.Up) && CurrentPosition.Y > map.Height.X1)
            {
                CurrentPosition = new Vector2(CurrentPosition.X, CurrentPosition.Y - speed);
                Direction = MoveDirection.Up;
            }
            if (keyboardState.IsKeyDown(Keys.Down) && CurrentPosition.Y < map.Height.X2 - 155)
            {
                CurrentPosition = new Vector2(CurrentPosition.X, CurrentPosition.Y + speed);
                Direction = MoveDirection.Down;
            }
        }
    }
}
