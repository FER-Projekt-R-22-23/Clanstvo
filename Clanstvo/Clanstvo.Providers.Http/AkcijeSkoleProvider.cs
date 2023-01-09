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
        var akcijaResult = _httpClient.GetFromJsonAsync<IEnumerable<AkcijaSudionik>>($"api/Akcije/polaznici/{id}");
        Console.WriteLine(akcijaResult);

        if (akcijaResult.Result!.Any())
        {
            var akcije = akcijaResult.Result!.Select(a => AkcijaSudionik.DtoMapping.ToDomain(a));

            return Results.OnSuccess(akcije);
        }

        return Results.OnFailure<IEnumerable<Akcija>>("Clan nema zabiljezenih akcija");
    }

    public Result<IEnumerable<Skola>> GetSkoleClana(int id)
    {
        var skolaResult = _httpClient.GetFromJsonAsync<IEnumerable<SkolaSudionik>>($"/polaznik/{id}");

        if (skolaResult.Result!.Any())
        {
            var skole = skolaResult.Result!.Select(s => SkolaSudionik.DtoMapping.ToDomain(s));

            return Results.OnSuccess(skole);
        }

        return Results.OnFailure<IEnumerable<Skola>>("Clan nema zabiljezenih skola");
    }

}