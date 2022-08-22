namespace Core
{
    public struct Coordinate : IEquatable<Coordinate>
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public override bool Equals(object? obj)
        {
            return obj is Coordinate other && Equals(other);
        }

        public bool Equals(Coordinate p)
        {
            return X == p.X && Y == p.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static bool operator ==(Coordinate lhs, Coordinate rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Coordinate lhs, Coordinate rhs)
        {
            return !(lhs == rhs);
        }
    }
}
