using BaseLibrary;
using Clanstvo.Domain.Models;

namespace Clanstvo.Providers;

public interface IAkcijeSkoleProvider
{
    public Result<IEnumerable<Skola>> GetSkoleClana(int id);
    public Result<IEnumerable<Akcija>> GetAkcijeClana(int id);
}