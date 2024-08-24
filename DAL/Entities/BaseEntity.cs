using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Entities;

[DataContract]
[BsonIgnoreExtraElements(Inherited = true)]
public abstract class BaseEntity
{
    [DataMember]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
}