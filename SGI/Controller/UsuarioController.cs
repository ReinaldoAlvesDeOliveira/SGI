using Infra.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SGI.Controller
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly SGIContext _context;

        public UsuarioController(SGIContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Busca todos os Usuarios.
        /// </summary>
        /// <returns>200</returns>
        [Authorize(Policy = "Administrador")]
        [HttpGet("obter-todos")]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _context.Usuarios.Select(x => new { Nome = x.Nome }).ToListAsync();
            return Ok(usuarios);
        }
    }
}
