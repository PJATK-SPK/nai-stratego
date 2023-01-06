using System.Runtime.InteropServices;

namespace Core.Models
{
    /// <summary>
    /// Coordinate structure
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XY
    {
        public XY(int x, int y)
        {
            X = x;
            Y = y;
        }
        public XY(XY xy)
        {
            X = xy.X;
            Y = xy.Y;
        }
        public XY(XYd xyd)
        {
            X = (int)xyd.X;
            Y = (int)xyd.Y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is XY xy) return xy == this;
            return false;
        }
        public double GetLength(XY another)
        {
            return Math.Sqrt(Math.Pow(another.X - X, 2) + Math.Pow(another.Y - Y, 2));
        }
        public override int GetHashCode() => HashCode.Combine(X, Y);
        public override string ToString() => $"XY({X}, {Y})";
        public static XY operator +(XY a) => a;
        public static XY operator -(XY a) => new(-a.X, -a.Y);
        public static XY operator +(XY a, XY b) => new(a.X + b.X, a.Y + b.Y);
        public static XY operator +(XY a, int b) => new(a.X + b, a.Y + b);
        public static XY operator -(XY a, XY b) => new(a.X - b.X, a.Y - b.Y);
        public static XY operator -(XY a, int b) => new(a.X - b, a.Y - b);
        public static XY operator *(XY a, XY b) => new(a.X * b.X, a.Y * b.Y);
        public static XY operator *(XY a, int b) => new(a.X * b, a.Y * b);
        public static XY operator /(XY a, XY b) => new(a.X / b.X, a.Y / b.Y);
        public static XY operator /(XY a, int b) => new(a.X / b, a.Y / b);
        public static bool operator ==(XY a, XY b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(XY a, XY b) => a.X != b.X || a.Y != b.Y;
    }
}
