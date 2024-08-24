using Microsoft.Extensions.Options;
using MongoDB.Driver;

using DAL.Data.Interfaces;

namespace DAL.Data;

public class MongoDbContext : IMongoDbContext
{
    public IMongoDatabase Database { get; }

    public MongoDbContext(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        Database = client.GetDatabase(settings.Value.DatabaseName);
    }
}