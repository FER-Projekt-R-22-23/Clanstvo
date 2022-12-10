
using Clanstvo.DataAccess.SqlServer.Data.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DbModels = Clanstvo.DataAccess.SqlServer.Data.DbModels;

namespace ClanstvoWebApi.DTOs
{


    public partial class Clanarina
    {
        [Key]
        public int Id { get; set; }
        public bool Placenost { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal Iznos { get; set; }
        public int Godina { get; set; }
        public int ClanId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Datum { get; set; }
    }
    public static partial class DtoMapping
    {
        public static Clanarina ToDto(this DbModels.Clanarina clanarina)
            => new Clanarina()
            {
                Id = clanarina.Id,
                Placenost = clanarina.Placenost,
                Iznos = clanarina.Iznos,
                Godina = clanarina.Godina,
                ClanId = clanarina.ClanId,
                Datum = clanarina.Datum
            };

        public static DbModels.Clanarina ToDbModel(this Clanarina clanarina)
            => new DbModels.Clanarina()
            {
                Id = clanarina.Id,
                Placenost = clanarina.Placenost,
                Iznos = clanarina.Iznos,
                Godina = clanarina.Godina,
                ClanId = clanarina.ClanId,
                Datum = clanarina.Datum
            };

           /* => new DomainModels.Clanarina(
                clanarina.Id,
                clanarina.Placenost,
                clanarina.Iznos,
                clanarina.Godina,
                clanarina.ClanId,
                clanarina.Datum
            )*/
    }
}
