using System;

namespace Condominio.Domain.Entities
{
    public class Usuario : Base
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime CriadoEm { get; set; }
        public bool Ativo { get; set; }
        public int IdEndereco { get; set; }
        public Endereco Endereco { get; set; }
        public int IdContato { get; set; }
        public Contato Contato { get; set; }
    }
}