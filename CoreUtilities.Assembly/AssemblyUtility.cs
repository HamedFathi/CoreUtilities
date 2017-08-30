using Microsoft.Extensions.DependencyModel;
using System.Collections.Generic;
using System.Linq;

namespace CoreUtilities
{
    public static class AssemblyUtility
    {
        public static IEnumerable<string> GetReferencedAssemblies()
        {
            var dependencies = DependencyContext.Default.RuntimeLibraries.Select(x => x.Name);
            return dependencies;
        }
    }
}
