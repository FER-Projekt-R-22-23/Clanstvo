using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using Clanstvo.DataAccess.SqlServer.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using DbModels = Clanstvo.DataAccess.SqlServer.Data.DbModels;

namespace ClanstvoWebApi.DTOs
{
    public partial class ClanRangStarost
    {
        [Key]
        public int ClanId { get; set; }
        [Key]
        public int RangStarostId { get; set; }
        [Column(TypeName = "date")]
        public DateTime Datum { get; set; }
    }
    public static partial class DtoMapping
    {
        public static ClanRangStarost ToDto(this DbModels.ClanRangStarost clan)
            => new ClanRangStarost()
            {
                ClanId = clan.ClanId,
                RangStarostId = clan.RangStarostId,
                Datum = clan.Datum
            };

        public static DbModels.ClanRangStarost ToDbModel(this ClanRangStarost clan
            )
            => new DbModels.ClanRangStarost()
            {
                ClanId = clan.ClanId,
                RangStarostId = clan.RangStarostId,
                Datum = clan.Datum
            };
    }
}
