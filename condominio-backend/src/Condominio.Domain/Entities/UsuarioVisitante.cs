using System;

namespace Condominio.Domain.Entities
{
    public class UsuarioVisitante : BaseDomain
    {
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int IdVisitante { get; set; }
        public Visitante Visitante { get; set; }
        public DateTime DataVisita { get; set; }
    }
}