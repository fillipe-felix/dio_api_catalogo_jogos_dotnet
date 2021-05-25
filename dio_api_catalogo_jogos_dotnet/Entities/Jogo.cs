using System;

namespace dio_api_catalogo_jogos_dotnet.Entities
{
    public class Jogo
    {
        public Guid Id { get; set; }
        
        public string Nome { get; set; }
        
        public string Produtora { get; set; }
        
        public double Preco { get; set; }
    }
}