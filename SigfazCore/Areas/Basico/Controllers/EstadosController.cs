using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SigfazCore.Areas.Basico.Models;
using SigfazCore.Areas.Basico.Request;
using SigfazCore.Models;

namespace SigfazCore.Areas.Basico.Controllers
{
    [Produces("application/json")]
    [Route("api/Estados")]
    public class EstadosController : Controller
    {
        private readonly SigfazCoreContext _context;

        public EstadosController(SigfazCoreContext context)
        {
            _context = context;
        }

        // GET: api/Estados
        [HttpGet]
        public IEnumerable<EstadoRequest> GetEstado()
        {
            var request = from b in _context.Estado
                          select new EstadoRequest()
                          {
                              EstadoId = b.ID,
                              Nome = b.Nome,
                              Sigla = b.Sigla
                          };
            return request;
        }



    // GET: api/Estados/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEstado([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var estado = await _context.Estado.SingleOrDefaultAsync(m => m.ID == id);

        if (estado == null)
        {
            return NotFound();
        }

        return Ok(estado);
    }

    // PUT: api/Estados/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEstado([FromRoute] int id, [FromBody] Estado estado)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (id != estado.ID)
        {
            return BadRequest();
        }

        _context.Entry(estado).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EstadoExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Estados
    [HttpPost]
    public async Task<IActionResult> PostEstado([FromBody] Estado estado)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Estado.Add(estado);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEstado", new { id = estado.ID }, estado);
    }

    // DELETE: api/Estados/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEstado([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var estado = await _context.Estado.SingleOrDefaultAsync(m => m.ID == id);
        if (estado == null)
        {
            return NotFound();
        }

        _context.Estado.Remove(estado);
        await _context.SaveChangesAsync();

        return Ok(estado);
    }

    private bool EstadoExists(int id)
    {
        return _context.Estado.Any(e => e.ID == id);
    }
    }
}   