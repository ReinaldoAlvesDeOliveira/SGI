using Infra.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGI.Configuration;
using System.Diagnostics.Eventing.Reader;

namespace SGI.Controller
{
    [ApiController]
    [Route("[Controller]")]
    public class AccountController : ControllerBase
    {
        private readonly SGIContext _context;
        private readonly IConfiguration _config;

        public AccountController(SGIContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        /// <summary>
        /// Autenticar usuário.
        /// </summary>
        /// <returns>200</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(string login, string senha)
        {
            // Recupera o usuário
            var usuario = await _context.Usuarios.Include(x => x.UsuarioPerfis).ThenInclude(x => x.Perfil).FirstOrDefaultAsync(x => x.Login == login && x.Senha == senha);

            // Verifica se o usuário existe
            if (usuario == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = AuthenticationConfig.GenerateToken(_config, usuario);

            // Retorna os dados
            return Ok(new
            {
                usuario = usuario.Nome,
                token = token
            });
        }
    }
}
