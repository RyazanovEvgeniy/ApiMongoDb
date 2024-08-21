using MongoDB.Driver;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;

using DAL.Data.Interfaces;
using DAL.Entities.Interfaces;
using DAL.Repository.Interfaces;
using DAL.Data;
using DAL.Entities;

namespace DAL.Repository;

public class BaseRepository<T, TKey> : IBaseRepository<T, TKey> where T : IEntity<TKey>
{
    public BaseRepository(IMongoDbContext context)
    {
        Collection = context.Database.GetCollection<T>(GetCollectionName());
    }

    public IMongoCollection<T> Collection { get; }

    public virtual IQueryable<T> AsQueryable()
    {
        return Collection.AsQueryable();
    }

    public virtual void Add(IEnumerable<T> entities)
    {
        Collection.InsertMany(entities);
    }

    public async virtual Task<T> AddAsync(T entity)
    {
        await Collection.InsertOneAsync(entity);
        return entity;
    }

    public virtual long Count()
    {
        return Collection.CountDocuments(_ => true);
    }

    public virtual void Delete(Expression<Func<T, bool>> predicate)
    {
        Collection.DeleteMany<T>(predicate);
    }

    public virtual void Delete(T entity)
    {
        var filter = Builders<T>.Filter.Eq(s => s.Id, entity.Id);
        Collection.DeleteOne(filter);
    }

    public virtual void Delete(TKey id)
    {
        var filter = Builders<T>.Filter.Eq(s => s.Id, id);
        Collection.DeleteOne(filter);
    }

    public virtual void DeleteAll()
    {
        Collection.DeleteMany(_ => true);
    }

    public virtual void Drop()
    {
        Collection.Database.DropCollection(Collection.CollectionNamespace.CollectionName);
    }

    public virtual bool Exists()
    {
        return Collection.AsQueryable().Any();
    }

    public virtual bool Exists(Expression<Func<T, bool>> predicate)
    {
        return Collection.AsQueryable().Any(predicate);
    }

    public async virtual Task<T> GetByIdAsync(TKey id)
    {
        var filter = Builders<T>.Filter.Eq(s => s.Id, id);
        return await Collection.Find(filter).SingleOrDefaultAsync();
    }

    public virtual void Update(IEnumerable<T> entities)
    {
        Parallel.ForEach(entities, entity => Update(entity));
    }

    public virtual T Update(T entity)
    {
        var filter = Builders<T>.Filter.Eq(s => s.Id, entity.Id);
        Collection.ReplaceOne(filter, entity);
        return entity;
    }

    private static string GetCollectionName()
    {
        var collectionName = typeof(T).GetTypeInfo().BaseType == typeof(object)
            ? GetCollectioNameFromInterface()
            : GetCollectionNameFromType(typeof(T));

        if (string.IsNullOrEmpty(collectionName))
            throw new ArgumentException("Collection name cannot be empty for this entity");
        return collectionName;
    }

    private static string GetCollectioNameFromInterface()
    {
        var att = typeof(T).GetTypeInfo().GetCustomAttribute<CollectionName>();
        return att != null ? att.Name : typeof(T).Name;
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
            if (typeof(Entity).GetTypeInfo().IsAssignableFrom(entitytype))
            {
                while (entitytype.GetTypeInfo().BaseType != typeof(Entity))
                    entitytype = entitytype.GetTypeInfo().BaseType!;
            }

            return entitytype.Name;
        }
    }

    public virtual IEnumerator<T> GetEnumerator()
    {
        return Collection.AsQueryable().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Collection.AsQueryable().GetEnumerator();
    }

    public virtual Type ElementType => Collection.AsQueryable().ElementType;

    public virtual Expression Expression => Collection.AsQueryable().Expression;

    public virtual IQueryProvider Provider => Collection.AsQueryable().Provider;
}

public class BaseRepository<T> : BaseRepository<T, string>, IBaseRepository<T> where T : IEntity<string>
{
    public BaseRepository(IMongoDbContext context) : base(context)
    {
    }
}