using DAL.Entities;

namespace BLL.Services.Interfaces;

public interface IUserService
{
    Task<User?> GetByIdAsync(string id);
    Task<List<User>> GetAllAsync();
    Task<string> AddAsync(User user);
    Task<bool> UpdateAsync(User user);
    Task<bool> DeleteAsync(string id);
}