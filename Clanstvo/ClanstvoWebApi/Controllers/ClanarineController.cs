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
    public class ClanarineController : ControllerBase
    {
        private readonly IClanarineRepository<int, DbModels.Clanarine> _clanarineRepository;

        public ClanarineController(IClanarineRepository<int, DbModels.Clanarine> context)
        {
            _clanarineRepository = context;
        }

        // GET: api/Clanarine
        [HttpGet]
        public ActionResult<IEnumerable<Clanarine>> GetAllClanarine()
        {
            return Ok(_clanarineRepository.GetAll().Select(DtoMapping.ToDto));
        }

        // GET: api/Clanarine/5
        [HttpGet("{id}")]
        public ActionResult<Clanarine> GetClanarine(int id)
        {
            var Clanarine = _clanarineRepository.Get(id).Map(DtoMapping.ToDto);

            return clanarineOption
                ? Ok(clanarineOption.Data)
                : NotFound();
        }

        // PUT: api/Clanarine/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult EditRangStarost(int id, Clanarine clanarine)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clanarine.Id)
            {
                return BadRequest();
            }

            if (!_clanarineRepository.Exists(id))
            {
                return NotFound();
            }

            return _clanarineRepository.Update(clanarine.ToDbModel())
                ? AcceptedAtAction("EditClanarine", clanarine)
                : StatusCode(500);
        }

        // POST: api/Clanarine
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Clanarine> CreateClanarine(Clanarine clanarine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return _clanarineRepository.Insert(clanarine.ToDbModel())
                ? CreatedAtAction("GetClanarine", new { id = clanarine.Id }, clanarine)
                : StatusCode(500);
        }

        // DELETE: api/Clanarine/5
        [HttpDelete("{id}")]
        public IActionResult DeleteClanarine(int id)
        {
            if (!_clanarineRepository.Exists(id))
                return NotFound();

            return _clanarineRepository.Remove(id)
                ? NoContent()
                : StatusCode(500);
        }
    }
}
