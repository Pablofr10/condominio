namespace Condominio.Domain.Dtos
{
    public class UserRoleDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public bool Ativo { get; set; }
    }
}