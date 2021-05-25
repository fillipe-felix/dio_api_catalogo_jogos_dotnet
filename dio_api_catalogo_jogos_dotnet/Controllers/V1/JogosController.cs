using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dio_api_catalogo_jogos_dotnet.InputModel;
using dio_api_catalogo_jogos_dotnet.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace dio_api_catalogo_jogos_dotnet.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<JogoViewModel>>> Obter()
        {
            return Ok();
        }
        
        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<JogoViewModel>> Obter(Guid idJogo)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo(JogoInputModel jogo)
        {
            return Ok();
        }

        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> AtualizarJogo(Guid idJogo, JogoInputModel jogo)
        {
            return Ok();
        }
        
        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo(Guid idJogo, double preco)
        {
            return Ok();
        }
        
        [HttpDelete("{idJogo:guid}")]
        public async Task<ActionResult> ApagarJogo(Guid idJogo)
        {
            return Ok();
        }
    }
}