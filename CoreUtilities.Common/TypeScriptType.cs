using System.ComponentModel;

namespace CoreUtilities
{
    public enum TypeScriptType
    {
        [Description("boolean")]
        Boolean,
        [Description("number")]
        Number,
        [Description("string")]
        String,
        [Description("number[]")]
        NumberArray,
        [Description("string[]")]
        StringArray,
        [Description("boolean[]")]
        BooleanArray,
        //[Description("")]
        //Tuple,
        [Description("enum")]
        Enum,
        [Description("any")]
        Any,
        [Description("void")]
        Void,
        [Description("never")]
        Never,
        [Description("null")]
        Null,
        [Description("undefined")]
        Undefined,
        [Description("Date")]
        Date
    }
}
