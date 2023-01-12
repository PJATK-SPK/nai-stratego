// Authors: Sandro Sobczynski, Marcel Pankanin

using Autofac;
using System.Diagnostics.CodeAnalysis;

namespace Core.Autofac
{
    public static class ContainerBuilderExtensions
    {
        /// <summary>
        /// Shortcut function for lifetime scope registration
        /// </summary>
        public static void RegisterAsScoped
          <[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementer>
          (this ContainerBuilder cb) where TImplementer : notnull
        {
            if (cb.Properties.ContainsKey(typeof(TImplementer).AssemblyQualifiedName!))
                return;

            cb.Properties.Add(typeof(TImplementer).AssemblyQualifiedName!, null);

            cb.RegisterType<TImplementer>().AsSelf().AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
