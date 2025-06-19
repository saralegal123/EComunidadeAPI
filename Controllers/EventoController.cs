using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EComunidadeAPI.Data;
using EComunidadeAPI.Models;
using Microsoft.Extensions.Configuration;
using EComunidadeAPI.Models.Enuns;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens; 
using System.Text; 
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using EComunidadeAPI.Extensions;

namespace EComunidadeAPI.Controllers
{
    [ApiController]
   [Route("[controller]")]
   public class EventoController : ControllerBase
   {
       private readonly AppDbContext _context;
       public EventoController(AppDbContext context)
       {
           _context = context;
       }
       [HttpGet]
       public async Task<ActionResult<IEnumerable<Evento>>> GetEventos()
       {
           return await _context.Eventos.ToListAsync();
       }
       [HttpGet("{id}")]
       public async Task<ActionResult<Evento>> GetEvento(int id)
       {
           var evento = await _context.Eventos.FindAsync(id);
           if (evento == null)
               return NotFound();
           return evento;
       }
       [HttpPost]
       public async Task<ActionResult<Evento>> PostEvento(Evento evento)
       {
           _context.Eventos.Add(evento);
           await _context.SaveChangesAsync();
           return CreatedAtAction(nameof(GetEvento), new { id = evento.IdEvento }, evento);
       }
       [HttpPut("{id}")]
       public async Task<IActionResult> PutEvento(int id, Evento evento)
       {
           if (id != evento.IdEvento)
               return BadRequest();
           _context.Entry(evento).State = EntityState.Modified;
           await _context.SaveChangesAsync();
           return NoContent();
       }
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
    }
}