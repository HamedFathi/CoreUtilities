using CoreExtensions;
using System.Collections.Generic;
using System.Composition.Convention;
using System.Composition.Hosting;
using System.IO;
using System.Linq;

namespace CoreUtilities
{
    public static class CompositionUtility
    {
        private static bool Contains(this string source, string target, bool ignoreCase)
        {
            return ignoreCase ? source.ContainsIgnoreCase(target) : source.Contains(target);
        }

        public static IEnumerable<T> LoadFromDirectory<T>(string directoryPath, string searchPattern = "*.dll", SearchOption searchOption = SearchOption.TopDirectoryOnly, bool customLoadContext = false)
        {
            var conventions = new ConventionBuilder();
            conventions
                .ForTypesDerivedFrom<T>()
                .Export<T>()
                .Shared();
            var configuration = new ContainerConfiguration()
                .WithAssembliesInFolderPath(directoryPath, conventions, searchPattern, searchOption, customLoadContext);
            var container = configuration.CreateContainer();
            var plugins = container.GetExports<T>().ToList();
            return plugins;
        }

        public static IEnumerable<T> LoadFromDirectoryByTypeName<T>(string directoryPath, string typeName, bool ignoreCase = false,
                    string searchPattern = "*.dll", SearchOption searchOption = SearchOption.TopDirectoryOnly, bool customLoadContext = false)
        {
            var plugins = LoadFromDirectory<T>(directoryPath, searchPattern, searchOption, customLoadContext)
                .Where(
                    x =>
                        x.GetType()
                            .FullName.Contains(typeName, ignoreCase));
            return plugins;
        }

        public static IEnumerable<T> LoadFromDirectoryByTypesName<T>(string directoryPath, string[] typesName, bool ignoreCase = false,
            string searchPattern = "*.dll", SearchOption searchOption = SearchOption.TopDirectoryOnly, bool customLoadContext = false)
        {
            var plugins = LoadFromDirectory<T>(directoryPath, searchPattern, searchOption, customLoadContext).ToList();
            var types = new List<T>();

            foreach (var tn in typesName)
            {
                var p = plugins.Where(x => x.GetType().FullName.Contains(tn, ignoreCase)).ToList();
                if (p.Count > 0)
                {
                    types.AddRange(p);
                }
            }
            return types;
        }

        public static IEnumerable<T> LoadFromFile<T>(string filePath, bool customLoadContext = false)
        {
            var conventions = new ConventionBuilder();
            conventions
                .ForTypesDerivedFrom<T>()
                .Export<T>()
                .Shared();
            var configuration = new ContainerConfiguration()
                .WithAssembliesInFilePath(filePath, conventions, customLoadContext);
            var container = configuration.CreateContainer();
            var plugins = container.GetExports<T>().ToList();
            return plugins;
        }

        public static IEnumerable<T> LoadFromFileByTypeName<T>(string filePath, string typeName, bool ignoreCase = false, bool customLoadContext = false)
        {
            var plugins = LoadFromFile<T>(filePath, customLoadContext)
                .Where(
                    x =>
                        x.GetType()
                            .FullName.Contains(typeName, ignoreCase));
            return plugins;
        }

        public static IEnumerable<T> LoadFromFileByTypesName<T>(string filePath, string[] typesName, bool ignoreCase = false, bool customLoadContext = false)
        {
            var plugins = LoadFromFile<T>(filePath, customLoadContext).ToList();
            var types = new List<T>();
            foreach (var tn in typesName)
            {
                var p = plugins.Where(x => x.GetType().FullName.Contains(tn, ignoreCase)).ToList();
                if (p.Count > 0)
                {
                    types.AddRange(p);
                }
            }
            return types;
        }
    }
}
