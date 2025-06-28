using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EComunidadeAPI.Models;
using EComunidadeAPI.Data;
using Microsoft.AspNetCore.Authorization;
namespace EComunidadeAPI.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class UsuariosController : ControllerBase
   {
       private readonly DataContext _context;
       private readonly IConfiguration _configuration;
       public UsuariosController(DataContext context, IConfiguration configuration)
       {
           _context = context;
           _configuration = configuration;
       }
       [HttpPost("Registrar")]
       [AllowAnonymous]
       public async Task<ActionResult<Usuario>> Registrar(Usuario usuario)
       {
           _context.Usuario.Add(usuario);
           await _context.SaveChangesAsync();
           return Ok(usuario);
       }
       [HttpPost("Autenticar")]
       [AllowAnonymous]
       public async Task<IActionResult> Autenticar([FromBody] Usuario login)
       {
           var usuario = await _context.Usuario
               .FirstOrDefaultAsync(u => u.Email == login.Email && u.Senha == login.Senha);
           if (usuario == null)
               return Unauthorized("Email ou senha inválidos");
           usuario.Token = CriarToken(usuario);
           return Ok(usuario);
       }
       private string CriarToken(Usuario usuario)
       {
           var claims = new List<Claim>
           {
               new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
               new Claim(ClaimTypes.Name, usuario.Email)
           };
           var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
               _configuration["ConfiguracaoToken:Chave"]));
           var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
           var tokenDescriptor = new SecurityTokenDescriptor
           {
               Subject = new ClaimsIdentity(claims),
               Expires = DateTime.Now.AddHours(6),
               SigningCredentials = creds
           };
           var tokenHandler = new JwtSecurityTokenHandler();
           var token = tokenHandler.CreateToken(tokenDescriptor);
           return tokenHandler.WriteToken(token);
       }
   }
}