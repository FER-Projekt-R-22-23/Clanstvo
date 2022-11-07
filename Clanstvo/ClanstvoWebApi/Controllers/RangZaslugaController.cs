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
    public class RangZaslugaController : ControllerBase
    {
        private readonly ClanstvoContext _context;

        public RangZaslugaController(ClanstvoContext context)
        {
            _context = context;
        }

        // GET: api/RangZasluga
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RangZasluga>>> GetRangZasluga()
        {
            return await _context.RangZasluga.ToListAsync();
        }

        // GET: api/RangZasluga/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RangZasluga>> GetRangZasluga(int id)
        {
            var rangZasluga = await _context.RangZasluga.FindAsync(id);

            if (rangZasluga == null)
            {
                return NotFound();
            }

            return rangZasluga;
        }

        // PUT: api/RangZasluga/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRangZasluga(int id, RangZasluga rangZasluga)
        {
            if (id != rangZasluga.Id)
            {
                return BadRequest();
            }

            _context.Entry(rangZasluga).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RangZaslugaExists(id))
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

        // POST: api/RangZasluga
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RangZasluga>> PostRangZasluga(RangZasluga rangZasluga)
        {
            _context.RangZasluga.Add(rangZasluga);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRangZasluga", new { id = rangZasluga.Id }, rangZasluga);
        }

        // DELETE: api/RangZasluga/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRangZasluga(int id)
        {
            var rangZasluga = await _context.RangZasluga.FindAsync(id);
            if (rangZasluga == null)
            {
                return NotFound();
            }

            _context.RangZasluga.Remove(rangZasluga);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RangZaslugaExists(int id)
        {
            return _context.RangZasluga.Any(e => e.Id == id);
        }
    }
}
