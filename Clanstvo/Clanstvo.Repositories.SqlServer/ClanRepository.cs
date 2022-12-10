using Clanstvo.Commons;
using Clanstvo.DataAccess.SqlServer.Data;
using Clanstvo.DataAccess.SqlServer.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Clanstvo.Repositories.SqlServer;

public class ClanRepository : IClanRepository<int, Clan>
{
    private readonly ClanstvoContext _dbContext;

    public ClanRepository(ClanstvoContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool Exists(Clan model)
    {
        return _dbContext.Clan
                         .AsNoTracking()
                         .Contains(model);
    }

    public bool Exists(int id)
    {
        var model = _dbContext.Clan
                              .AsNoTracking()
                              .FirstOrDefault(clan => clan.Id.Equals(id));
        return model is not null;
    }

    public Option<Clan> Get(int id)
    {
        var model = _dbContext.Clan
                              .AsNoTracking()
                              .FirstOrDefault(clan => clan.Id.Equals(id));

        return model is not null
            ? Options.Some(model)
            : Options.None<Clan>();
    }

    public Option<Clan> GetAggregate(int id)
    {
        var model = _dbContext.Clan
                              .Include(clan => clan.ClanRangZasluga)
                              .ThenInclude(clanRangZasluga => clanRangZasluga.RangZasluga)
                              .Include(clan => clan.ClanRangStarost)
                              .ThenInclude(clanRangStarost => clanRangStarost.RangStarost)
                              .Include(clan => clan.Clanarina)
                              .AsNoTracking()
                              .FirstOrDefault(clan => clan.Id.Equals(id)); // give me the first or null; substitute for .Where()
                                                                           // single or default throws an exception if more than one element meets the criteria

        return model is not null
            ? Options.Some(model)
            : Options.None<Clan>();
    }

    public IEnumerable<Clan> GetAll()
    {
        var models = _dbContext.Clan
                               .ToList();

        return models;
    }

    public IEnumerable<Clan> GetAllAggregates()
    {
        var models = _dbContext.Clan
                               .Include(clan => clan.ClanRangZasluga)
                               .ThenInclude(clanRangZasluga => clanRangZasluga.RangZasluga)
                               .Include(clan => clan.ClanRangStarost)
                               .ThenInclude(clanRangStarost => clanRangStarost.RangStarost)
                               .ToList();

        return models;
    }

    public bool Insert(Clan model)
    {
        if (_dbContext.Clan.Add(model).State == Microsoft.EntityFrameworkCore.EntityState.Added)
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
        var model = _dbContext.Clan
                              .AsNoTracking()
                              .FirstOrDefault(clan => clan.Id.Equals(id));

        if (model is not null)
        {
            _dbContext.Clan.Remove(model);

            return _dbContext.SaveChanges() > 0;
        }
        return false;
    }

    public bool Update(Clan model)
    {
        // detach
        if (_dbContext.Clan.Update(model).State == Microsoft.EntityFrameworkCore.EntityState.Modified)
        {
            var isSuccess = _dbContext.SaveChanges() > 0;

            // every Update attaches the entity object and EF begins tracking
            // we detach the entity object from tracking, because this can cause problems when a repo is not set as a transient service
            _dbContext.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            return isSuccess;
        }

        return false;
    }

    public bool UpdateAggregate(Clan model)
    {
        if (_dbContext.Clan.Update(model).State == Microsoft.EntityFrameworkCore.EntityState.Modified)
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