using DAL.Entities;

namespace DAL.Repository.Interfaces;

public interface ICustomerRepository
{
    Task<Customer> GetByIdAsync(string id);
    Task<Customer> AddAsync(Customer customer);
}