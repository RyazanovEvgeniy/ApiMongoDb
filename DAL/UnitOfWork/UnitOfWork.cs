using MongoDB.Driver;

using DAL.Repository;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork.Interfaces;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    // private IMongoDatabase _database;
    // private ICustomerRepository? _customerRepository;
    // private IOrderRepository? _orderRepository;

    // public UnitOfWork(string connectionString, string databaseName)
    // {
    //     var client = new MongoClient(connectionString);
    //     _database = client.GetDatabase(databaseName);
    // }

    // public ICustomerRepository Customers => _customerRepository ?? new CustomerRepository(_database);
    // public IOrderRepository Orders => _orderRepository ?? new OrderRepository(_database);

    public void SaveChanges()
    {
        // You can perform any additional logic here if needed
        // For example, if you have cascading changes between entities, you can handle them here
        // Since MongoDB does not support ACID transactions across multiple documents,
        // the SaveChanges method will handle each entity's save operation independently.
    }

    public void Dispose()
    {
        // Clean up resources if needed
    }
}