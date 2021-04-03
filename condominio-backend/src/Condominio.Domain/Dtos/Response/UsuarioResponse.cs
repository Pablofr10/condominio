using System;
using Condominio.Domain.Entities;

namespace Condominio.Domain.Dtos.Response
{
    public class UsuarioResponse
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