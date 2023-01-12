// Authors: Sandro Sobczynski, Marcel Pankanin

using ObjectDetector.Extensions;
using ObjectDetector.Models;
using System.Drawing;

namespace ObjectDetector.Services.ObjectFinder
{
    public class ObjectFinderService
    {
        private const int ML_WIDTH = 800; // Must be equal with input attribute
        private const int ML_HEIGHT = 600;

        /// <summary>
        /// Try to find objects by given detection function and return bounding boxes
        /// </summary>
        public List<MLBoundingBox<int>> TryFindObjectBBox(Bitmap screenshot, ObjectRunner.Delegate detection)
        {
            using var image = screenshot.ToMLImage(ML_WIDTH, ML_HEIGHT);

            var bboxes = detection(image);
            var result = new List<MLBoundingBox<int>>();

            foreach (var bbox in bboxes)
            {
                try
                {
                    var fixedBbox = ConvertCoordsToImageCoords(bbox, screenshot.Width, screenshot.Height);
                    result.Add(fixedBbox);
                }
                catch { }
            }

            return result;
        }

        /// <summary>
        /// Convert input image to ML.NET size
        /// </summary>
        private MLBoundingBox<int> ConvertCoordsToImageCoords(MLBoundingBox<float> bbox, int fullWidth, int fullHeight)
        {
            return new MLBoundingBox<int>()
            {
                Left = (int)((bbox.Left / ML_WIDTH) * fullWidth),
                Right = (int)((bbox.Right / ML_WIDTH) * fullWidth),
                Top = (int)((bbox.Top / ML_HEIGHT) * fullHeight),
                Bottom = (int)((bbox.Bottom / ML_HEIGHT) * fullHeight),
                Label = bbox.Label,
                Score = (int)(bbox.Score * 100)
            };
        }
    }
}
