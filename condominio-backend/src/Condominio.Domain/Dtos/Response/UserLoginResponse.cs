namespace Condominio.Domain.Dtos.Response
{
    public class UserLoginResponse
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}