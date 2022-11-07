using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace Clanstvo.DataAccess.SqlServer.DTOs
{
    internal class ClanoviDto
    {
        public ClanoviDto()
        {
            ClanRangStarost = new HashSet<ClanRangStarostDto>();
            ClanRangZasluga = new HashSet<ClanRangZaslugaDto>();
            Clanarine = new HashSet<ClanarineDto>();
        }

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
        public virtual ICollection<ClanRangStarostDto> ClanRangStarost { get; set; }
        [InverseProperty("Clan")]
        public virtual ICollection<ClanRangZaslugaDto> ClanRangZasluga { get; set; }
        [InverseProperty("Clan")]
        public virtual ICollection<ClanarineDto> Clanarine { get; set; }
    }
}
