using System;
using System.Threading.Tasks;
using Oip.Security.BusinessLogic.Dtos.Log;

namespace Oip.Security.BusinessLogic.Services.Interfaces;

public interface IAuditLogService
{
    Task<AuditLogsDto> GetAsync(AuditLogFilterDto filters);

    Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan);
}