namespace Condominio.Domain.Dtos.Response
{
    public class UserRoleResponse
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string NomePermissao { get; set; }
    }
}