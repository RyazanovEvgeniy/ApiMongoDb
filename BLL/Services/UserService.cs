using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.UnitOfWork.Interfaces;

namespace BLL.Services;

public class UserService(IUnitOfWork unitOfWork) : IUserService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<string> AddAsync(User user)
    {
        return await _unitOfWork.Users.AddAsync(user);
    }

    public async Task<bool> DeleteAsync(string id)
    {
        return await _unitOfWork.Users.DeleteAsync(id);
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _unitOfWork.Users.GetAllAsync();
    }

    public async Task<User?> GetByIdAsync(string id)
    {
        return await _unitOfWork.Users.GetById(id);
    }

    public async Task<bool> UpdateAsync(User user)
    {
        return await _unitOfWork.Users.UpdateAsync(user);
    }
}
