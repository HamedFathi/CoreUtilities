using System.IO;

namespace CoreUtilities
{
    public static class StringUtility
    {
        public static void CreateToFile(string fileText, string absolutePath)
        {
            using (StreamWriter sw = File.CreateText(absolutePath))
                sw.Write(fileText);
        }

        public static string GetFileText(string absolutePath)
        {
            using (StreamReader sr = new StreamReader(absolutePath))
                return sr.ReadToEnd();
        }

        public static bool IsBracesMatch(string text)
        {
            int level = 0;

            foreach (char c in text)
            {
                if (c == '{')
                {
                    // opening brace detected
                    level++;
                }

                if (c == '}')
                {
                    level--;

                    if (level < 0)
                    {
                        return false;
                        // closing brace detected, without a corresponding opening brace
                        //throw new ApplicationException("Opening brace missing.");
                    }
                }
            }

            if (level > 0)
            {
                return false;
                // more open than closing braces
                //throw new ApplicationException("Closing brace missing.");
            }
            return true;
        }

        public static bool IsParenthesisMatch(string text)
        {
            int level = 0;

            foreach (char c in text)
            {
                if (c == '(')
                {
                    // opening brace detected
                    level++;
                }

                if (c == ')')
                {
                    level--;

                    if (level < 0)
                    {
                        return false;
                        // closing brace detected, without a corresponding opening brace
                        //throw new ApplicationException("Opening brace missing.");
                    }
                }
            }

            if (level > 0)
            {
                return false;
                // more open than closing braces
                //throw new ApplicationException("Closing brace missing.");
            }
            return true;
        }

        public static void UpdateFileText(string absolutePath, string lookFor, string replaceWith)
        {
            string newText = GetFileText(absolutePath).Replace(lookFor, replaceWith);
            WriteToFile(absolutePath, newText);
        }

        public static void WriteToFile(string absolutePath, string fileText)
        {
            using (StreamWriter sw = new StreamWriter(absolutePath, false))
                sw.Write(fileText);
        }
    }
}
