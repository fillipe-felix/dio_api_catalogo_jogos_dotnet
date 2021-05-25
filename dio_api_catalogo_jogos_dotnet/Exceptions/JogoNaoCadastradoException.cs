using System;

namespace dio_api_catalogo_jogos_dotnet.Exceptions
{
    public class JogoNaoCadastradoException : Exception
    {
        public JogoNaoCadastradoException() : base("Esta jogo não esta cadastrado")
        {
            
        }
    }
}