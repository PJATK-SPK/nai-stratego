namespace Core.Models
{
    /// <summary>
    /// Bounding box class (left-up position + width/height)
    /// </summary>
    public class BoundingBox<T> where T : struct
    {
        public T Top = default!;
        public T Left = default!;
        public T Right = default!;
        public T Bottom = default!;

        public T X { get => Left; }
        public T Y { get => Top; }
        public T Width { get => (dynamic)Right - (dynamic)Left; }
        public T Height { get => (dynamic)Bottom - (dynamic)Top; }
    }
}
