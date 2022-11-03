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
    public class ClanRangZaslugaController : ControllerBase
    {
        private readonly ClanstvoContext _context;

        public ClanRangZaslugaController(ClanstvoContext context)
        {
            _context = context;
        }

        // GET: api/ClanRangZasluga
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClanRangZasluga>>> GetClanRangZasluga()
        {
            return await _context.ClanRangZasluga.ToListAsync();
        }

        // GET: api/ClanRangZasluga/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClanRangZasluga>> GetClanRangZasluga(int id)
        {
            var clanRangZasluga = await _context.ClanRangZasluga.FindAsync(id);

            if (clanRangZasluga == null)
            {
                return NotFound();
            }

            return clanRangZasluga;
        }

        // PUT: api/ClanRangZasluga/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClanRangZasluga(int id, ClanRangZasluga clanRangZasluga)
        {
            if (id != clanRangZasluga.ClanId)
            {
                return BadRequest();
            }

            _context.Entry(clanRangZasluga).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClanRangZaslugaExists(id))
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

        // POST: api/ClanRangZasluga
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClanRangZasluga>> PostClanRangZasluga(ClanRangZasluga clanRangZasluga)
        {
            _context.ClanRangZasluga.Add(clanRangZasluga);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClanRangZaslugaExists(clanRangZasluga.ClanId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClanRangZasluga", new { id = clanRangZasluga.ClanId }, clanRangZasluga);
        }

        // DELETE: api/ClanRangZasluga/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClanRangZasluga(int id)
        {
            var clanRangZasluga = await _context.ClanRangZasluga.FindAsync(id);
            if (clanRangZasluga == null)
            {
                return NotFound();
            }

            _context.ClanRangZasluga.Remove(clanRangZasluga);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClanRangZaslugaExists(int id)
        {
            return _context.ClanRangZasluga.Any(e => e.ClanId == id);
        }
    }
}
