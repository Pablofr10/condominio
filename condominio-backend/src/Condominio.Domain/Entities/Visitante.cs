using System.Collections.Generic;

namespace Condominio.Domain.Entities
{
    public class Visitante : BaseDomain
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public bool Confirmado { get; set; }
        public int IdUsuario { get; set; }
        public List<Usuario> Usuario { get; set; }
    }
}