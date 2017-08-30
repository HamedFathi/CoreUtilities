using System.Collections.Generic;
using System.Text;

namespace CoreUtilities
{
    public class NamingConventionUtility
    {
        public static string CorrectVariableName(string name, out bool isChanged)
        {
            isChanged = false;
            if (string.IsNullOrEmpty(name))
                return null;
            if (!IsValidVariableName(name))
            {
                var sb = new StringBuilder();

                for (int i = 0; i < name.Length; i++)
                {
                    if (i == 0)
                    {
                        if (!char.IsLetter(name[i]) && name[i] != '@' && name[i] != '_')
                            sb.Append('_');
                        else
                            sb.Append(name[i]);
                    }
                    else
                    {
                        if (!char.IsNumber(name[i]) && !char.IsLetter(name[i]) && name[i] != '_')
                            sb.Append('_');
                        else
                            sb.Append(name[i]);
                    }

                }

                name = sb.ToString();
                isChanged = true;

            }
            if (IsCSharpKeyword(name))
            {
                isChanged = true;
                return "@" + name;
            }
            return name;
        }

        public static bool IsCSharpKeyword(string keyword)
        {
            keyword = keyword.Trim();

            var list = new List<string>()
            {
                "abstract",
                "as",
                "base",
                "bool",
                "break",
                "byte",
                "case",
                "catch",
                "char",
                "checked",
                "class",
                "const",
                "continue",
                "decimal",
                "default",
                "delegate",
                "do",
                "double",
                "else",
                "enum",
                "event",
                "explicit",
                "extern",
                "false",
                "finally",
                "fixed",
                "float",
                "for",
                "foreach",
                "goto",
                "if",
                "implicit",
                "in",
                "int",
                "interface",
                "public",
                "is",
                "lock",
                "long",
                "nameof",
                "namespace",
                "new",
                "null",
                "object",
                "operator",
                "out",
                "override",
                "params",
                "private",
                "protected",
                "public",
                "readonly",
                "ref",
                "return",
                "sbyte",
                "sealed",
                "short",
                "sizeof",
                "stackalloc",
                "static",
                "string",
                "struct",
                "switch",
                "this",
                "throw",
                "true",
                "try",
                "typeof",
                "uint",
                "ulong",
                "unchecked",
                "unsafe",
                "ushort",
                "using",
                "virtual",
                "void",
                "volatile",
                "while"
            };

            return list.Contains(keyword);
        }

        public static bool IsValidVariableName(string name)
        {

            name = name.Trim();
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            var first = name[0];
            if (char.IsNumber(first))
            {
                return false;
            }
            if (name.Contains("@") && first != '@')
            {
                return false;
            }

            for (int i = 0; i < name.Length; i++)
            {
                if (i == 0)
                {
                    if (!char.IsNumber(name[i]) && !char.IsLetter(name[i]) && name[i] != '@' && name[i] != '_')
                        return false;
                }
                else if (!char.IsNumber(name[i]) && !char.IsLetter(name[i]) && name[i] != '_')
                {
                    return false;
                }
            }


            return true;
        }
    }
}
