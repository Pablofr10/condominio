namespace Condominio.Domain.Entities
{
    public class Imagem : BaseDomain
    {
        public string Url { get; set; }
        public Usuario Usuario { get; set; }
    }
}