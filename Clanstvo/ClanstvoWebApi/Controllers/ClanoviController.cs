using Clanstvo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clanstvo.DataAccess.SqlServer.Data.DbModels;

namespace ClanstvoWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClanoviController : ControllerBase
{
    private readonly IClanoviRepository<int, Clanovi> _clanoviRepository;


    public ClanoviController(IClanoviRepository<int, Clanovi> clanoviRepository)
    {
        _clanoviRepository = clanoviRepository;
    }

    // GET: api/Clanovi
    [HttpGet]
    public ActionResult<Clanovi> GetClanovi()
    {
        return Ok(_clanoviRepository.GetAll());
    }

    // GET: api/Clanovi/5
    [HttpGet("{id}")]
    public ActionResult<Clanovi> GetClanovi(int id)
    {
        var clanoviOption = _clanoviRepository.GetAggregate(id);

        return clanoviOption
            ? Ok(clanoviOption.Data)
            : NotFound();
    }

    // PUT: api/Clanovi/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public IActionResult EditClanovi(int id, Clanovi clanovi)
    {
        if (id != clanovi.Id)
        {
            return BadRequest();
        }

        if (!_clanoviRepository.Exists(id))
        {
            return NotFound();
        }

        return _clanoviRepository.Update(clanovi)
            ? AcceptedAtAction("EditClanovi", clanovi)
            : StatusCode(500);
    }

    // POST: api/Clanovi
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public ActionResult<Clanovi> CreateClanovi(Clanovi clanovi)
    {
        return _clanoviRepository.Insert(clanovi)
            ? CreatedAtAction("GetClanovi", new {id = clanovi.Id}, clanovi)
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
