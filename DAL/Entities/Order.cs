using MongoDB.Bson;

namespace DAL.Entities;

public class Order : Entity
{
    public ObjectId CustomerId { get; set; }
}