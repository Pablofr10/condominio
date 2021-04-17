
using System;

namespace Condominio.Application.Exceptions
{
    [Serializable]
    public class PermissaoException : Exception
    {
        public PermissaoException()
        {
        }

        public PermissaoException(string mensagem) : base(mensagem)
        {
        }

        public PermissaoException(string mensagem, Exception inner) : base(mensagem, inner)
        {
        }
    }
}