using System;

namespace KillZombie.Models
{
    class GetPosition
    {
        public int X { get; set; }

        public int Y { get; set; }

        public GetPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static GetPosition ComputePosition(MapCell[,] world)
        {
            var random = new Random();
            var position = new GetPosition(0, 0);

            while (world[position.Y / 32, position.X / 32] != MapCell.Green1)
            {
                position = new GetPosition(random.Next(80, 1850),
                                random.Next(80, 940));
            }

            return position;
        }
    }
}
