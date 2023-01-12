// Authors: Sandro Sobczynski, Marcel Pankanin

using Autofac;
using Flags.Services.FlagsDetector;
using ObjectDetector;

namespace Flags
{
    public class FlagsModule : Module
    {
        /// <summary>
        /// Load IOC dependencies
        /// </summary>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ObjectDetectorModule>();

            builder.RegisterModule<FlagsDetectorModule>();
        }
    }
}
