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
    public class ClanRangStarostController : ControllerBase
    {
        private readonly ClanstvoContext _context;

        public ClanRangStarostController(ClanstvoContext context)
        {
            _context = context;
        }

        // GET: api/ClanRangStarost
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClanRangStarost>>> GetClanRangStarost()
        {
            return await _context.ClanRangStarost.ToListAsync();
        }

        // GET: api/ClanRangStarost/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClanRangStarost>> GetClanRangStarost(int id)
        {
            var clanRangStarost = await _context.ClanRangStarost.FindAsync(id);

            if (clanRangStarost == null)
            {
                return NotFound();
            }

            return clanRangStarost;
        }

        // PUT: api/ClanRangStarost/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClanRangStarost(int id, ClanRangStarost clanRangStarost)
        {
            if (id != clanRangStarost.ClanId)
            {
                return BadRequest();
            }

            _context.Entry(clanRangStarost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClanRangStarostExists(id))
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

        // POST: api/ClanRangStarost
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClanRangStarost>> PostClanRangStarost(ClanRangStarost clanRangStarost)
        {
            _context.ClanRangStarost.Add(clanRangStarost);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClanRangStarostExists(clanRangStarost.ClanId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClanRangStarost", new { id = clanRangStarost.ClanId }, clanRangStarost);
        }

        // DELETE: api/ClanRangStarost/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClanRangStarost(int id)
        {
            var clanRangStarost = await _context.ClanRangStarost.FindAsync(id);
            if (clanRangStarost == null)
            {
                return NotFound();
            }

            _context.ClanRangStarost.Remove(clanRangStarost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClanRangStarostExists(int id)
        {
            return _context.ClanRangStarost.Any(e => e.ClanId == id);
        }
    }
}
