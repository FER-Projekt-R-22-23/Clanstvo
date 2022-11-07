using Clanstvo.DataAccess.SqlServer.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DbModels = Clanstvo.DataAccess.SqlServer.Data.DbModels;

namespace ClanstvoWebApi.DTOs
{
    public partial class RangZasluga
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Naziv { get; set; }

    }
    public static partial class DtoMapping
    {
        public static RangZasluga ToDto(this DbModels.RangZasluga clan)
            => new RangZasluga()
            {
                Id = clan.Id,
                Naziv = clan.Naziv,
            };

        public static DbModels.RangZasluga ToDbModel(this RangZasluga clan
            )
            => new DbModels.RangZasluga()
            {

                Id = clan.Id,
                Naziv = clan.Naziv,
            };
    }
}
