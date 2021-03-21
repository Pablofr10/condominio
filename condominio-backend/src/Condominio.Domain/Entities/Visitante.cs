namespace Condominio.Domain.Entities
{
    public class Visitante
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public bool Confirmado { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}