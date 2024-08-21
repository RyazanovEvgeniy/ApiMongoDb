using MongoDB.Driver;
using System.Linq.Expressions;

using DAL.Entities.Interfaces;

namespace DAL.Repository.Interfaces;

public interface IBaseRepository<T, in TKey> : IQueryable<T> where T : IEntity<TKey>
{
    IMongoCollection<T> Collection { get; }
    IQueryable<T> AsQueryable();
    Task<T> GetByIdAsync(TKey id);
    Task<T> AddAsync(T entity);
    void Add(IEnumerable<T> entities);
    T Update(T entity);
    void Update(IEnumerable<T> entities);
    void Delete(TKey id);
    void Delete(T entity);
    void Delete(Expression<Func<T, bool>> predicate);
    void DeleteAll();
    void Drop();
    long Count();
    bool Exists();
    bool Exists(Expression<Func<T, bool>> predicate);
}

public interface IBaseRepository<T> : IBaseRepository<T, string> where T : IEntity<string>
{
}