using Domain.Models;
using Domain.ViewModels;
using Infra.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace SGI.Controller
{
    [ApiController]
    [Route("[Controller]")]
    public class CongregacaoController : ControllerBase
    {
        private readonly SGIContext _context;

        public CongregacaoController(SGIContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Busca todos.
        /// </summary>
        /// <returns>200</returns>
        [HttpGet("obter-todos")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var congregracoes = await _context.Congregracoes.ToListAsync();
                return Ok(congregracoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Busca por Nome.
        /// </summary>
        /// <returns>200</returns>
        [HttpGet("por-nome-congregacao")]
        public IActionResult GetByDescricao(string nomeCongregacao)
        {
            var Idcongregacao = _context.Congregracoes.Where(x => x.NomeCongregacao.Contains(nomeCongregacao));
            return Ok(Idcongregacao);
        }

        /// <summary>
        /// Busca por ID.
        /// </summary>
        /// <returns>200</returns>
        [HttpGet("buscar-por-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var congregacao = await _context.Congregracoes.AsNoTracking().Include(x => x.Endereco).FirstOrDefaultAsync(x => x.Id == id);
            return Ok(congregacao);
        }

        /// <summary>
        /// Adicionar.
        /// </summary>
        /// <returns>200</returns>
        [HttpPost("adicionar")]
        public async Task<IActionResult> Post([FromBody] CongregacaoViewModel congregacao)
        {
            var novoCongregacao = new Congregacao(congregacao);
            await _context.AddAsync(novoCongregacao);
            await _context.SaveChangesAsync();
            return Ok(novoCongregacao);
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> Put(CongregacaoAtualizarViewModel congregacao, int id)
        {

            if (id > 0)
            {
                Congregacao con = await _context.Congregracoes.AsNoTracking().Include(x => x.Endereco).FirstOrDefaultAsync(x => x.Id == id);

                if (con != null)
                {
                    con.AtualizarDados(congregacao);
                    _context.Update(con);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
            }

            return BadRequest("Erro ao atualizar congregacao");
        }
    }
}