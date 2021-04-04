namespace Condominio.Domain.Entities
{
    public class Contato : BaseDomain
    {
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public Usuario Usuario { get; set; }
    }
}