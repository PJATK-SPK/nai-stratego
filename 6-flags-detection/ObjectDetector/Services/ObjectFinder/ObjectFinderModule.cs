using Autofac;
using Core.Autofac;

namespace ObjectDetector.Services.ObjectFinder
{
    public class ObjectFinderModule : Module
    {
        /// <summary>
        /// Load IOC dependencies
        /// </summary>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAsScoped<ObjectFinderService>();
            builder.RegisterAsScoped<ObjectFinderService>();
        }
    }
}
