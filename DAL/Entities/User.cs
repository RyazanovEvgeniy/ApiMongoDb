using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Entities;

[DataContract]
[BsonIgnoreExtraElements(Inherited = true)]
public class User : BaseEntity
{
    [DataMember]
    [BsonRepresentation(BsonType.String)]
    public string? Name { get; set; }
}