
namespace Clanstvo.Providers.Http.DTOs
{


    public class Skola
    {
        public int IdSkole { get; set; }

        public string NazivSkole { get; set; } = String.Empty;

    }


    public static partial class DtoMapping
    {
        public static Skola ToDto(this Domain.Models.Skola skola)
        {
            return new Skola()
            {
                IdSkole = skola.Id,
                NazivSkole = skola.NazivSkole
            };
        }


        public static Domain.Models.Skola ToDomain(this Skola skola)
        {
            return new Domain.Models.Skola(skola.IdSkole, skola.NazivSkole);
        }

    }
}
