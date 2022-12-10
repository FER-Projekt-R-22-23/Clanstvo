using Clanstvo.Commons;
using Clanstvo.DataAccess.SqlServer.Data;
using Clanstvo.DataAccess.SqlServer.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Clanstvo.Repositories.SqlServer;

public class RangStarostRepository : IRangStarostRepository
{
    private readonly ClanstvoContext _dbContext;

    public RangStarostRepository(ClanstvoContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool Exists(RangStarost model)
    {
        return _dbContext.RangStarost
                         .AsNoTracking()
                         .Contains(model);
    }

    public bool Exists(int id)
    {
        var model = _dbContext.RangStarost
                              .AsNoTracking()
                              .FirstOrDefault(rang => rang.Id.Equals(id));
        return model is not null;
    }

    public Option<RangStarost> Get(int id)
    {
        var model = _dbContext.RangStarost
                              .AsNoTracking()
                              .FirstOrDefault(rang => rang.Id.Equals(id));

        return model is not null
            ? Options.Some(model)
            : Options.None<RangStarost>();
    }


    public IEnumerable<RangStarost> GetAll()
    {
        var models = _dbContext.RangStarost
                               .ToList();

        return models;
    }


    public bool Insert(RangStarost model)
    {
        if (_dbContext.RangStarost.Add(model).State == Microsoft.EntityFrameworkCore.EntityState.Added)
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
        var model = _dbContext.RangStarost
                              .AsNoTracking()
                              .FirstOrDefault(rang => rang.Id.Equals(id));

        if (model is not null)
        {
            _dbContext.RangStarost.Remove(model);

            return _dbContext.SaveChanges() > 0;
        }
        return false;
    }

    public bool Update(RangStarost model)
    {
        // detach
        if (_dbContext.RangStarost.Update(model).State == Microsoft.EntityFrameworkCore.EntityState.Modified)
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
