﻿using ClanstvoWebApi.Data.DbModels;
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
    internal class ClanRangStarostDto
    {
        [Key]
        public int ClanId { get; set; }
        [Key]
        public int RangStarostId { get; set; }
        [Column(TypeName = "date")]
        public DateTime Datum { get; set; }

        [ForeignKey("ClanId")]
        [InverseProperty("ClanRangStarost")]
        public virtual ClanoviDto Clan { get; set; }
        [ForeignKey("RangStarostId")]
        [InverseProperty("ClanRangStarost")]
        public virtual RangStarostDto RangStarost { get; set; }
    }
}