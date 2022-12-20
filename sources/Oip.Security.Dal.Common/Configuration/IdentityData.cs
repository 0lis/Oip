using System.Collections.Generic;
using Oip.Security.Dal.Configuration.Configuration.Identity;

namespace Oip.Security.Dal.Configuration.Configuration;

public class IdentityData
{
    public List<Role> Roles { get; set; }
    public List<User> Users { get; set; }
}