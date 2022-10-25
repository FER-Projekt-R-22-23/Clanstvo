using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClanstvoWebApi.Data;
using ClanstvoWebApi.Data.DbModels;

namespace ClanstvoWebApi.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RangStarostController : ControllerBase
    {
        private readonly ClanstvoContext _context;

        public RangStarostController(ClanstvoContext context)
        {
            _context = context;
        }

        // GET: api/RangStarost
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RangStarost>>> GetRangStarost()
        {
            return await _context.RangStarost.ToListAsync();
        }

        // GET: api/RangStarost/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RangStarost>> GetRangStarost(int id)
        {
            var rangStarost = await _context.RangStarost.FindAsync(id);

            if (rangStarost == null)
            {
                return NotFound();
            }

            return rangStarost;
        }

        // PUT: api/RangStarost/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRangStarost(int id, RangStarost rangStarost)
        {
            if (id != rangStarost.Id)
            {
                return BadRequest();
            }

            _context.Entry(rangStarost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RangStarostExists(id))
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

        // POST: api/RangStarost
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RangStarost>> PostRangStarost(RangStarost rangStarost)
        {
            _context.RangStarost.Add(rangStarost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRangStarost", new { id = rangStarost.Id }, rangStarost);
        }

        // DELETE: api/RangStarost/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRangStarost(int id)
        {
            var rangStarost = await _context.RangStarost.FindAsync(id);
            if (rangStarost == null)
            {
                return NotFound();
            }

            _context.RangStarost.Remove(rangStarost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RangStarostExists(int id)
        {
            return _context.RangStarost.Any(e => e.Id == id);
        }
    }
}
