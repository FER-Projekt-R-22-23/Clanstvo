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
    internal class RangStarostDto
    {
        public RangStarostDto()
        {
            ClanRangStarost = new HashSet<ClanRangStarostDto>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Naziv { get; set; }

        [InverseProperty("RangStarost")]
        public virtual ICollection<ClanRangStarostDto> ClanRangStarost { get; set; }
    }
}
