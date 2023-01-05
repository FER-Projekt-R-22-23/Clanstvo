using BaseLibrary;
using Microsoft.AspNetCore.Mvc;
using Clanstvo.Providers;
using Clanstvo.Providers.Http.DTOs;
using ClanstvoWebApi.DTOs;
using DtoMapping = ClanstvoWebApi.DTOs.DtoMapping;

namespace ClanstvoWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AkcijeController : ControllerBase
{
    private readonly IAkcijeSkoleProvider _akcijeSkoleProvider;

    public AkcijeController(IAkcijeSkoleProvider akcijeSkoleProvider)
    {
        _akcijeSkoleProvider = akcijeSkoleProvider;
    }

    //[HttpGet("Akcije")]
    /*
    public ActionResult<IEnumerable<Akcija>> GetNeplaceneClanarine([FromQuery] int[] listOfIds)
    {
        var akcijaResult = _akcijeSkoleProvider.GetDidntPay(listOfIds.ToList())
            .Map(c => c.Select(clanarina => clanarina.ToDto()));

        Console.WriteLine(clanoviResult.Data);

        return clanoviResult
            ? Ok(clanoviResult.Data)
            : Problem(clanoviResult.Message, statusCode: 500);
    }
    */

}