using Clanstvo.Commons;
using Clanstvo.DataAccess.SqlServer.Data;
using Clanstvo.DataAccess.SqlServer.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace Clanstvo.Repositories.SqlServer;
public class ClanarinaRepository : IClanarinaRepository
{
    private readonly ClanstvoContext _dbContext;

    public ClanarinaRepository(ClanstvoContext dbContext)
    {
        _dbContext = dbContext;
    }
    public bool Exists(Clanarina model)
    {
        return _dbContext.Clanarina
                         .AsNoTracking()
                         .Contains(model);
    }

    public bool Exists(int id)
    {
        var model = _dbContext.Clanarina.
                                AsNoTracking().
                                FirstOrDefault(clanarina => clanarina.Id.Equals(id));
        return model is not null;
    }

    public Option<Clanarina> Get(int id)
    {
        var model = _dbContext.Clanarina
                              .AsNoTracking()
                              .FirstOrDefault(clanarina => clanarina.Id.Equals(id));

        return model is not null
            ? Options.Some(model)
            : Options.None<Clanarina>();
    }

    public IEnumerable<Clanarina> GetAll()
    {
        var models = _dbContext.Clanarina
                               .ToList();

        return models;
    }

    public bool Insert(Clanarina model)
    {
        if (_dbContext.Clanarina.Add(model).State == Microsoft.EntityFrameworkCore.EntityState.Added)
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
        var model = _dbContext.Clanarina
                               .AsNoTracking()
                               .FirstOrDefault(clanarina => clanarina.Id.Equals(id));

        if (model is not null)
        {
            _dbContext.Clanarina.Remove(model);

            return _dbContext.SaveChanges() > 0;
        }
        return false;
    }

    public bool Update(Clanarina model)
    {
        // detach
        if (_dbContext.Clanarina.Update(model).State == Microsoft.EntityFrameworkCore.EntityState.Modified)
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


