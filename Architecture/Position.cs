using System;

namespace KillZombie.Models
{
    class Position
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Position ComputePosition(Borders map, MapCell[,] world)
        {
            var random = new Random();
            var position = new Position(0, 0);

            while (world[position.Y / 32, position.X / 32] != MapCell.Green1)
            {
                position = new Position(random.Next(map.Width.X1 + 40, map.Width.X2 - 40),
                                random.Next(map.Height.X1, map.Height.X2 - 120));
            }

            return position;
        }

        //private static bool IsTrue(MapCell[,] world, Position position)
        //{
        //    if (world[position.Y / 32, position.X / 32] != MapCell.Green1
        //        && world[(position.Y + 15) / 32, position.X / 32] != MapCell.Green1
        //        && world[(position.Y - 15) / 32, position.X / 32] != MapCell.Green1
        //        && world[position.Y / 32, (position.X + 15) / 32] != MapCell.Green1
        //        && world[position.Y / 32, (position.X - 15) / 32] != MapCell.Green1

        //        && world[(position.Y - 15) / 32, (position.X - 15) / 32] != MapCell.Green1
        //        && world[(position.Y + 15) / 32, (position.X - 15) / 32] != MapCell.Green1
        //        && world[(position.Y - 15) / 32, (position.X + 15) / 32] != MapCell.Green1
        //        && world[(position.Y + 15) / 32, (position.X + 15) / 32] != MapCell.Green1
        //        )
        //        return true;
        //    return false;
        //}
    }
}
