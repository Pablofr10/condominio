using System;

namespace Condominio.Domain.Entities
{
    public class Reserva : Base
    {
        public string Local { get; set; }
        public DateTime DataReserva { get; set; }
        public DateTime HoraInicial { get; set; }
        public DateTime HoraFinal { get; set; }
        public int SituacaoReserva { get; set; }
        public int QuantidadeUsuarios { get; set; }
    }
}