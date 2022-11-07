using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clanstvo.DataAccess.SqlServer.Data.DbModels;

namespace ClanstvoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClanarineController : ControllerBase
    {
        private readonly ClanstvoContext _context;

        public ClanarineController(ClanstvoContext context)
        {
            _context = context;
        }

        // GET: api/Clanarine
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clanarine>>> GetClanarine()
        {
            return await _context.Clanarine.ToListAsync();
        }

        // GET: api/Clanarine/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clanarine>> GetClanarine(int id)
        {
            var clanarine = await _context.Clanarine.FindAsync(id);

            if (clanarine == null)
            {
                return NotFound();
            }

            return clanarine;
        }

        // PUT: api/Clanarine/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClanarine(int id, Clanarine clanarine)
        {
            if (id != clanarine.Id)
            {
                return BadRequest();
            }

            _context.Entry(clanarine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClanarineExists(id))
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

        // POST: api/Clanarine
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clanarine>> PostClanarine(Clanarine clanarine)
        {
            _context.Clanarine.Add(clanarine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClanarine", new { id = clanarine.Id }, clanarine);
        }

        // DELETE: api/Clanarine/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClanarine(int id)
        {
            var clanarine = await _context.Clanarine.FindAsync(id);
            if (clanarine == null)
            {
                return NotFound();
            }

            _context.Clanarine.Remove(clanarine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClanarineExists(int id)
        {
            return _context.Clanarine.Any(e => e.Id == id);
        }
    }
}
