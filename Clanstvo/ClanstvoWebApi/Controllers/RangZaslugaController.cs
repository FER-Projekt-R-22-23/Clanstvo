using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clanstvo.Repositories;
using ClanstvoWebApi.DTOs;
using DbModels = Clanstvo.DataAccess.SqlServer.Data.DbModels;
using Clanstvo.Commons;

namespace ClanstvoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RangZaslugaController : ControllerBase
    {
        private readonly IRangZaslugaRepository<int, DbModels.RangZasluga> _rangZaslugaRepository;

        public RangZaslugaController(IRangZaslugaRepository<int, DbModels.RangZasluga> context)
        {
            _rangZaslugaRepository = context;
        }

        // GET: api/RangZasluga
        [HttpGet]
        public ActionResult<IEnumerable<RangZasluga>> GetAllRangZasluga()
        {
            return Ok(_rangZaslugaRepository.GetAll().Select(DtoMapping.ToDto));
        }

        // GET: api/RangZasluga/5
        [HttpGet("{id}")]
        public ActionResult<RangZasluga> GetRangZasluga(int id)
        {
            var rangZaslugaOption =  _rangZaslugaRepository.Get(id).Map(DtoMapping.ToDto);

            return rangZaslugaOption
                ? Ok(rangZaslugaOption.Data)
                : NotFound();
        }

        // PUT: api/RangZasluga/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult EditRangZasluga(int id, RangZasluga rangZasluga)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rangZasluga.Id)
            {
                return BadRequest();
            }

            if (!_rangZaslugaRepository.Exists(id))
            {
                return NotFound();
            }

            return _rangZaslugaRepository.Update(rangZasluga.ToDbModel())
                ? AcceptedAtAction("EditRangZasluga", rangZasluga)
                : StatusCode(500);
        }

        // POST: api/RangZasluga
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<RangZasluga> CreateRole(RangZasluga rangZasluga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return _rangZaslugaRepository.Insert(rangZasluga.ToDbModel())
                ? CreatedAtAction("GetRangZasluga", new { id = rangZasluga.Id }, rangZasluga)
                : StatusCode(500);
        }

        // DELETE: api/RangZasluga/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            if (!_rangZaslugaRepository.Exists(id))
                return NotFound();

            return _rangZaslugaRepository.Remove(id)
                ? NoContent()
                : StatusCode(500);
        }
    }
}
