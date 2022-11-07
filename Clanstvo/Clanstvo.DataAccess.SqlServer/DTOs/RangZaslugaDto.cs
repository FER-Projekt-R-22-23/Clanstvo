using ClanstvoWebApi.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clanstvo.DataAccess.SqlServer.DTOs
{
    internal class RangZaslugaDto
    {
        
        public RangZaslugaDto()
        {
            ClanRangZasluga = new HashSet<ClanRangZaslugaDto>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Naziv { get; set; }

        [InverseProperty("RangZasluga")]
        public virtual ICollection<ClanRangZaslugaDto> ClanRangZasluga { get; set; }
    
}
}
