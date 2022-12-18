using System.Collections.Generic;
using Oip.Security.EntityFramework.Configuration.Configuration.Identity;

namespace Oip.Security.EntityFramework.Configuration.Configuration;

public class IdentityData
{
    public List<Role> Roles { get; set; }
    public List<User> Users { get; set; }
}