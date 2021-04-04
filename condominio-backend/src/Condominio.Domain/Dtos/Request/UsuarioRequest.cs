using System;

namespace Condominio.Domain.Dtos.Request
{
    public class UsuarioRequest
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int NumeroApartamento { get; set; }
        public string Complemento { get; set; }
        public ContatoDto Contato { get; set; }
        public ImagemDto Imagem { get; set; }
    }
}