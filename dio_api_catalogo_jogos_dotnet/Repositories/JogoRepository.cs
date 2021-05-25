using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dio_api_catalogo_jogos_dotnet.Entities;

namespace dio_api_catalogo_jogos_dotnet.Repositories
{
    public class JogoRepository : IJogoRepository
    {

        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("bd472226-1753-47bc-a7ef-64065616ae5e"), new Jogo{Id = Guid.Parse("bd472226-1753-47bc-a7ef-64065616ae5e"), Nome = "Fifa 21", Produtora = "EA", Preco = 200}},
            {Guid.Parse("c9760ef8-697b-44a4-8868-331e770615ea"), new Jogo{Id = Guid.Parse("c9760ef8-697b-44a4-8868-331e770615ea"), Nome = "Fifa 20", Produtora = "EA", Preco = 190}},
            {Guid.Parse("e52c0f8d-98fa-4521-b6db-6db6762351fc"), new Jogo{Id = Guid.Parse("e52c0f8d-98fa-4521-b6db-6db6762351fc"), Nome = "Fifa 19", Produtora = "EA", Preco = 180}},
            {Guid.Parse("0603ed86-bd76-446b-aa53-16b57366577b"), new Jogo{Id = Guid.Parse("0603ed86-bd76-446b-aa53-16b57366577b"), Nome = "Fifa 18", Produtora = "EA", Preco = 170}},
            {Guid.Parse("07b011bd-219d-402c-9bf5-a9b1d50d4b04"), new Jogo{Id = Guid.Parse("07b011bd-219d-402c-9bf5-a9b1d50d4b04"), Nome = "Street Fighter V", Produtora = "Capcom", Preco = 80}},
            {Guid.Parse("ee44570b-e53b-48e6-b32e-8b6c4ac8f8a5"), new Jogo{Id = Guid.Parse("ee44570b-e53b-48e6-b32e-8b6c4ac8f8a5"), Nome = "Grand The Auto V", Produtora = "Rockstar", Preco = 190}},
        };
        
        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
            {
                return null;
            }

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values
                .Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        //Faz a mesma coisa do de cima
        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Jogo>();

            foreach (var jogo in jogos.Values)
            {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                {
                    retorno.Add(jogo);
                }
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public async Task Dispose()
        {
            //Fecha a conexão com o banco
        }
    }
}