using Clanstvo.Repositories;
using Microsoft.AspNetCore.Mvc;
using ClanstvoWebApi.DTOs;
using DbModels = Clanstvo.DataAccess.SqlServer.Data.DbModels;
using Clanstvo.Commons;

namespace ClanstvoWebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ClanoviController : ControllerBase
{
    private readonly IClanoviRepository<int, DbModels.Clanovi> _clanoviRepository;


    public ClanoviController(IClanoviRepository<int, DbModels.Clanovi> clanoviRepository)
    {
        _clanoviRepository = clanoviRepository;
    }

    // GET: api/Clanovi
    [HttpGet]
    public ActionResult<IEnumerable<Clanovi>> GetAllClanovi()
    {
        return Ok(_clanoviRepository.GetAll().Select(DtoMapping.toDto));
    }

    // GET: api/Clanovi/5
    [HttpGet("{id}")]
    public ActionResult<Clanovi> GetClanovi(int id)
    {
        var clanoviOption = _clanoviRepository.Get(id).Map(DtoMapping.toDto);

        return clanoviOption
            ? Ok(clanoviOption.Data)
            : NotFound();
    }

    // PUT: api/Clanovi/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public IActionResult EditClanovi(int id, Clanovi clanovi)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (id != clanovi.Id)
        {
            return BadRequest();
        }

        if (!_clanoviRepository.Exists(id))
        {
            return NotFound();
        }

        return _clanoviRepository.Update(clanovi.ToDbModel())
            ? AcceptedAtAction("EditPerson", clanovi)
            : StatusCode(500);
    }

    // POST: api/Clanovi
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public ActionResult<Clanovi> CreateClanovi(Clanovi clanovi)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return _clanoviRepository.Insert(clanovi.ToDbModel())
            ? CreatedAtAction("GetClanovi", new { id = clanovi.Id }, clanovi)
            : StatusCode(500);
    }

    // DELETE: api/Clanovi/5
    [HttpDelete("{id}")]
    public IActionResult DeleteClanovi(int id)
    {
      if(!_clanoviRepository.Exists(id))
            return NotFound();

      return _clanoviRepository.Remove(id)
            ? NoContent()
            : StatusCode(500);
    }
}
