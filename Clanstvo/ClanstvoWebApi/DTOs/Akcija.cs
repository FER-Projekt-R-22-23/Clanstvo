﻿using Clanstvo.Domain.Models;
using Clanstvo.Providers.Http.DTOs;

namespace ClanstvoWebApi.DTOs;

public class Akcija
{
    public int IdAkcije { get; set; }

    public string Naziv { get; set; } = string.Empty;


}

public static partial class DtoMapping
 {
    public static AkcijaSudionik ToDto(this Clanstvo.Domain.Models.Akcija akcija)
    {
            return new AkcijaSudionik()
            {
                IdAkcije = akcija.Id,
                Naziv = akcija.Naziv
            };
    }


    /*
    public static Domain.Models.Akcija ToDomain(AkcijaSudionik akcija)
    {
            return new Domain.Models.Akcija(akcija.IdAkcije, akcija.Naziv);
    }
    */
}


