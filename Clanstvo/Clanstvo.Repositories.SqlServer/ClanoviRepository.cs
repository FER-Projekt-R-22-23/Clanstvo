using Clanstvo.Commons;
using Clanstvo.DataAccess.SqlServer.Data;
using Clanstvo.DataAccess.SqlServer.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Clanstvo.Repositories.SqlServer;

public class ClanoviRepository : IClanoviRepository<int, Clanovi>
{
    private readonly ClanstvoContext _dbContext;

    public ClanoviRepository(ClanstvoContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool Exists(Clanovi model)
    {
        return _dbContext.Clanovi
                         .AsNoTracking()
                         .Contains(model);
    }

    public bool Exists(int id)
    {
        var model = _dbContext.Clanovi
                              .AsNoTracking()
                              .FirstOrDefault(clan => clan.Id.Equals(id));
        return model is not null;
    }

    public Option<Clanovi> Get(int id)
    {
        var model = _dbContext.Clanovi
                              .AsNoTracking()
                              .FirstOrDefault(clan => clan.Id.Equals(id));

        return model is not null
            ? Options.Some(model)
            : Options.None<Clanovi>();
    }

    public Option<Clanovi> GetAggregate(int id)
    {
        var model = _dbContext.Clanovi
                              .Include(clan => clan.ClanRangZasluga)
                              .ThenInclude(clanRangZasluga => clanRangZasluga.RangZasluga)
                              .AsNoTracking()
                              .FirstOrDefault(clan => clan.Id.Equals(id)); // give me the first or null; substitute for .Where()
                                                                               // single or default throws an exception if more than one element meets the criteria

        return model is not null
            ? Options.Some(model)
            : Options.None<Clanovi>();
    }

    public IEnumerable<Clanovi> GetAll()
    {
        var models = _dbContext.Clanovi
                               .ToList();

        return models;
    }

    public IEnumerable<Clanovi> GetAllAggregates()
    {
        var models = _dbContext.Clanovi
                               .Include(clan => clan.ClanRangZasluga)
                               .ThenInclude(clanRangZasluga => clanRangZasluga.RangZasluga)
                               .ToList();

        return models;
    }

    public bool Insert(Clanovi model)
    {
        if (_dbContext.Clanovi.Add(model).State == Microsoft.EntityFrameworkCore.EntityState.Added)
        {
            var isSuccess = _dbContext.SaveChanges() > 0;

            // every Add attaches the entity object and EF begins tracking
            // we detach the entity object from tracking, because this can cause problems when a repo is not set as a transient service
            _dbContext.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            return isSuccess;
        }

        return false;
    }

    public bool Remove(int id)
    {
        var model = _dbContext.Clanovi
                              .AsNoTracking()
                              .FirstOrDefault(clan => clan.Id.Equals(id));

        if (model is not null)
        {
            _dbContext.Clanovi.Remove(model);

            return _dbContext.SaveChanges() > 0;
        }
        return false;
    }

    public bool Update(Clanovi model)
    {
        // detach
        if (_dbContext.Clanovi.Update(model).State == Microsoft.EntityFrameworkCore.EntityState.Modified)
        {
            var isSuccess = _dbContext.SaveChanges() > 0;

            // every Update attaches the entity object and EF begins tracking
            // we detach the entity object from tracking, because this can cause problems when a repo is not set as a transient service
            _dbContext.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            return isSuccess;
        }

        return false;
    }

    public bool UpdateAggregate(Clanovi model)
    {
        if (_dbContext.Clanovi.Update(model).State == Microsoft.EntityFrameworkCore.EntityState.Modified)
        {
            var isSuccess = _dbContext.SaveChanges() > 0;

            // every Update attaches the entity object and EF begins tracking
            // we detach the entity object from tracking, because this can cause problems when a repo is not set as a transient service
            _dbContext.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            return isSuccess;
        }

        return false;
    }
}