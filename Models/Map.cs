using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillZombies.Models
{
    class Map
    {
        public Line Height { get; set; }

        public Line Width { get; set; }

        public Map(Line width, Line height)
        {
            Width = width;
            Height = height;
        }
    }
}
