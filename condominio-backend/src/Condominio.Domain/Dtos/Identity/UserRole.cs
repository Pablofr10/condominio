using Microsoft.AspNetCore.Identity;

namespace Condominio.Domain.Dtos.Identity
{
    public class UserRole : IdentityUserRole<int>
    {
        public User User { get; set; }
        public Role Role { get; set; }
        public string Username { get; set; }
        public bool Ativo { get; set; }
    }
}