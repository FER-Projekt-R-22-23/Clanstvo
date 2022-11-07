using ClanstvoWebApi.Data.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clanstvo.DataAccess.SqlServer.DTOs
{
    internal class ClanarineDto
    {
        [Key]
        public int Id { get; set; }
        public bool Placenost { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal Iznos { get; set; }
        public int Godina { get; set; }
        public int ClanId { get; set; }
        [Column(TypeName = "date")]
        public DateTime Datum { get; set; }

        [ForeignKey("ClanId")]
        [InverseProperty("Clanarine")]
        public virtual ClanoviDto Clan { get; set; }
    }
}
