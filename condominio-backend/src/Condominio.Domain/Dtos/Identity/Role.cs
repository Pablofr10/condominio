using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Condominio.Domain.Dtos.Identity
{
    public class Role : IdentityRole<int>
    {
        public List<UserRole> UserRoles { get; set; }
    }
}