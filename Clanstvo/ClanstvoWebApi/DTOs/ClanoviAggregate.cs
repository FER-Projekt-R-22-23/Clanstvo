using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Clanstvo.DataAccess.SqlServer.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DbModels = Clanstvo.DataAccess.SqlServer.Data.DbModels;

namespace ClanstvoWebApi.DTOs
{
    public class ClanoviAggregate
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

        [InverseProperty("Clan")]
        public virtual ICollection<ClanRangStarost> ClanRangStarost { get; set; }
        [InverseProperty("Clan")]
        public virtual ICollection<ClanRangZasluga> ClanRangZasluga { get; set; }
        [InverseProperty("Clan")]
        public virtual ICollection<Clanarine> Clanarine { get; set; }
    }
    public static partial class DtoMapping
    {
        public static ClanoviAggregate ToAggregateDto(this DbModels.Clanovi clan)
            => new ClanoviAggregate()
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
                ClanRangStarost = clan.ClanRangStarost == null
                                ? new List<ClanRangStarost>()
                                : clan.ClanRangStarost.Select(pr => pr.ToDto()).ToList(),
                ClanRangZasluga = clan.ClanRangZasluga == null
                                ? new List<ClanRangZasluga>()
                                : clan.ClanRangZasluga.Select(pr => pr.ToDto()).ToList(),
                Clanarine = clan.Clanarine == null
                                ? new List<Clanarine>()
                                : clan.Clanarine.Select(pr => pr.ToDto()).ToList()
            };

        public static DbModels.Clanovi ToDbModel(ClanoviAggregate clan)
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
                ClanRangStarost = clan.ClanRangStarost.Select(pr => pr.ToDbModel(clan.Id)).ToList(),
                ClanRangZasluga = clan.ClanRangZasluga.Select(pr => pr.ToDbModel(clan.Id)).ToList()
            };
    }
}
