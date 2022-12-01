using Domain.Models;
using Domain.ViewModels;
using Infra.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace SGI.Controller
{
    [ApiController]
    [Route("[Controller]")]
    public class MatrizController : ControllerBase
    {
        private readonly SGIContext _context;

        public MatrizController(SGIContext context)
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
            var matrizes = await _context.Matrizes.ToListAsync();
            return Ok(matrizes);
        }

        /// <summary>
        /// Busca por Nome.
        /// </summary>
        /// <returns>200</returns>
        [HttpGet("por-nome-Matriz")]
        public IActionResult GetByDescricao(string NomeMatriz)
        {
            var IdMatriz = _context.Matrizes.Where(x => x.NomeMatriz.Contains(NomeMatriz));
            return Ok(IdMatriz);
        }

        /// <summary>
        /// Busca por ID.
        /// </summary>
        /// <returns>200</returns>
        [HttpGet("buscar-por-id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var matriz = await _context.Matrizes.AsNoTracking().Include(x => x.Endereco).FirstOrDefaultAsync(x => x.Id == id);
            return Ok(matriz);
        }

        /// <summary>
        /// Adicionar.
        /// </summary>
        /// <returns>200</returns>
        [HttpPost("adicionar")]
        public async Task<IActionResult> Post([FromBody] MatrizViewModel matriz)
        {
            try
            {
                var novoMatriz = new Matriz(matriz);
                await _context.AddAsync(novoMatriz);
                await _context.SaveChangesAsync();
                return Ok(novoMatriz);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> Put(MatrizAtualizarViewModel matriz, int id)
        {

            if (id > 0)
            {
                Matriz mat = await _context.Matrizes.AsNoTracking().Include(x => x.Endereco).FirstOrDefaultAsync(x => x.Id == id);

                if (mat != null)
                {
                    mat.AtualizarDados(matriz);
                    _context.Update(mat);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
            }

            return BadRequest("Erro ao atualizar matriz");
        }
    }
}
