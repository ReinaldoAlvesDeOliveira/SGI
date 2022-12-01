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
    public class LancamentoController : ControllerBase
    {
        private readonly SGIContext _context;

        public LancamentoController(SGIContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Busca todos os Endereços.
        /// </summary>
        /// <returns>200</returns>
        [HttpGet("obter-todos")]
        public async Task<IActionResult> Get()
        {
            var lancamento = await _context.Lancamentos.ToListAsync();
            return Ok(lancamento);
        }

        /// <summary>
        /// Busca por Rua.
        /// </summary>
        /// <returns>200</returns>
        [HttpGet("por-Descricao")]
        public IActionResult GetByDescricao(string Descricao)
        {
            var IdLancamento = _context.Lancamentos.Where(x => x.Descricao.Contains(Descricao));
            return Ok(IdLancamento);
        }

        /// <summary>
        /// Busca por ID.
        /// </summary>
        /// <returns>200</returns>
        [HttpGet("buscar-por-id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Lancamento = await _context.Lancamentos.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(Lancamento);
        }

        /// <summary>
        /// Busca Por Data.
        /// </summary>
        /// <returns>200</returns>
        [HttpGet("buscar-por-Data")]
        public async Task<IActionResult> Getlist(string DataLancamento)
        {
            var data = Convert.ToDateTime(DataLancamento);
            var lancamentos = await _context.Lancamentos.Where(x => x.DataLancamento.Date == data.Date).ToListAsync();
            return Ok(lancamentos);
        }

        /// <summary>
        /// Adicionar.
        /// </summary>
        /// <returns>200</returns>
        [HttpPost("Adicionar")]
        public async Task<IActionResult> Post([FromBody] LancamentoViewModel lancamento)
        {
            var novoLancamento = new Lancamento(lancamento);
            _context.Add(novoLancamento);
            await _context.SaveChangesAsync();
            return Ok(novoLancamento);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> Put(LancamentoViewModel lancamento, int id = 0)
        {

            if (id > 0)
            {
                Lancamento lan = await _context.Lancamentos.FirstOrDefaultAsync(x => x.Id == id);

                if (lan != null)
                {
                    lan.AtualizarDados(lancamento);
                    _context.Update(lan);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
            }

            return BadRequest("Erro ao atualizar lancamento");
        }


    }
}
