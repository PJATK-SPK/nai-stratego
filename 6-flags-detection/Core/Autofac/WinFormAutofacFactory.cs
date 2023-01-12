// Authors: Sandro Sobczynski, Marcel Pankanin

using Autofac;

namespace Core.Autofac
{
    public static class WinFormAutofacFactory
    {
        /// <summary>
        /// Create new Autofac IOC container with lifetime scope
        /// </summary>
        /// <param name="modules">Modules to register</param>
        public static ILifetimeScope CreateScope(IEnumerable<Module> modules)
        {
            var cb = new ContainerBuilder();
            foreach (var module in modules)
                cb.RegisterModule(module);
            return cb.Build().BeginLifetimeScope();
        }
    }
}
