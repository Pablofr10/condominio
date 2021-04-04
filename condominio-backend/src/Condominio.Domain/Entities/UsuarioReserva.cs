using System.Collections.Generic;

namespace Condominio.Domain.Entities
{
    public class UsuarioReserva
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int IdReserva { get; set; }
        public virtual Reserva Reserva { get; set; }
    }
}