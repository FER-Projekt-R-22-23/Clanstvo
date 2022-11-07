
using Clanstvo.DataAccess.SqlServer.Data.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DbModels = Clanstvo.DataAccess.SqlServer.Data.DbModels;

namespace ClanstvoWebApi.DTOs
{


    public partial class Clanarine
    {
        [Key]
        public int Id { get; set; }
        public bool Placenost { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal Iznos { get; set; }
        public int Godina { get; set; }
        public int ClanId { get; set; }
        [Column(TypeName = "date")]
        public DateTime Datum { get; set; }
    }
    public static partial class DtoMapping
    {
        public static Clanarine ToDto(this DbModels.Clanarine clanarine)
            => new Clanarine()
            {
                Id = clanarine.Id,
                Placenost = clanarine.Placenost,
                Iznos = clanarine.Iznos,
                Godina = clanarine.Godina,
                ClanId = clanarine.ClanId,
                Datum = clanarine.Datum
            };

        public static DbModels.Clanarine ToDbModel(this Clanarine clanarine)
            => new DbModels.Clanarine()
            {
                Id = clanarine.Id,
                Placenost = clanarine.Placenost,
                Iznos = clanarine.Iznos,
                Godina = clanarine.Godina,
                ClanId = clanarine.ClanId,
                Datum = clanarine.Datum
            };
    }
}
