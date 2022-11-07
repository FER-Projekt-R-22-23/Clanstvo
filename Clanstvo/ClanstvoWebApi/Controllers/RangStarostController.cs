using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clanstvo.Repositories;
using ClanstvoWebApi.DTOs;
using DbModels = Clanstvo.DataAccess.SqlServer.Data.DbModels;
using Clanstvo.Commons;

namespace ClanstvoWebApi.Contollers

    // made by Luka Slugečić, Anton Macan, Bruno Rački
{
    [Route("api/[controller]")]
    [ApiController]
    public class RangStarostController : ControllerBase
    {
        private readonly IRangStarostRepository<int, DbModels.RangStarost> _rangStarostRepository;

        public RangStarostController(IRangStarostRepository<int, DbModels.RangStarost> context)
        {
            _rangStarostRepository = context;
        }

        // GET: api/RangStarost
        [HttpGet]
        public ActionResult<IEnumerable<RangStarost>> GetAllRangStarost()
        {
            return Ok(_rangStarostRepository.GetAll().Select(DtoMapping.ToDto));
        }

        // GET: api/RangStarost/5
        [HttpGet("{id}")]
        public ActionResult<RangStarost> GetRangStarost(int id)
        {
            var rangStarostOption = _rangStarostRepository.Get(id).Map(DtoMapping.ToDto);

            return rangStarostOption
                ? Ok(rangStarostOption.Data)
                : NotFound();
        }

        // PUT: api/RangStarost/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult EditRangStarost(int id, RangStarost rangStarost)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rangStarost.Id)
            {
                return BadRequest();
            }

            if (!_rangStarostRepository.Exists(id))
            {
                return NotFound();
            }

            return _rangStarostRepository.Update(rangStarost.ToDbModel())
                ? AcceptedAtAction("EditRangStarost", rangStarost)
                : StatusCode(500);
        }

        // POST: api/RangStarost
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<RangStarost> CreateRangStarost(RangStarost rangStarost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return _rangStarostRepository.Insert(rangStarost.ToDbModel())
                ? CreatedAtAction("GetRangStarost", new { id = rangStarost.Id }, rangStarost)
                : StatusCode(500);
        }

        // DELETE: api/RangStarost/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRangStarost(int id)
        {
            if (!_rangStarostRepository.Exists(id))
                return NotFound();

            return _rangStarostRepository.Remove(id)
                ? NoContent()
                : StatusCode(500);
        }
    }
}
