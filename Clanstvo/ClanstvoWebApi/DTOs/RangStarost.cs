using Clanstvo.DataAccess.SqlServer.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DbModels = Clanstvo.DataAccess.SqlServer.Data.DbModels;

namespace ClanstvoWebApi.DTOs
{
    public partial class RangStarost
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
        public static RangStarost ToDto(this DbModels.RangStarost clan)
            => new RangStarost()
            {
                Id = clan.Id,
                Naziv = clan.Naziv,
            };

        public static DbModels.RangStarost ToDbModel(this RangStarost clan
            )
            => new DbModels.RangStarost()
            {

                Id = clan.Id,
                Naziv = clan.Naziv,
            };
    }
}