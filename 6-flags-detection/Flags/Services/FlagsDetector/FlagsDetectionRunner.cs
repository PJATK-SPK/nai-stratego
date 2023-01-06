using Flags.Resources.TrainingModels.FlagsDetection;
using Microsoft.ML.Data;
using ObjectDetector.Models;

namespace Flags.Services.FlagsDetector
{
    public class FlagsDetectionRunner
    {
        public FlagsDetectionRunner() { }

        /// <summary>
        /// Find flags and return picture coordinates
        /// </summary>
        public MLBoundingBox<float>[] DetectFlags(MLImage image)
        {
            var payload = new FlagsDetection.ModelInput(image);
            var engine = FlagsDetection.CreatePredictEngine();
            var result = engine.Predict(payload);
            return result.BoundingBoxes;
        }
    }
}
