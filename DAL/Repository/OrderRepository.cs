using MongoDB.Driver;

using DAL.Entities;
using DAL.Repository.Interfaces;

namespace DAL.Repository;

public class OrderRepository : IOrderRepository
{
    private IMongoCollection<Order> _collection;

    public OrderRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<Order>("orders");
    }
}