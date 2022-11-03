using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClanstvoWebApi.Data;
using ClanstvoWebApi.Data.DbModels;

namespace ClanstvoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClanoviController : ControllerBase
    {
        private readonly ClanstvoContext _context;

        public ClanoviController(ClanstvoContext context)
        {
            _context = context;
        }

        // GET: api/Clanovi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clanovi>>> GetClanovi()
        {
            return await _context.Clanovi.ToListAsync();
        }

        // GET: api/Clanovi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clanovi>> GetClanovi(int id)
        {
            var clanovi = await _context.Clanovi.FindAsync(id);

            if (clanovi == null)
            {
                return NotFound();
            }

            return clanovi;
        }

        // PUT: api/Clanovi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClanovi(int id, Clanovi clanovi)
        {
            if (id != clanovi.Id)
            {
                return BadRequest();
            }

            _context.Entry(clanovi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClanoviExists(id))
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

        // POST: api/Clanovi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clanovi>> PostClanovi(Clanovi clanovi)
        {
            _context.Clanovi.Add(clanovi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClanovi", new { id = clanovi.Id }, clanovi);
        }

        // DELETE: api/Clanovi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClanovi(int id)
        {
            var clanovi = await _context.Clanovi.FindAsync(id);
            if (clanovi == null)
            {
                return NotFound();
            }

            _context.Clanovi.Remove(clanovi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClanoviExists(int id)
        {
            return _context.Clanovi.Any(e => e.Id == id);
        }
    }
}
