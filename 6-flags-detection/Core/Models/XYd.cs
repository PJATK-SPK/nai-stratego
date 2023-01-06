using System.Runtime.InteropServices;

namespace Core.Models
{
    /// <summary>
    /// Coordinate structure with double type
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct XYd
    {
        public XYd(double x, double y)
        {
            X = x;
            Y = y;
        }
        public XYd(XYd xyd)
        {
            X = xyd.X;
            Y = xyd.Y;
        }
        public XYd(XY xy)
        {
            X = xy.X;
            Y = xy.Y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is XYd xy) return xy == this;
            return false;
        }
        public double GetLength(XYd another)
        {
            return Math.Sqrt(Math.Pow(another.X - X, 2) + Math.Pow(another.Y - Y, 2));
        }
        public override int GetHashCode() => HashCode.Combine(X, Y);
        public override string ToString() => $"XYd({X}, {Y})";
        public static XYd operator +(XYd a) => a;
        public static XYd operator -(XYd a) => new(-a.X, -a.Y);
        public static XYd operator +(XYd a, XYd b) => new(a.X + b.X, a.Y + b.Y);
        public static XYd operator +(XYd a, double b) => new(a.X + b, a.Y + b);
        public static XYd operator -(XYd a, XYd b) => new(a.X - b.X, a.Y - b.Y);
        public static XYd operator -(XYd a, double b) => new(a.X - b, a.Y - b);
        public static XYd operator *(XYd a, XYd b) => new(a.X * b.X, a.Y * b.Y);
        public static XYd operator *(XYd a, double b) => new(a.X * b, a.Y * b);
        public static XYd operator /(XYd a, XYd b) => new(a.X / b.X, a.Y / b.Y);
        public static XYd operator /(XYd a, double b) => new(a.X / b, a.Y / b);
        public static bool operator ==(XYd a, XYd b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(XYd a, XYd b) => a.X != b.X || a.Y != b.Y;
    }
}
