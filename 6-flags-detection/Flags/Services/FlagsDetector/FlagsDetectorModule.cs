// Authors: Sandro Sobczynski, Marcel Pankanin

using Autofac;
using Core.Autofac;

namespace Flags.Services.FlagsDetector
{
    public class FlagsDetectorModule : Module
    {
        /// <summary>
        /// Load IOC dependencies
        /// </summary>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAsScoped<FlagsDetectorService>();
            builder.RegisterAsScoped<FlagsDetectionRunner>();
        }
    }
}
