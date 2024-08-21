using MongoDB.Driver;
using Microsoft.Extensions.Options;

using DAL.Data.Interfaces;

namespace DAL.Data;

public class MongoDbContext : IMongoDbContext
{
    public MongoDbContext(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        Database = client.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoDatabase Database { get; }
}