namespace Condominio.Domain.Entities
{
    public class Convidado : BaseDomain
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public bool Confirmado { get; set; }
        public int IdReserva { get; set; }
        public Reserva Reserva { get; set; }
    }
}