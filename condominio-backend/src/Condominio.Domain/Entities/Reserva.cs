using System;
using System.Collections.Generic;

namespace Condominio.Domain.Entities
{
    public class Reserva : BaseDomain
    {
        public string Local { get; set; }
        public DateTime DataReserva { get; set; }
        public DateTime HoraInicial { get; set; }
        public DateTime HoraFinal { get; set; }
        public int Situacao { get; set; }
        public int QuantidadeConvidados { get; set; }
        public virtual List<Usuario> Usuarios { get; set; }
    }
}