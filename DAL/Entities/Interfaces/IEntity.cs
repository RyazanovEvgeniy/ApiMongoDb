using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Entities.Interfaces;

public interface IEntity<MongoEntityId>
{
    [BsonId]
    MongoEntityId? Id {  get; set; }
}

public interface IEntity : IEntity<string>
{

}