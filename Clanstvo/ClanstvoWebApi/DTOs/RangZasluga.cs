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

        [Required(ErrorMessage = "Role name can't be empty", AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Role name can't be longer than 50 characters")]
        public string Naziv { get; set; } = string.Empty;

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

        /* => new DomainModels.RangZasluga(
               clan.Id,
               clan.Naziv
           ) */
    }
}
