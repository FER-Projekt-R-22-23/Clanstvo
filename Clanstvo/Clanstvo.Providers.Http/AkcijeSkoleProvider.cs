using System.Net.Http.Json;
using BaseLibrary;
using Clanstvo.Domain.Models;
using Clanstvo.Providers.Http.DTOs;

namespace Clanstvo.Providers.Http;

public class AkcijeSkoleProvider : IAkcijeSkoleProvider
{
    private readonly HttpClient _httpClient;

    public AkcijeSkoleProvider(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("AkcijeSkole");
    }

    
    public Result<IEnumerable<Akcija>> GetAkcijeClana(int id)
    {
        var akcijaResult = _httpClient.GetFromJsonAsync<IEnumerable<AkcijaSudionik>>("/polaznici/");

        if (akcijaResult.Result != null)
        {
            var akcije = akcijaResult.Result.Select(c => AkcijaSudionik.DtoMapping.ToDomain(c));

            return Results.OnSuccess(akcije);
        }

        return Results.OnFailure<IEnumerable<Akcija>>("Clanovi nemaju neplacenih clanarina");
    }

    public Result<IEnumerable<Skola>> GetSkoleClana(int id)
    {
        var skolaResult = _httpClient.GetFromJsonAsync<IEnumerable<SkolaSudionik>>("/polaznici/");

        if (skolaResult.Result != null)
        {
            var skole = skolaResult.Result.Select(c => SkolaSudionik.DtoMapping.ToDomain(c));

            return Results.OnSuccess(skole);
        }

        return Results.OnFailure<IEnumerable<Skola>>("Clanovi nemaju neplacenih clanarina");
    }

}