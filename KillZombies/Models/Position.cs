using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillZombies.Models
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

        public static Position ComputePosition(Borders map)
        {
            var random = new Random();

            return new Position(random.Next(map.Width.X1 + 20, map.Width.X2 - 20), 
                                random.Next(map.Height.X1 + 20, map.Height.X2 - 20));
        }
    }
}
