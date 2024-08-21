using DAL.Entities;

namespace BLL.Services.Interfaces;

public interface ICustomerService
{
    Task<Customer> GetByIdAsync(string id);
    Task<Customer> AddAsync(Customer customer);
}