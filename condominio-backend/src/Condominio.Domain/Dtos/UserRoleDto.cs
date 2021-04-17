namespace Condominio.Domain.Dtos
{
    public class UserRoleDto
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string UserName { get; set; }
        public bool Ativo { get; set; }
    }
}