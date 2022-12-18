using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Oip.Security.Dal.Common.DbContexts;
using Oip.Security.EntityFramework.Common.DbContexts;

namespace Oip.Security.Dal.Sqlite.ContextFactory;

public class SqliteIdentityServerDataProtectionDbContextFactory : SqliteBaseDbContextFactory<IdentityServerDataProtectionDbContext>
{
}