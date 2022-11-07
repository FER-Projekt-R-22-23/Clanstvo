using Clanstvo.DataAccess.SqlServer.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DbModels = Clanstvo.DataAccess.SqlServer.Data.DbModels;

namespace ClanstvoWebApi.DTOs
{


    public partial class Clanovi
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Ime { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Prezime { get; set; }
        [Column(TypeName = "date")]
        public DateTime DatumRodenja { get; set; }
        public byte[] Slika { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Adresa { get; set; }
        public bool ImaMaramu { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DatumMarama { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string MjestoMarama { get; set; }
    }
    public static partial class DtoMapping
    {
        public static Clanovi ToDto(this DbModels.Clanovi clan)
            => new Clanovi()
            {
                Id = clan.Id,
                Ime = clan.Ime,
                Prezime = clan.Prezime,
                Slika = clan.Slika,
                DatumRodenja = clan.DatumRodenja,
                Adresa = clan.Adresa,
                ImaMaramu = clan.ImaMaramu,
                DatumMarama = clan.DatumMarama,
                MjestoMarama = clan.MjestoMarama,
            };

        public static DbModels.Clanovi ToDbModel(this Clanovi clan
            )
            => new DbModels.Clanovi()
            {
                Id = clan.Id,
                Ime = clan.Ime,
                Prezime = clan.Prezime,
                Slika = clan.Slika,
                DatumRodenja = clan.DatumRodenja,
                Adresa = clan.Adresa,
                ImaMaramu = clan.ImaMaramu,
                DatumMarama = clan.DatumMarama,
                MjestoMarama = clan.MjestoMarama,
            };
    }
}

