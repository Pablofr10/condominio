namespace Condominio.Domain.Entities
{
    public class Imagem : Base
    {
        public string Url { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}