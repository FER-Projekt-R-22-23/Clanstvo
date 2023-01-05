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
        _httpClient = httpClientFactory.CreateClient("Clanstvo");
    }

    
    public Result<IEnumerable<Akcija>> GetAkcijeClana(int id)
    {
        var akcijaResult = _httpClient.GetFromJsonAsync<IEnumerable<Akcija>>("api/polaznici/");

        if (akcijaResult.Result != null)
        {
            var clanovi = akcijaResult.Result.Select(c => Akcija.DtoMapping.ToDomain(c));

            return Results.OnSuccess(clanovi);
        }

        return Results.OnFailure<IEnumerable<Akcija>>("Clanovi nemaju neplacenih clanarina");
    }
    
}