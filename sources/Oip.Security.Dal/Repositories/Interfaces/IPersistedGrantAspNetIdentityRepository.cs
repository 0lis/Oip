﻿using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;
using Oip.Security.Dal.Entities;
using Oip.Security.Dal.Extensions.Common;

namespace Oip.Security.Dal.Identity.Repositories.Interfaces;

public interface IPersistedGrantAspNetIdentityRepository
{
    bool AutoSaveChanges { get; set; }

    Task<PagedList<PersistedGrantDataView>> GetPersistedGrantsByUsersAsync(string search, int page = 1,
        int pageSize = 10);

    Task<PagedList<PersistedGrant>> GetPersistedGrantsByUserAsync(string subjectId, int page = 1, int pageSize = 10);
    Task<PersistedGrant> GetPersistedGrantAsync(string key);
    Task<int> DeletePersistedGrantAsync(string key);
    Task<int> DeletePersistedGrantsAsync(string userId);
    Task<bool> ExistsPersistedGrantsAsync(string subjectId);
    Task<bool> ExistsPersistedGrantAsync(string key);
    Task<int> SaveAllChangesAsync();
}