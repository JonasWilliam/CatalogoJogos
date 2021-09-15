using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoDeJogos.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<object>>> Obter()
        {
            return Ok();
        }
        [HttpGet("{idJogo:guild}")]
        public async Task<ActionResult<List<object>>> Obter(Guid idJogo)
        {
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult<object>> InserirJogo(object jogo)
        {
            return Ok();
        }
        [HttpPut("{idJogo:guild}")]
        public async Task<ActionResult> AtualizarJogo(Guid idJogo, object jogo)
        {
            return Ok();
        }
        [HttpPatch("{idJogo:guild}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo(Guid idJogo, Double jogo)
        {
            return Ok();
        }
        [HttpDelete("{idJogo:guild}")]
        public async Task<ActionResult> ApagarJogo(Guid idJogo)
        {
            return Ok();
        }
    }
}