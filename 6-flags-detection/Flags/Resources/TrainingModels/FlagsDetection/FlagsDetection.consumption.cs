using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.Image;
using ObjectDetector.Models;

namespace Flags.Resources.TrainingModels.FlagsDetection
{
    /// <summary>
    /// Auto-generated ML class
    /// </summary>
    internal partial class FlagsDetection
    {
        /// <summary>
        /// model input class for FlagsDetection.
        /// </summary>
        #region model input class
        internal class ModelInput
        {
            [LoadColumn(0)]
            [ColumnName(@"Label")]
            public string? Label { get; set; }

            [LoadColumn(1)]
            [ColumnName(@"ImageSource")]
            [ImageType(600, 800)]  // Must be equal with ML_WIDTH/HEIGHT
            public MLImage ImageSource { get; set; }

            public ModelInput(MLImage imageSource)
            {
                ImageSource = imageSource;
                Label = null;
            }
        }

        #endregion

        /// <summary>
        /// model output class for FlagsDetection.
        /// </summary>
        #region model output class
        internal class ModelOutput
        {
            public string[] ObjectTags = new string[] { "--bg--", "PolishFlag", "RussianFlag", "UkraineFlag", };

            [ColumnName("boxes")]
            public float[] Boxes { get; set; } = new float[0];

            [ColumnName("labels")]
            public long[] Labels { get; set; } = new long[0];

            [ColumnName("scores")]
            public float[] Scores { get; set; } = new float[0];

            public MLBoundingBox<float>[] BoundingBoxes
            {
                get
                {
                    var boundingBoxes = Enumerable.Range(0, Labels.Length)
                              .Select((index) =>
                              {
                                  return new MLBoundingBox<float>()
                                  {
                                      Left = Boxes[index * 4],
                                      Top = Boxes[(index * 4) + 1],
                                      Right = Boxes[(index * 4) + 2],
                                      Bottom = Boxes[(index * 4) + 3],
                                      Score = Scores[index],
                                      Label = ObjectTags[Labels[index]],
                                  };
                              }).ToArray();
                    return boundingBoxes;
                }
            }
        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("Resources/TrainingModels/FlagsDetection/FlagsDetection.zip");

        internal static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            var mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }
    }
}
