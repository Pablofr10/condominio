using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Condominio.Domain.Dtos.Identity
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}