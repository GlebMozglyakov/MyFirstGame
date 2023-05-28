namespace KillZombie.Models
{
    public readonly struct Pointt
    {
        public int X { get; }
        public int Y { get; }

        public Pointt(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Pointt point, Pointt other) => point.X == other.X && point.Y == other.Y;
        public static bool operator !=(Pointt point, Pointt other) => point.X != other.X || point.Y != other.Y;
        public static Pointt operator +(Pointt point, Pointt other) => new(point.X + other.X, point.Y + other.Y);
        public static Pointt operator -(Pointt point, Pointt other) => new(point.X - other.X, point.Y - other.Y);

        public override int GetHashCode()
            => X * Y + X;

        public override string ToString()
            => $"x: {X}; y: {Y};";

        public bool Equals(Pointt other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object? obj)
        {
            return obj is Pointt other && Equals(other);
        }
    }
}
