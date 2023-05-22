using SharpDX.Direct3D9;

namespace KillZombies.Models
{
    class Borders
    {
        public Line Height { get; set; }

        public Line Width { get; set; }

        public Borders(Line width, Line height)
        {
            Height = height;
            Width = width;
        }
    }
}
