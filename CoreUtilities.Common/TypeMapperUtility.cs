using CoreExtensions;
using System;

namespace CoreUtilities
{
    public static class TypeMapperUtility
    {
        public static string ToCSharp(SqlServerType sqlServerType, bool isNullable = false)
        {
            var status = isNullable ? "?" : "";
            switch (sqlServerType)
            {
                case SqlServerType.SysName:
                case SqlServerType.NChar:
                case SqlServerType.NText:
                case SqlServerType.NVarChar:
                case SqlServerType.Text:
                case SqlServerType.Varhar:
                case SqlServerType.Xml:
                    return CSharpType.String.GetDescription();
                case SqlServerType.Bigint:
                    return CSharpType.Long.GetDescription() + status;
                case SqlServerType.Binary:
                case SqlServerType.Image:
                case SqlServerType.FileStream:
                case SqlServerType.RowVersion:
                case SqlServerType.VarBinary:
                case SqlServerType.TimeStamp:
                    return CSharpType.BytesArray.GetDescription();
                case SqlServerType.Bit:
                    return CSharpType.Bool.GetDescription() + status;
                case SqlServerType.Char:
                    return CSharpType.Char.GetDescription() + status;
                case SqlServerType.Date:
                case SqlServerType.DateTime:
                case SqlServerType.DateTime2:
                case SqlServerType.SmallDateTime:
                    return CSharpType.DateTime.GetDescription() + status;
                case SqlServerType.DateTimeOffset:
                    return CSharpType.DateTimeOffset.GetDescription() + status;
                case SqlServerType.Decimal:
                case SqlServerType.Money:
                case SqlServerType.SmallMoney:
                    return CSharpType.Decimal.GetDescription() + status;
                case SqlServerType.Numeric:
                case SqlServerType.Float:
                    return CSharpType.Double.GetDescription() + status;
                case SqlServerType.Geography:
                    return CSharpType.SqlGeography.GetDescription();
                case SqlServerType.Geometry:
                    return CSharpType.SqlGeometry.GetDescription();
                case SqlServerType.HierarchyId:
                    return CSharpType.SqlHierarchyId.GetDescription();
                case SqlServerType.Int:
                    return CSharpType.Int.GetDescription() + status;
                case SqlServerType.Real:
                    return CSharpType.Float.GetDescription() + status;
                case SqlServerType.SmallInt:
                    return CSharpType.Short.GetDescription() + status;
                case SqlServerType.SqlVariant:
                    return CSharpType.Object.GetDescription();
                case SqlServerType.Time:
                    return CSharpType.TimeSpan.GetDescription() + status;
                case SqlServerType.TinyInt:
                    return CSharpType.Byte.GetDescription() + status;
                case SqlServerType.UniqueIdentifier:
                    return CSharpType.Guid.GetDescription() + status;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sqlServerType), sqlServerType, null);
            }
        }

        public static string ToTypeScript(CSharpType cSharpType, bool isNullable = false)
        {
            var status = isNullable ? " | " + TypeScriptType.Null.GetDescription() : "";
            switch (cSharpType)
            {
                case CSharpType.Bool:
                    return TypeScriptType.Boolean.GetDescription() + status;
                case CSharpType.Byte:
                case CSharpType.SByte:
                case CSharpType.Decimal:
                case CSharpType.Double:
                case CSharpType.Float:
                case CSharpType.Short:
                case CSharpType.UShort:
                case CSharpType.Int:
                case CSharpType.UInt:
                case CSharpType.Long:
                case CSharpType.ULong:
                    return TypeScriptType.Number.GetDescription() + status;
                case CSharpType.String:
                case CSharpType.Char:
                    return TypeScriptType.String.GetDescription() + status;
                case CSharpType.Object:
                    return TypeScriptType.Any.GetDescription() + status;
                case CSharpType.SqlGeography:
                    return TypeScriptType.Any.GetDescription() + status;
                case CSharpType.SqlGeometry:
                    return TypeScriptType.Any.GetDescription() + status;
                case CSharpType.SqlHierarchyId:
                    return TypeScriptType.Any.GetDescription() + status;
                case CSharpType.BytesArray:
                    return TypeScriptType.NumberArray.GetDescription() + status;
                case CSharpType.DateTime:
                    return TypeScriptType.Date.GetDescription() + status;
                default:
                    throw new ArgumentOutOfRangeException(nameof(cSharpType), cSharpType, null);
            }
        }

        public static string ToTypeScript(SqlServerType sqlServerType, bool isNullable = false)
        {
            var status = isNullable ? " | " + TypeScriptType.Null.GetDescription() : "";
            switch (sqlServerType)
            {
                case SqlServerType.SysName:
                    return TypeScriptType.String.GetDescription() + status;
                case SqlServerType.Bigint:
                    return TypeScriptType.Number.GetDescription() + status;
                case SqlServerType.Binary:
                    break;
                case SqlServerType.Bit:
                    return TypeScriptType.Boolean.GetDescription() + status;
                case SqlServerType.Char:
                    return TypeScriptType.String.GetDescription() + status;
                case SqlServerType.Date:
                    return TypeScriptType.Date.GetDescription() + status;

                case SqlServerType.DateTime:
                    return TypeScriptType.Date.GetDescription() + status;

                case SqlServerType.DateTime2:
                    return TypeScriptType.Date.GetDescription() + status;

                case SqlServerType.DateTimeOffset:
                    break;
                case SqlServerType.Decimal:
                    return TypeScriptType.Number.GetDescription() + status;
                case SqlServerType.FileStream:
                    break;
                case SqlServerType.Float:
                    return TypeScriptType.Number.GetDescription() + status;
                case SqlServerType.Geography:
                    return TypeScriptType.Any.GetDescription() + status;
                case SqlServerType.Geometry:
                    return TypeScriptType.Any.GetDescription() + status;
                case SqlServerType.HierarchyId:
                    return TypeScriptType.Any.GetDescription() + status;
                case SqlServerType.Image:
                    break;
                case SqlServerType.Int:
                    return TypeScriptType.Number.GetDescription() + status;
                case SqlServerType.Money:
                    return TypeScriptType.Number.GetDescription() + status;
                case SqlServerType.NChar:
                    return TypeScriptType.String.GetDescription() + status;
                case SqlServerType.NText:
                    return TypeScriptType.String.GetDescription() + status;
                case SqlServerType.Numeric:
                    return TypeScriptType.Number.GetDescription() + status;
                case SqlServerType.NVarChar:
                    return TypeScriptType.String.GetDescription() + status;
                case SqlServerType.Real:
                    return TypeScriptType.Number.GetDescription() + status;
                case SqlServerType.RowVersion:
                    return TypeScriptType.Number.GetDescription() + status;
                case SqlServerType.SmallDateTime:
                    return TypeScriptType.Date.GetDescription() + status;

                case SqlServerType.SmallInt:
                    return TypeScriptType.Number.GetDescription() + status;
                case SqlServerType.SmallMoney:
                    return TypeScriptType.Number.GetDescription() + status;
                case SqlServerType.SqlVariant:
                    break;
                case SqlServerType.Text:
                    return TypeScriptType.String.GetDescription() + status;
                case SqlServerType.Time:
                    break;
                case SqlServerType.TimeStamp:
                    break;
                case SqlServerType.TinyInt:
                    return TypeScriptType.Number.GetDescription() + status;
                case SqlServerType.UniqueIdentifier:
                    return TypeScriptType.String.GetDescription() + status;
                case SqlServerType.VarBinary:
                    break;
                case SqlServerType.Varhar:
                    return TypeScriptType.String.GetDescription() + status;
                case SqlServerType.Xml:
                    return TypeScriptType.String.GetDescription() + status;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sqlServerType), sqlServerType, null);
            }
            return "";
        }
    }
}
