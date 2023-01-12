// Authors: Sandro Sobczynski, Marcel Pankanin

using Autofac;
using ObjectDetector.Services.ObjectFinder;

namespace ObjectDetector
{
    public class ObjectDetectorModule : Module
    {
        /// </summary>

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ObjectFinderModule>();
        }
    }
}
