using Core.Models;

namespace ObjectDetector.Models
{
    /// <summary>
    /// ML style BoundingBox
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MLBoundingBox<T> : BoundingBox<T> where T : struct
    {
        public string Label = default!;
        public T Score = default;
    }
}
