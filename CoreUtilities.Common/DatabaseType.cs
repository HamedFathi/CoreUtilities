using System.ComponentModel;

namespace CoreUtilities
{
    public enum DatabaseType
    {
        [Description("")]
        SqlServer,
        Oracle,
        PostgreSql,
        Sqlite,
        Firebird,
        MySql,
        DB2,
        MongoDB,
        Redis
    }
}
