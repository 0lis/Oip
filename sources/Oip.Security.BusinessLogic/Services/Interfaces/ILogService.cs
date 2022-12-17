using System;
using System.Threading.Tasks;
using Oip.Security.BusinessLogic.Dtos.Log;

namespace Oip.Security.BusinessLogic.Services.Interfaces
{
    public interface ILogService
    {
        Task<LogsDto> GetLogsAsync(string search, int page = 1, int pageSize = 10);

        Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan);
    }
}