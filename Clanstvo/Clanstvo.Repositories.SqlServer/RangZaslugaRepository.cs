using Clanstvo.Commons;
using Clanstvo.DataAccess.SqlServer.Data;
using Clanstvo.DataAccess.SqlServer.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Clanstvo.Repositories.SqlServer;

public class RangZaslugaRepository : IRangZaslugatRepository<int,RangZasluga>
{
    private readonly ClanstvoContext _dbContext;

    public RangZaslugaRepository(ClanstvoContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool Exists(RangZasluga model)
    {
        return _dbContext.RangZasluga
                         .AsNoTracking()
                         .Contains(model);
    }

    public bool Exists(int id)
    {
        var model = _dbContext.RangZasluga
                              .AsNoTracking()
                              .FirstOrDefault(rang => rang.Id.Equals(id));
        return model is not null;
    }

    public Option<RangZasluga> Get(int id)
    {
        var model = _dbContext.RangZasluga
                              .AsNoTracking()
                              .FirstOrDefault(rang => rang.Id.Equals(id));

        return model is not null
            ? Options.Some(model)
            : Options.None<RangZasluga>();
    }


    public IEnumerable<RangZasluga> GetAll()
    {
        var models = _dbContext.RangZasluga
                               .ToList();

        return models;
    }


    public bool Insert(RangZasluga model)
    {
        if (_dbContext.RangZasluga.Add(model).State == Microsoft.EntityFrameworkCore.EntityState.Added)
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
        var model = _dbContext.RangZasluga
                              .AsNoTracking()
                              .FirstOrDefault(rang => rang.Id.Equals(id));

        if (model is not null)
        {
            _dbContext.RangZasluga.Remove(model);

            return _dbContext.SaveChanges() > 0;
        }
        return false;
    }

    public bool Update(RangZasluga model)
    {
        // detach
        if (_dbContext.RangZasluga.Update(model).State == Microsoft.EntityFrameworkCore.EntityState.Modified)
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
