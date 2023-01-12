// Authors: Sandro Sobczynski, Marcel Pankanin

using Core.Extensions;
using ObjectDetector.Services.ObjectFinder;
using System.Drawing;

namespace Flags.Services.FlagsDetector
{
    public class FlagsDetectorService
    {
        private readonly FlagsDetectionRunner _flagsDetection;
        private readonly ObjectFinderService _objectFinder;

        public FlagsDetectorService(FlagsDetectionRunner flagsDetection, ObjectFinderService objectFinder)
        {
            _flagsDetection = flagsDetection;
            _objectFinder = objectFinder;
        }

        /// <summary>
        /// Detect flag and draw bounding box on given picture
        /// </summary>
        public Bitmap Detect(Image source)
        {
            var result = new Bitmap(source);

            var rnd = new Random();

            try
            {
                var bboxes = _objectFinder.TryFindObjectBBox(result, _flagsDetection.DetectFlags);
                var bestMatch = bboxes.OrderByDescending(c => c.Score).FirstOrDefault();

                if (bestMatch != null)
                {
                    var name = $"{bestMatch.Label} - {bestMatch.Score}%";
                    var position = $"{bestMatch.X}:{bestMatch.Y}-{bestMatch.X + bestMatch.Width}:{bestMatch.Y + bestMatch.Height}";
                    result.DrawBBox(bestMatch, Color.Red, $"{name} | {position}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
    }
}
