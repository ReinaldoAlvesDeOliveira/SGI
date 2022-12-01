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
    public class MembrosController : ControllerBase
    {
        private readonly SGIContext _context;

        public MembrosController(SGIContext context)
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
            var membros = await _context.Membros.ToListAsync();
            return Ok(membros);
        }

        /// <summary>
        /// Busca por Nome.
        /// </summary>
        /// <returns>200</returns>
        [HttpGet("por-nome")]
        public IActionResult GetByDescricao(string Nome)
        {
            var IdMembros = _context.Membros.Where(x => x.Nome.Contains(Nome));
            return Ok(IdMembros);
        }

        /// <summary>
        /// Busca por ID.
        /// </summary>
        /// <returns>200</returns>
        [HttpGet("buscar-por-id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var membro = await _context.Membros.AsNoTracking().Include(x => x.Endereco).Include(x => x.Congregracao).Include(x => x.Matriz).FirstOrDefaultAsync(x => x.Id == id);
            return Ok(membro);
        }

        /// <summary>
        /// Adicionar.
        /// </summary>
        /// <returns>200</returns>
        [HttpPost("Adicionar")]
        public async Task<IActionResult> Post([FromBody] MembroViewModel membro)
        {
            try
            {
                var novoMembro = new Membro(membro);
                _context.Add(novoMembro);
                await _context.SaveChangesAsync();
                return Ok(novoMembro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> Put(MembroAtualizarViewModel membro, int id)
        {

            if (id < 0)
            {
                Membro men = await _context.Membros.AsNoTracking().Include(x => x.Endereco).FirstOrDefaultAsync(x => x.Id == id);

                if (men != null)
                {
                    men.AtualizarDados(membro);
                    _context.Update(men);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }

            }

            return BadRequest("Erro ao atualizar membro");
        }


    }
}
