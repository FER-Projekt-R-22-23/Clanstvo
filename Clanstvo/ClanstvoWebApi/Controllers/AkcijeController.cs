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

    [HttpGet("Akcije")]
    public ActionResult<IEnumerable<AkcijaSudionik>> GetAkcijeSudionika([FromQuery] int id)
    {
        var akcijaResult = _akcijeSkoleProvider.GetAkcijeClana(id);

        Console.WriteLine(akcijaResult.Data);

        return akcijaResult
            ? Ok(akcijaResult.Data)
            : Problem(akcijaResult.Message, statusCode: 500);
    }

    [HttpGet("Skole")]
    public ActionResult<IEnumerable<SkolaSudionik>> GetSkoleSudionika([FromQuery] int id)
    {
        var skolaResult = _akcijeSkoleProvider.GetSkoleClana(id);

        Console.WriteLine(skolaResult.Data);

        return skolaResult
            ? Ok(skolaResult.Data)
            : Problem(skolaResult.Message, statusCode: 500);
    }


}