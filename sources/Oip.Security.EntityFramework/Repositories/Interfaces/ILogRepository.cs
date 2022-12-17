using System;
using System.Threading.Tasks;
using Oip.Security.EntityFramework.Entities;
using Oip.Security.EntityFramework.Extensions.Common;

namespace Oip.Security.EntityFramework.Repositories.Interfaces
{
    public interface ILogRepository
    {
        Task<PagedList<Log>> GetLogsAsync(string search, int page = 1, int pageSize = 10);

        Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan);

        bool AutoSaveChanges { get; set; }
    }
}