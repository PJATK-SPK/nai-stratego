using Microsoft.ML.Data;
using ObjectDetector.Models;

namespace ObjectDetector.Services.ObjectFinder
{
    public static class ObjectRunner
    {
        /// <summary>
        /// Delegate for detecting objects from ML.NET
        /// </summary>
        public delegate MLBoundingBox<float>[] Delegate(MLImage image);
    }
}
