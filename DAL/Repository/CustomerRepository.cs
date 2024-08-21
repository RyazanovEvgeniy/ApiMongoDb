using MongoDB.Driver;

using DAL.Entities;
using DAL.Repository.Interfaces;
using DAL.Data.Interfaces;

namespace DAL.Repository;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(IMongoDbContext context) : base(context) { }
}