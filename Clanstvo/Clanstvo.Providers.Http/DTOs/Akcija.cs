
namespace Clanstvo.Providers.Http.DTOs
{


    public class Akcija
    {
        public int IdAkcije { get; set; }

        public string Naziv { get; set; } = String.Empty;
   
    }


    public static partial class DtoMapping
    {
        public static Akcija ToDto(this Domain.Models.Akcija akcija)
        {
            return new Akcija()
            {
                IdAkcije = akcija.Id,
                Naziv = akcija.Naziv
            };
        }

        
        public static Domain.Models.Akcija ToDomain(this Akcija akcija)
        {
            return new Domain.Models.Akcija(akcija.IdAkcije, akcija.Naziv);
        }

    }
}
