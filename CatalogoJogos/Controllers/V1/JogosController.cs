using ApiCatalogoDeJogos.ImputModel;
using ApiCatalogoDeJogos.Services;
using ApiCatalogoDeJogos.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoDeJogos.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService  jogoService;


        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Obter([FromQuery, Range(1,int.MaxValue)] int pagina = 1, [FromQuery, Range(1,50)] int quantidade = 5)
        {
            var jogos = await jogoService.Obter(pagina, quantidade);
            if (jogos.Count() == 0)
                return NoContent();

            return Ok(jogos);
        }
        [HttpGet("{idJogo:guild}")]
        public async Task<ActionResult<List<JogoViewModel>>> Obter([FromRoute]Guid idJogo)
        {
            var jogo = await jogoService.Obter(idJogo);
            if (jogo == null)
                return NoContent();
             
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody]JogoImputModel jogoInputModel)
        {
            try
            {
                var jogo = await jogoService.Inserir(jogoInputModel);
                return Ok(jogo);
            }
           // catch(JogoJaCadastradoException ex)
           catch(Exception ex)
            {
                return UnprocessableEntity("Já existe um jogo com este nome para esta produtora");
            }
            
            
        }
        [HttpPut("{idJogo:guild}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo,[FromBody] JogoImputModel jogoInputModel)
        {
            try
            {
                await jogoService.Atualizar(idJogo, jogoInputModel);
                return Ok();
            }
            // catch(JogoNaoCadastradoException ex)
            catch (Exception ex)
            {
                return NotFound("Não existe este jogo");
            }
        }
        [HttpPatch("{idJogo:guild}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute]Guid idJogo,[FromBody] Double preco)
        {
            try
            {
                await jogoService.Atualizar(idJogo, preco);

                return Ok();

            }
            // catch(JogoNaoCadastradoException ex)
            catch (Exception ex)
            {
                return NotFound("Não existe este jogo");
            }
        }
        [HttpDelete("{idJogo:guild}")]
        public async Task<ActionResult> ApagarJogo([FromRoute]Guid idJogo)
        {
            try
            {
                await jogoService.Remover(idJogo);

                return Ok();

            }
            // catch(JogoNaoCadastradoException ex)
            catch (Exception ex)
            {
                return NotFound("Não existe este jogo");
            }
        }
    }
}