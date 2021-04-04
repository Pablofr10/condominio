using System;
using Condominio.Domain.Entities;

namespace Condominio.Domain.Dtos.Response
{
    public class UsuarioResponse
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public bool Ativo { get; set; }
        public int NumeroApartamento { get; set; }
        public string Complemento { get; set; }
        public ContatoDto Contato { get; set; }
        public string UrlImagem { get; set; }
    }
}