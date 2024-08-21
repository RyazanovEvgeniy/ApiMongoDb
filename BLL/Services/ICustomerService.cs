using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace BLL.Services;

public class CustomerService : ICustomerService
{
    private ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> GetByIdAsync(string id)
    {
        return await _customerRepository.GetByIdAsync(id);
    }

    public async Task<Customer> AddAsync(Customer customer)
    {
        return await _customerRepository.AddAsync(customer);
    }
}
