using System;
using System.Threading.Tasks;
using Oip.Security.BusinessLogic.Dtos.Log;
using Oip.Security.BusinessLogic.Mappers;
using Oip.Security.BusinessLogic.Services.Interfaces;
using Oip.Security.EntityFramework.Repositories.Interfaces;
using Skoruba.AuditLogging.EntityFramework.Entities;

namespace Oip.Security.BusinessLogic.Services;

public class AuditLogService<TAuditLog> : IAuditLogService
    where TAuditLog : AuditLog
{
    protected readonly IAuditLogRepository<TAuditLog> AuditLogRepository;

    public AuditLogService(IAuditLogRepository<TAuditLog> auditLogRepository)
    {
        AuditLogRepository = auditLogRepository;
    }

    public async Task<AuditLogsDto> GetAsync(AuditLogFilterDto filters)
    {
        var pagedList = await AuditLogRepository.GetAsync(filters.Event, filters.Source, filters.Category,
            filters.Created, filters.SubjectIdentifier, filters.SubjectName, filters.Page, filters.PageSize);
        var auditLogsDto = pagedList.ToModel();

        return auditLogsDto;
    }

    public virtual async Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan)
    {
        await AuditLogRepository.DeleteLogsOlderThanAsync(deleteOlderThan);
    }
}