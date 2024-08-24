
using System.Linq.Expressions;

using DAL.Entities;

namespace DAL.Repository.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetById(string id);
    Task<List<TEntity>> GetAllAsync();
    Task<string> AddAsync(TEntity entity);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(string id);
    IQueryable<TEntity> AsQueryable();
}