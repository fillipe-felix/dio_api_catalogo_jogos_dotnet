using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dio_api_catalogo_jogos_dotnet.InputModel;
using dio_api_catalogo_jogos_dotnet.ViewModel;

namespace dio_api_catalogo_jogos_dotnet.Services
{
    public interface IJogoService
    {
        Task<List<JogoViewModel>> Obter(int pagina, int quantidade);

        Task<JogoViewModel> Obter(Guid id);

        Task<JogoViewModel> Inserir(JogoInputModel jogo);

        Task Atualizar(Guid id, JogoInputModel jogo);

        Task Atualizar(Guid id, double preco);

        Task Remover(Guid id);
    }
}