using System.Reflection;

namespace Oip.Security.Dal.Sqlite.Helpers;

public class MigrationAssembly
{
    public static string AssemblyName =>
        typeof(MigrationAssembly).GetTypeInfo().Name;
}