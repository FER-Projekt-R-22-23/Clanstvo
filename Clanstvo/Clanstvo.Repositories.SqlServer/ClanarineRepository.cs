using Clanstvo.Commons;
using Clanstvo.DataAccess.SqlServer.Data;
using Clanstvo.DataAccess.SqlServer.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace Clanstvo.Repositories.SqlServer;
public class ClanarineRepository : IClanarineRepository<int, Clanarine>
{
    private readonly ClanstvoContext _dbContext;

    public ClanarineRepository(ClanstvoContext dbContext)
    {
        _dbContext = dbContext;
    }
    public bool Exists(Clanarine model)
    {
        return _dbContext.Clanarine
                         .AsNoTracking()
                         .Contains(model);
    }

    public bool Exists(int id)
    {
        var model = _dbContext.Clanarine.
                                AsNoTracking().
                                FirstOrDefault(clanarina => clanarina.Id.Equals(id));
        return model is not null;
    }

    public Option<Clanarine> Get(int id)
    {
        var model = _dbContext.Clanarine
                              .AsNoTracking()
                              .FirstOrDefault(clanarina => clanarina.Id.Equals(id));

        return model is not null
            ? Options.Some(model)
            : Options.None<Clanarine>();
    }

    public IEnumerable<Clanarine> GetAll()
    {
        var models = _dbContext.Clanarine
                               .ToList();

        return models;
    }

    public bool Insert(Clanarine model)
    {
        if (_dbContext.Clanarine.Add(model).State == Microsoft.EntityFrameworkCore.EntityState.Added)
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
        var model = _dbContext.Clanarine
                               .AsNoTracking()
                               .FirstOrDefault(clanarina => clanarina.Id.Equals(id));

        if (model is not null)
        {
            _dbContext.Clanarine.Remove(model);

            return _dbContext.SaveChanges() > 0;
        }
        return false;
    }

    public bool Update(Clanarine model)
    {
        // detach
        if (_dbContext.Clanarine.Update(model).State == Microsoft.EntityFrameworkCore.EntityState.Modified)
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


