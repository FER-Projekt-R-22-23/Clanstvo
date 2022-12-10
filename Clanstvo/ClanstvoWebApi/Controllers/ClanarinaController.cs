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
    public class ClanarinaController : ControllerBase
    {
        private readonly IClanarinaRepository<int, DbModels.Clanarina> _clanarinaRepository;

        public ClanarinaController(IClanarinaRepository<int, DbModels.Clanarina> context)
        {
            _clanarinaRepository = context;
        }

        // GET: api/Clanarine
        [HttpGet]
        public ActionResult<IEnumerable<Clanarina>> GetAllClanarina()
        {
            return Ok(_clanarinaRepository.GetAll().Select(DtoMapping.ToDto));
        }

        // GET: api/Clanarine/5
        [HttpGet("{id}")]
        public ActionResult<Clanarina> GetClanarina(int id)
        {
            var clanarinaOption = _clanarinaRepository.Get(id).Map(DtoMapping.ToDto);

            return clanarinaOption
                ? Ok(clanarinaOption.Data)
                : NotFound();
        }

        // PUT: api/Clanarine/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult EditClanarina(int id, Clanarina clanarina)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clanarina.Id)
            {
                return BadRequest();
            }

            if (!_clanarinaRepository.Exists(id))
            {
                return NotFound();
            }

            return _clanarinaRepository.Update(clanarina.ToDbModel())
                ? AcceptedAtAction("EditClanarina", clanarina)
                : StatusCode(500);
        }

        // POST: api/Clanarina
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Clanarina> CreateClanarina(Clanarina clanarina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return _clanarinaRepository.Insert(clanarina.ToDbModel())
                ? CreatedAtAction("GetClanarina", new { id = clanarina.Id }, clanarina)
                : StatusCode(500);
        }

        // DELETE: api/Clanarina/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClanarina(int id)
        {
            if (!_clanarinaRepository.Exists(id))
                return NotFound();

            return _clanarinaRepository.Remove(id)
                ? NoContent()
                : StatusCode(500);
        }
    }
}
