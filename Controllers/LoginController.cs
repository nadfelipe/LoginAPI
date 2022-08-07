using login_webAPI.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace login_webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginContext _context;

        public LoginController(LoginContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Logar(string email, string senha)
        {
            var usuario = _context.Usuarios.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }
    }
}
