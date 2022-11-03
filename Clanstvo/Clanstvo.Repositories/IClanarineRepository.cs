namespace Clanstvo.Repositories;

/// <summary>
/// Facade interface for a Person repository
/// </summary>
/// <typeparam name="TKey"></typeparam>
/// <typeparam name="TModel"></typeparam>
public interface IClanarineRepository<TKey, TModel> : IRepository<TKey, TModel>, IAggregateRepository<TKey, TModel>
{
}