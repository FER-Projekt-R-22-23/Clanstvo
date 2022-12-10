using Clanstvo.Repositories;
using Microsoft.AspNetCore.Mvc;
using ClanstvoWebApi.DTOs;
using DbModels = Clanstvo.DataAccess.SqlServer.Data.DbModels;
using Clanstvo.Commons;

namespace ClanstvoWebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ClanController : ControllerBase
{
    private readonly IClanRepository<int, DbModels.Clan> _clanRepository;


    public ClanController(IClanRepository<int, DbModels.Clan> clanRepository)
    {
        _clanRepository = clanRepository;
    }

    // GET: api/Clanovi
    [HttpGet]
    public ActionResult<IEnumerable<Clan>> GetAllClan()
    {
        return Ok(_clanRepository.GetAll().Select(DtoMapping.ToDto));
    }

    // GET: api/Clanovi/5
    [HttpGet("{id}")]
    public ActionResult<Clan> GetClan(int id)
    {
        var clanOption = _clanRepository.Get(id).Map(DtoMapping.ToDto);

        return clanOption
            ? Ok(clanOption.Data)
            : NotFound();
    }

    [HttpGet("/Aggregate/{id}")]
    public ActionResult<ClanAggregate> GetPersonAggregate(int id)
    {
        var clanOption = _clanRepository.GetAggregate(id).Map(DtoMapping.ToAggregateDto);

        return clanOption
           ? Ok(clanOption.Data)
           : NotFound();
    }


    // PUT: api/Clan/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public IActionResult EditClan(int id, Clan clan)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (id != clan.Id)
        {
            return BadRequest();
        }

        if (!_clanRepository.Exists(id))
        {
            return NotFound();
        }

        return _clanRepository.Update(clan.ToDbModel())
            ? AcceptedAtAction("EditClan", clan)
            : StatusCode(500);
    }

    // POST: api/Clan
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public ActionResult<Clan> CreateClan(Clan clan)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return _clanRepository.Insert(clan.ToDbModel())
            ? CreatedAtAction("GetClan", new { id = clan.Id }, clan)
            : StatusCode(500);
    }

    // DELETE: api/Clan/5
    [HttpDelete("{id}")]
    public IActionResult DeleteClan(int id)
    {
      if(!_clanRepository.Exists(id))
            return NotFound();

      return _clanRepository.Remove(id)
            ? NoContent()
            : StatusCode(500);
    }
}
