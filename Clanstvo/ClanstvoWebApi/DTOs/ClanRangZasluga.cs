using Clanstvo.DataAccess.SqlServer.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DbModels = Clanstvo.DataAccess.SqlServer.Data.DbModels;

namespace ClanstvoWebApi.DTOs
{
    public partial class ClanRangZasluga
    {
        [Key]
        public int ClanId { get; set; }
        [Key]
        public int RangZaslugaId { get; set; }
        [Column(TypeName = "date")]
        public DateTime Datum { get; set; }
    }
    public static partial class DtoMapping
    {
        public static ClanRangZasluga ToDto(this DbModels.ClanRangZasluga clan)
            => new ClanRangZasluga()
            {
                ClanId = clan.ClanId,
                RangZaslugaId = clan.RangZaslugaId,
                Datum = clan.Datum
            };

        public static DbModels.ClanRangZasluga ToDbModel(this ClanRangZasluga clan
            )
            => new DbModels.ClanRangZasluga()
            {
                ClanId = clan.ClanId,
                RangZaslugaId = clan.RangZaslugaId,
                Datum = clan.Datum
            };
    }
}
