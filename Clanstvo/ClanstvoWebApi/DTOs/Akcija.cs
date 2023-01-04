using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using DbModels = Clanstvo.DataAccess.SqlServer.Data.DbModels;
using DomainModels = Clanstvo.Domain.Models;

namespace ClanstvoWebApi.DTOs
{
    public class Akcija
    {
        public int IdAkcije { get; set; }

        [Required(ErrorMessage = "Naziv akcije can't be null")]
        [StringLength(50, ErrorMessage = "Naziv akcije cant't be longer than 50 characters")]
        public string Naziv { get; set; } = String.Empty;
        public int MjestoPbr { get; set; }
        public int Organizator { get; set; }
        public int KontaktOsoba { get; set; }

        public string? Vrsta { get; set; }
    }
}