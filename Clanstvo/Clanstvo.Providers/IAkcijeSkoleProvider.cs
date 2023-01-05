using BaseLibrary;
using Clanstvo.Domain.Models;

namespace Clanstvo.Providers;

public interface IAkcijeSkoleProvider
{
    // TO DO
    // public Result<IEnumerable<Clan>> GetDidntPay(IEnumerable<int> ids);
    public Result<IEnumerable<Skola>> GetSkoleClana(int id);
    public Result<IEnumerable<Akcija>> GetAkcijeClana(int id);
}