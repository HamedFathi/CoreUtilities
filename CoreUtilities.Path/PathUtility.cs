using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CoreUtilities
{
    public static class PathUtility
    {
        public static string GetDirectoryName(string path)
        {
            if (IsDirectory(path).Value == true)
                return Path.GetFullPath(path).Split(Path.DirectorySeparatorChar).LastOrDefault();
            else
            {
                var newPath = Path.GetDirectoryName(path);
                return Path.GetFullPath(newPath).Split(Path.DirectorySeparatorChar).LastOrDefault();
            }
        }

        public static string GetFilePathWithoutExtension(string path)
        {
            return System.IO.Path.ChangeExtension(path, null);
        }

        public static string GetFullPathWithoutExtension(string path)
        {
            return Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path));
        }

        public static string GetRelativePath(string file, string folder)
        {
            //   / means the root of the current directory
            //  ./ means the current directory
            // ../ means the parent of the current directory

            var absDirs = file.Split(Path.DirectorySeparatorChar);
            var relDirs = folder.Split(Path.DirectorySeparatorChar);
            // Get the shortest of the two paths
            var len = absDirs.Length < relDirs.Length ? absDirs.Length : relDirs.Length;
            // Use to determine where in the loop we exited
            var lastCommonRoot = -1;
            int index;
            // Find common root
            for (index = 0; index < len; index++)
            {
                if (absDirs[index] == relDirs[index])
                    lastCommonRoot = index;
                else break;
            }
            // If we didn't find a common prefix then throw
            if (lastCommonRoot == -1)
            {
                throw new ArgumentException("Paths do not have a common base");
            }
            // Build up the relative path
            var relativePath = new StringBuilder();
            // Add on the ..
            for (index = lastCommonRoot + 1; index < absDirs.Length; index++)
            {
                if (absDirs[index].Length > 0) relativePath.Append(".." + Path.DirectorySeparatorChar);
            }
            // Add on the folders
            for (index = lastCommonRoot + 1; index < relDirs.Length - 1; index++)
            {
                relativePath.Append(relDirs[index] + Path.DirectorySeparatorChar);
            }
            relativePath.Append(relDirs[relDirs.Length - 1]);
            return relativePath.ToString();
        }

        public static bool? IsDirectory(string path)
        {
            if (Directory.Exists(path))
                return true;
            if (File.Exists(path))
                return false;
            return null;
        }

        public static bool? IsFile(string path)
        {
            if (Directory.Exists(path))
                return false;
            if (File.Exists(path))
                return true;
            return null;
        }
    }
}
