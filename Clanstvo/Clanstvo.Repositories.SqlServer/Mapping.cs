using Clanstvo.Domain.Models;
using System.Data;
using System.Globalization;
using DbModels = Clanstvo.DataAccess.SqlServer.Data.DbModels;
namespace Clanstvo.Repositories.SqlServer;

public static class Mapping
{
    public static RangStarost ToDomain(this DbModels.RangStarost rang)
        => new RangStarost(
            rang.Id,
            rang.Naziv
    );

    public static DbModels.RangStarost ToDbModel(this RangStarost rang)
        => new DbModels.RangStarost()
        {
            Id = rang.Id,
            Naziv = rang.Naziv
        };


    public static RangZasluga ToDomain(this DbModels.RangZasluga rang)
        => new RangZasluga(
            rang.Id,
            rang.Naziv
    );

    public static DbModels.RangZasluga ToDbModel(this RangZasluga rang)
        => new DbModels.RangZasluga()
        {
            Id = rang.Id,
            Naziv = rang.Naziv
        };

    public static Clanarina ToDomain(this DbModels.Clanarina clanarina)
        => new Clanarina(
            clanarina.Id,
            clanarina.Placenost,
            clanarina.Iznos,
            clanarina.Godina,
            clanarina.ClanId,
            clanarina.Datum
            );

    public static DbModels.Clanarina ToDbModel(this Clanarina clanarina)
        => new DbModels.Clanarina()
        {
            Id = clanarina.Id,
            Placenost = clanarina.Placenost,
            Iznos = clanarina.Iznos,
            Godina = clanarina.Godina,
            ClanId = clanarina.ClanId,
            Datum = clanarina.Datum
        };

    //mozda dodati za ClanRangStarost i ClanRangZasluga (roleAssignment i PersonRole)

    /*public static ClanRangStarost ToDomain(this DbModels.ClanRangStarost clanRangStarost)
        => new ClanRangStarost(
            clanRangStarost.Datum,
            clanRangStarost.RangStarost.ToDomain()
            );*/

    public static Clan ToDomain(this DbModels.Clan clan)
        => new Clan(
            clan.Id,
            clan.Ime,
            clan.Prezime,
            clan.DatumRodenja,
            clan.Slika,
            clan.Adresa,
            clan.ImaMaramu,
            clan.DatumMarama,
            clan.MjestoMarama
        );

    public static DbModels.Clan ToDbModel(this Clan clan)
        => new DbModels.Clan()
        {
            Id = clan.Id,
            Ime = clan.Ime,
            Prezime = clan.Prezime,
            DatumRodenja = clan.DatumRodenja,
            Slika = clan.Slika,
            Adresa = clan.Adresa,
            ImaMaramu = clan.ImaMaramu,
            DatumMarama = clan.DatumMarama,
            MjestoMarama = clan.MjestoMarama
        };

}
