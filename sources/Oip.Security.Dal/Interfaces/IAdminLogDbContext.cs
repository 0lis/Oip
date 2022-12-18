using Microsoft.EntityFrameworkCore;
using Oip.Security.EntityFramework.Entities;

namespace Oip.Security.EntityFramework.Interfaces;

public interface IAdminLogDbContext
{
    DbSet<Log> Logs { get; set; }
}