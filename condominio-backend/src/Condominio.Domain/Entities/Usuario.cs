using System;
using System.Collections.Generic;

namespace Condominio.Domain.Entities
{
    public class Usuario : BaseDomain
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime CriadoEm { get; set; }
        public bool Ativo { get; set; }
        public int NumeroApartamento { get; set; }
        public string Complemento { get; set; }
        public int IdContato { get; set; }
        public Contato Contato { get; set; }
        public int IdImagem { get; set; }
        public Imagem Imagem { get; set; }
        public virtual List<Reserva> Reservas { get; set; }
        public virtual  List<Visitante> Visitantes { get; set; }
    }
}