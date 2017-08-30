using System.Reflection;
using System.Runtime.Loader;

namespace CoreUtilities
{
    public sealed class LoadContextUtility : AssemblyLoadContext
    {
        protected override Assembly Load(AssemblyName assemblyName)
        {
            return Assembly.Load(assemblyName);
        }
    }
}
