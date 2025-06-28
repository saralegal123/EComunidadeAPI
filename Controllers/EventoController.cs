using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EComunidadeAPI.Data;
using EComunidadeAPI.Models;
using Microsoft.AspNetCore.Authorization;
namespace EComunidadeAPI.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class EventoController : ControllerBase
   {
       private readonly DataContext _context;
       public EventoController(DataContext context)
       {
           _context = context;
       }

       [Authorize]
       [HttpGet]
       public async Task<ActionResult<IEnumerable<Evento>>> GetEventos()
       {
           return await _context.Eventos.ToListAsync();
       }
       [Authorize]
       [HttpGet("{id}")]
       public async Task<ActionResult<Evento>> GetEvento(int id)
       {
           var evento = await _context.Eventos.FindAsync(id);
           if (evento == null)
               return NotFound();
           return evento;
       }
       [Authorize]
       [HttpPost]
       public async Task<ActionResult<Evento>> PostEvento(Evento evento)
       {
           _context.Eventos.Add(evento);
           await _context.SaveChangesAsync();
           return CreatedAtAction(nameof(GetEvento), new { id = evento.IdEvento }, evento);
       }
       [Authorize]
       [HttpPut("{id}")]
       public async Task<IActionResult> PutEvento(int id, Evento evento)
       {
           if (id != evento.IdEvento)
               return BadRequest();
           _context.Entry(evento).State = EntityState.Modified;
           await _context.SaveChangesAsync();
           return NoContent();
       }
       [Authorize]
       [HttpDelete("{id}")]
       public async Task<IActionResult> DeleteEvento(int id)
       {
           var evento = await _context.Eventos.FindAsync(id);
           if (evento == null)
               return NotFound();
           _context.Eventos.Remove(evento);
           await _context.SaveChangesAsync();
           return NoContent();
       }

       [AllowAnonymous]
       [HttpGet("publico")]
       public IActionResult TestePublico()
       {
           return Ok("Esse endpoint é público.");
       }

       [Authorize]
       [HttpGet("protegido")]
       public IActionResult TesteProtegido()
       {
           return Ok("Você acessou um endpoint protegido com JWT!");
       }
   }
}