using System;
using System.IO;
using System.Linq;

namespace CoreUtilities
{
    public static class DirectoryInfoUtility
    {
        public static string CreateTempDirectory()
        {
            var tempDirectory = Path.Combine(Path.GetTempPath(),
                Path.GetRandomFileName());
            if (!System.IO.Directory.Exists(tempDirectory))
            {
                System.IO.Directory.CreateDirectory(tempDirectory);
            }
            else
            {
                throw new Exception("Temp directory did not create.");
            }
            return tempDirectory;
        }

        public static void CreateTempDirectory(Action<string> action, bool autoDelete = true)
        {
            var tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            if (!Directory.Exists(tempDirectory))
            {
                Directory.CreateDirectory(tempDirectory);
                action(tempDirectory);
                if (Directory.Exists(tempDirectory) && autoDelete == true)
                {
                    try
                    {
                        Directory.Delete(tempDirectory, true);

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                throw new Exception("Temp directory did not create.");
            }
        }

        public static string GetDirectoryName(string path)
        {
            return Path.GetFullPath(path).Split(Path.DirectorySeparatorChar).LastOrDefault();
        }
    }
}
