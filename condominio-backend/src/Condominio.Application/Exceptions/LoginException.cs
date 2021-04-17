
using System;

namespace Condominio.Application.Exceptions
{
    [Serializable]
    public class LoginException : Exception
    {
        public LoginException()
        {
        }

        public LoginException(string mensagem) : base(mensagem)
        {
        }

        public LoginException(string mensagem, Exception inner) : base(mensagem, inner)
        {
        }
    }
}