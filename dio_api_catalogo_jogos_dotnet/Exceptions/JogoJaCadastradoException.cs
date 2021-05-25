using System;

namespace dio_api_catalogo_jogos_dotnet.Exceptions
{
    public class JogoJaCadastradoException : Exception
    {
        public JogoJaCadastradoException() : base("Este jogo já esta cadastrado")
        {
            
        }
    }
}