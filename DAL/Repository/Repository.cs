using MongoDB.Driver;
using System.Reflection;

using DAL.Entities;
using DAL.Data;
using DAL.Data.Interfaces;
using DAL.Repository.Interfaces;

namespace DAL.Repository;

public class Repository<TEntity>(IMongoDbContext dbContext) : IRepository<TEntity> where TEntity : BaseEntity
{
    public IMongoCollection<TEntity> Collection { get; } = dbContext.Database.GetCollection<TEntity>(GetCollectionName());

    public virtual IQueryable<TEntity> AsQueryable()
    {
        return Collection.AsQueryable();
    }

    public async Task<TEntity?> GetById(string id)
    {
        var filter = Builders<TEntity>.Filter.Eq(s => s.Id, id);
        return await Collection.Find(filter).SingleOrDefaultAsync();
    }

    public async virtual Task<List<TEntity>> GetAllAsync()
    {
        return await Collection.Find(Builders<TEntity>.Filter.Empty).ToListAsync();
    }

    public async Task<string> AddAsync(TEntity entity)
    {
        await Collection.InsertOneAsync(entity);
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        var filter = Builders<TEntity>.Filter.Eq(s => s.Id, entity.Id);
        return (await Collection.ReplaceOneAsync(filter, entity)).IsAcknowledged;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var filter = Builders<TEntity>.Filter.Eq(s => s.Id, id);
        return (await Collection.DeleteOneAsync(filter)).DeletedCount > 0;
    }

    private static string GetCollectionName()
    {
        var collectionName = typeof(TEntity).GetTypeInfo().BaseType == typeof(object)
            ? GetCollectioNameFromInterface()
            : GetCollectionNameFromType(typeof(TEntity));

        if (string.IsNullOrEmpty(collectionName))
            throw new ArgumentException("Collection name cannot be empty for this entity");
        return collectionName;
    }

    private static string GetCollectioNameFromInterface()
    {
        var att = typeof(TEntity).GetTypeInfo().GetCustomAttribute<CollectionName>();
        return att != null ? att.Name : typeof(TEntity).Name;
    }

    private static string GetCollectionNameFromType(Type entitytype)
    {
        var att = entitytype.GetTypeInfo().GetCustomAttribute<CollectionName>();
        if (att != null)
        {
            return att.Name;
        }
        else
        {
            if (typeof(BaseEntity).GetTypeInfo().IsAssignableFrom(entitytype))
            {
                while (entitytype.GetTypeInfo().BaseType != typeof(BaseEntity))
                    entitytype = entitytype.GetTypeInfo().BaseType!;
            }

            return entitytype.Name;
        }
    }
}