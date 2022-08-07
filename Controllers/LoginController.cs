using login_webAPI.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

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
            var usuario = _context.Usuarios.Where(x => x.Email == email).FirstOrDefault();

            if (usuario == null)
                return NotFound();

            if (BCrypt.Net.BCrypt.Verify(senha, usuario.Senha))
            {
                var minhasClaims = new[]
               {
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.GivenName, usuario.Nome) 
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("login-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(
                        issuer: "login.webAPI",
                        audience: "login.webAPI",
                        claims: minhasClaims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                );
                var token = new JwtSecurityTokenHandler().WriteToken(meuToken);

                return Ok(new { token = token });
            }

            return Unauthorized();
        }
    }
}
