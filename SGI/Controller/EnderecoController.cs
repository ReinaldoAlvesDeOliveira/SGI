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
    public class EnderecoController : ControllerBase
    {
        private readonly SGIContext _context;

        public EnderecoController(SGIContext context)
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
            var enderecos = await _context.Enderecos.AsNoTracking().ToListAsync();
            return Ok(enderecos);
        }

        /// <summary>
        /// Busca por Rua.
        /// </summary>
        /// <returns>200</returns>
        [HttpGet("por-rua")]
        public IActionResult GetByDescricao(string rua)
        {
            var IdEnderecos = _context.Enderecos.Where(x => x.Rua.Contains(rua));
            return Ok(IdEnderecos);
        }

        /// <summary>
        /// Busca Endereço por ID.
        /// </summary>
        /// <returns>200</returns>
        [HttpGet("buscar-por-id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var endereco = await _context.Enderecos.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(endereco);
        }

        /// <summary>
        /// Adicionar.
        /// </summary>
        /// <returns>200</returns>
        [HttpPost("adicionar")]
        public async Task<IActionResult> Post([FromBody] EnderecoViewModel endereco)
        {
            var novoEndereco = new Endereco(endereco);
            await _context.AddAsync(novoEndereco);
            await _context.SaveChangesAsync();
            return Ok(novoEndereco);
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> Put(EnderecoViewModel endereco, int id)
        {

            if (id > 0)
            {
                Endereco end = await _context.Enderecos.FirstOrDefaultAsync(x => x.Id == id);

                if (end != null)
                {
                    end.AtualizarDados(endereco);
                    _context.Update(end);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
            }

            return BadRequest("Erro ao atualizar endereço");
        }
    }
}
