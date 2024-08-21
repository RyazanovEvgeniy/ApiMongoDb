using MongoDB.Driver;

namespace DAL.Data.Interfaces;

public interface IMongoDbContext
{
    IMongoDatabase Database { get; }
}