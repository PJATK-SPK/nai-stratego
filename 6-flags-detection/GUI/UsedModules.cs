// Authors: Sandro Sobczynski, Marcel Pankanin

using Autofac;
using Flags;

public static class UsedModules
{
    /// <summary>
    /// IOC modules to load
    /// </summary>
    public static readonly IEnumerable<Module> List = new List<Module>()
    {
        new FlagsModule()
    };
}